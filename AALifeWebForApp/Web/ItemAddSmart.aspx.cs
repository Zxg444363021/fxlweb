using System;
using System.Data;
using System.Web.UI.WebControls;

public partial class ItemAddSmart : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int userId = Int32.Parse(Session["UserID"].ToString());

            DataTable catTypeList = UserCategoryAccess.GetCategoryTypeList(userId);
            this.CatTypeList.DataSource = catTypeList;
            this.CatTypeList.DataBind();

            this.CategoryTypeDown.DataSource = catTypeList;
            this.CategoryTypeDown.DataTextField = "CategoryTypeName";
            this.CategoryTypeDown.DataValueField = "CategoryTypeID";
            this.CategoryTypeDown.DataBind();
            this.CategoryTypeDown.Items.Insert(0, new ListItem("请选择", "0"));

            this.ZhuanTiDown.DataSource = ZhuanTiAccess.GetZhuanTiList(userId);
            this.ZhuanTiDown.DataTextField = "ZhuanTiName";
            this.ZhuanTiDown.DataValueField = "ZTID";
            this.ZhuanTiDown.DataBind();
            this.ZhuanTiDown.Items.Insert(0, new ListItem("请选择", "0"));

            this.ItemType.Attributes.Add("readonly", "readonly");
            this.CategoryTypeDown.Attributes.Add("readonly", "readonly");
            this.ItemBuyDate.Attributes.Add("readonly", "readonly");
            //this.ItemBuyDate1.Attributes.Add("readonly", "readonly");
            //this.ItemBuyDate2.Attributes.Add("readonly", "readonly");

            if (Session["TodayDate"] != null)
            {
                string today = Session["TodayDate"].ToString();
                string today2 = DateTime.Parse(today).AddMonths(11).ToString("yyyy-MM-dd");

                this.ItemBuyDate.Text = today + " " + ItemHelper.GetWeekString(today, 0);
                this.ItemBuyDateHid.Value = today;

                this.ItemBuyDate1.Text = today;
                this.ItemBuyDate2.Text = today2;
            }
            
            //钱包
            this.CardDown.DataSource = CardAccess.GetCardList(userId);
            this.CardDown.DataTextField = "CardName";
            this.CardDown.DataValueField = "CardID";
            this.CardDown.DataBind(); 
            if (Request.Cookies["CardID"] != null)
            {
                string cardId = Request.Cookies["CardID"].Value;
                this.CardDown.SelectedValue = cardId;
            }
        }
    }

    protected void SubmitButtom_Click(object sender, EventArgs e)
    {
        int result = SaveItem();
        if (result == 1)
        {
            Utility.Confirm(this, "添加成功，是否继续添加？", "ItemAddSmart.aspx", "ItemList.aspx");
        }
        else
        {
            Utility.Alert(this, "添加失败！");
        }        
    }

    protected void Buttom1_Click(object sender, EventArgs e)
    {
        int result = SaveItem();
        if (result == 1)
        {
            Utility.Alert(this, "添加成功。");
        }
        else
        {
            Utility.Alert(this, "添加失败！");
        }
    }

    protected int SaveItem()
    {
        string itemType = this.ItemTypeHid.Value;
        if (itemType == "")
        {
            Utility.Alert(this, "消费分类填写错误！");
            return 2;
        }

        int catTypeId = Int32.Parse(this.CategoryTypeDown.SelectedValue);
        if (catTypeId == 0)
        {
            Utility.Alert(this, "商品类别填写错误！");
            return 2;
        }
        Response.Cookies["CatTypeID"].Value = catTypeId.ToString();
        Response.Cookies["CatTypeID"].Expires = DateTime.MaxValue;

        string itemName = this.ItemName.Text.Trim();
        if (itemName == "")
        {
            Utility.Alert(this, "商品名称填写错误！");
            return 2;
        }

        int userId = Int32.Parse(Session["UserID"].ToString());

        string itemPrice = this.ItemPrice.Text.Trim();
        if (!ValidHelper.CheckDouble(itemPrice))
        {
            Utility.Alert(this, "商品价格填写错误！");
            return 2;
        }

        int zhuanTiId = Int32.Parse(this.ZhuanTiDown.SelectedValue);

        int cardId = Int32.Parse(this.CardDown.SelectedValue);
        Response.Cookies["CardID"].Value = cardId.ToString();
        Response.Cookies["CardID"].Expires = DateTime.MaxValue; 

        DateTime itemBuyDate = DateTime.Now;
        DateTime itemBuyDate1 = DateTime.Now;
        DateTime itemBuyDate2 = DateTime.Now;
        int monthRegion = 0;
        int regionId = 0;
        string regionType = "";
        if (this.RegionID.Checked)
        {
            if (!ValidHelper.CheckDate(this.ItemBuyDate1.Text.Trim()) || !ValidHelper.CheckDate(this.ItemBuyDate2.Text.Trim()))
            {
                Utility.Alert(this, "购买日期填写错误！");
                return 2;
            }
            else
            {
                itemBuyDate1 = DateTime.Parse(this.ItemBuyDate1.Text.Trim() + " " + DateTime.Now.ToString("HH:mm:ss"));
                itemBuyDate2 = DateTime.Parse(this.ItemBuyDate2.Text.Trim() + " " + DateTime.Now.ToString("HH:mm:ss"));
            }

            regionType = this.RegionTypeHid.Value;
            itemBuyDate = itemBuyDate1;
            regionId = Int32.Parse(ItemAccess.GetItemListMaxRegionId(userId));
            monthRegion = ItemHelper.GetMonthRegion(itemBuyDate1, itemBuyDate2, regionType);

            //判断区间最大天数
            int maxRegion = 0;
            string regionStr = "";
            switch (regionType)
            {
                case "d":
                case "b":
                    maxRegion = 92;
                    regionStr = "应小于3个月。";
                    break;
                case "w":
                    maxRegion = (int)Math.Floor((double)92 / 7);
                    regionStr = "应小于3个月。";
                    break;
                case "m":
                    maxRegion = 36;
                    regionStr = "应小于3年。";
                    break;
                case "y":
                    maxRegion = 15;
                    regionStr = "应小于15年。";
                    break;
            }

            if (monthRegion <= 0 || monthRegion >= maxRegion)
            {
                Utility.Alert(this, "区间日期设置不合理！" + regionStr);
                return 2;
            }
        }
        else
        {
            if (!ValidHelper.CheckDate(this.ItemBuyDateHid.Value))
            {
                Utility.Alert(this, "购买日期填写错误！");
                return 2;
            }
            else
            {
                itemBuyDate = DateTime.Parse(this.ItemBuyDateHid.Value + " " + DateTime.Now.ToString("HH:mm:ss"));
                itemBuyDate1 = itemBuyDate;
            }
        }

        ItemEntity item = new ItemEntity();
        item.ItemType = itemType;
        item.ItemName = itemName;
        item.CategoryTypeID = catTypeId;
        item.ItemPrice = Double.Parse(itemPrice);
        item.UserID = userId;
        item.RegionID = regionId;
        item.RegionType = regionType;
        item.Synchronize = 1;
        item.ZhuanTiID = zhuanTiId;
        item.CardID = cardId;

        bool success = false;
        for (int i = 0; i <= monthRegion; i++)
        {
            switch (regionType)
            {
                case "d":
                    itemBuyDate = itemBuyDate1.AddDays(i);
                    break;
                case "w":
                    itemBuyDate = itemBuyDate1.AddDays(i * 7);
                    break;
                case "m":
                    itemBuyDate = itemBuyDate1.AddMonths(i);
                    break;
                case "y":
                    itemBuyDate = itemBuyDate1.AddYears(i);
                    break;
                case "b":
                    DateTime curDate = itemBuyDate1.AddDays(i);
                    if (ItemHelper.GetWorkDayFinal(curDate, Session["UserWorkDay"].ToString()))
                    {
                        itemBuyDate = curDate;
                    }
                    else
                    {
                        continue;
                    }
                    break;
            }

            item.ItemBuyDate = itemBuyDate;
            success = ItemAccess.InsertItem(item, 1);
        }

        if (success)
        {
            Session["TodayDate"] = itemBuyDate1.ToString("yyyy-MM-dd");
            return 1;
        }
        else
        {
            return 0;
        }  
    }

}
