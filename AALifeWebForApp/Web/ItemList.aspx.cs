using System;
using System.Data;
using System.Web.UI.WebControls;
using System.Collections.Generic;

public partial class ItemList : BasePage 
{
    private int userId = 0;
    private string today = "";
    private DataTable catTypeList = null;
    private DataTable itemTypeList = null;
    private DataTable cardList = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        userId = Int32.Parse(Session["UserID"].ToString());
        catTypeList = UserCategoryAccess.GetCategoryTypeList(userId);
        itemTypeList = ItemAccess.GetItemListType();
        cardList = CardAccess.GetCardList(userId);

        if (Request.QueryString["date"] != null && Request.QueryString["date"] != "")
        {
            if (!ValidHelper.CheckDate(Request.QueryString["date"]))
            {
                Session["TodayDate"] = DateTime.Now.ToString("yyyy-MM-dd");
            }
            else
            {
                Session["TodayDate"] = Request.QueryString["date"];
            }
        }
        today = Session["TodayDate"].ToString();

        if (!IsPostBack)
        {
            BindGrid();

            this.CatTypeEmpIns.DataSource = catTypeList;
            this.CatTypeEmpIns.DataTextField = "CategoryTypeName";
            this.CatTypeEmpIns.DataValueField = "CategoryTypeID";
            this.CatTypeEmpIns.DataBind();
            if (Request.Cookies["CatTypeID"] != null)
            {
                this.CatTypeEmpIns.SelectedValue = Request.Cookies["CatTypeID"].Value;
            }

            this.ItemTypeEmpIns.DataSource = itemTypeList;
            this.ItemTypeEmpIns.DataTextField = "ItemTypeName";
            this.ItemTypeEmpIns.DataValueField = "ItemTypeValue";
            this.ItemTypeEmpIns.DataBind();

            //钱包
            this.CardEmpIns.DataSource = cardList;
            this.CardEmpIns.DataTextField = "CardName";
            this.CardEmpIns.DataValueField = "CardID";
            this.CardEmpIns.DataBind();
            if (Request.Cookies["CardID"] != null)
            {
                this.CardEmpIns.SelectedValue = Request.Cookies["CardID"].Value;
            }
        }
    }

    protected void BindGrid()
    {
        DataTable dt = ItemAccess.GetItemList(today, userId);
        List.DataSource = dt;
        List.DataBind();

        this.ZhuanTiDown.DataSource = ZhuanTiAccess.GetZhuanTiList(userId);
        this.ZhuanTiDown.DataTextField = "ZhuanTiName";
        this.ZhuanTiDown.DataValueField = "ZTID";
        this.ZhuanTiDown.DataBind();
        this.ZhuanTiDown.Items.Insert(0, new ListItem("请选择", "0"));

        double shouruPrice = 0;
        double zhichuPrice = 0;
        double shouruPriceMonth = 0;
        double zhichuPriceMonth = 0;
        double shouruPriceYear = 0;
        double zhichuPriceYear = 0;
        DataTable total = ItemAccess.GetItemListShouZhi(today, userId, out shouruPrice, out zhichuPrice, out shouruPriceMonth, out zhichuPriceMonth, out shouruPriceYear, out zhichuPriceYear);
        this.Label2.Text = shouruPrice.ToString("0.0##");
        this.Label4.Text = zhichuPrice.ToString("0.0##");
        this.Label1.Text = shouruPriceMonth.ToString("0.0##");
        this.Label3.Text = zhichuPriceMonth.ToString("0.0##");
        this.Label11.Text = shouruPriceYear.ToString("0.0##");
        this.Label12.Text = zhichuPriceYear.ToString("0.0##");

        double jiechuPrice = 0;
        double huanruPrice = 0;
        double jieruPrice = 0;
        double huanchuPrice = 0;
        DataTable jiehuan = ItemAccess.GetItemListJieHuan(today, userId, out jiechuPrice, out huanruPrice, out jieruPrice, out huanchuPrice);
        this.Label5.Text = jiechuPrice.ToString("0.##");
        this.Label6.Text = huanruPrice.ToString("0.##");
        this.Label7.Text = jieruPrice.ToString("0.##");
        this.Label8.Text = huanchuPrice.ToString("0.##");

        this.Label9.Text = (jiechuPrice - huanruPrice).ToString("0.##");
        this.Label10.Text = (jieruPrice - huanchuPrice).ToString("0.##");
    }

    //进入编辑操作
    protected void List_RowEditing(object sender, GridViewEditEventArgs e)
    {
        List.EditIndex = e.NewEditIndex;
        BindGrid();

        HiddenField catTypeIdHid = (HiddenField)List.Rows[e.NewEditIndex].FindControl("CatTypeIDHid");
        HiddenField itemTypeIdHid = (HiddenField)List.Rows[e.NewEditIndex].FindControl("ItemTypeIDHid");
        DropDownList catTypeDropDown = (DropDownList)List.Rows[e.NewEditIndex].FindControl("CatTypeDropDown");
        DropDownList itemTypeDropDown = (DropDownList)List.Rows[e.NewEditIndex].FindControl("ItemTypeDropDown");
        TextBox itemBuyDate = (TextBox)List.Rows[e.NewEditIndex].FindControl("ItemBuyDateBox");
        int regionId = Int32.Parse(((HiddenField)List.Rows[e.NewEditIndex].FindControl("RegionIDHid")).Value);
        DropDownList cardDropDown = (DropDownList)List.Rows[e.NewEditIndex].FindControl("CardDropDown");
        HiddenField cardIdHid = (HiddenField)List.Rows[e.NewEditIndex].FindControl("CardIDHid");

        TableCell catCell = (TableCell)catTypeDropDown.Parent;
        catCell.CssClass = "typeselect";
        TableCell itemCell = (TableCell)itemTypeDropDown.Parent;
        itemCell.CssClass = "typeselect";
        TableCell cardCell = (TableCell)cardDropDown.Parent;
        cardCell.CssClass = "typeselect";

        catTypeDropDown.DataSource = catTypeList;
        catTypeDropDown.DataTextField = "CategoryTypeName";
        catTypeDropDown.DataValueField = "CategoryTypeID";
        catTypeDropDown.DataBind();

        itemTypeDropDown.DataSource = itemTypeList;
        itemTypeDropDown.DataTextField = "ItemTypeName";
        itemTypeDropDown.DataValueField = "ItemTypeValue";
        itemTypeDropDown.DataBind();

        cardDropDown.DataSource = cardList;
        cardDropDown.DataTextField = "CardName";
        cardDropDown.DataValueField = "CardID";
        cardDropDown.DataBind();

        if (catTypeIdHid.Value != "")
        {
            catTypeDropDown.Items.FindByValue(catTypeIdHid.Value).Selected = true;
        }
        else
        {
            catTypeDropDown.SelectedIndex = 0;
        }

        if (itemTypeIdHid.Value != "")
        {
            itemTypeDropDown.Items.FindByValue(itemTypeIdHid.Value).Selected = true;
        }
        else
        {
            itemTypeDropDown.SelectedIndex = 0;
        }
        
        if (cardIdHid.Value != "")
        {
            cardDropDown.Items.FindByValue(cardIdHid.Value).Selected = true;
        }
        else
        {
            cardDropDown.SelectedIndex = 0;
        }

        if (regionId > 0)
        {
            itemBuyDate.Attributes.Add("disabled", "disabled");
            itemBuyDate.Style.Add("background", "#F4F4F4");
        }
    }

    //删除操作
    protected void List_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int itemId = Int32.Parse(List.DataKeys[e.RowIndex].Value.ToString());
        int regionId = Int32.Parse(((HiddenField)List.Rows[e.RowIndex].FindControl("RegionIDHid")).Value);
        HiddenField itemTypeIdHid = (HiddenField)List.Rows[e.RowIndex].FindControl("ItemTypeIDHid");
        HiddenField itemPriceHid = (HiddenField)List.Rows[e.RowIndex].FindControl("ItemPriceHid");
        int monthRegion = 1;

        bool success = false;
        if (regionId > 0)
        {
            DataTable dt = ItemAccess.GetItemListByRegionId(userId, regionId);
            monthRegion = dt.Rows.Count;
            foreach (DataRow dr in dt.Rows)
            {
                itemId = Int32.Parse(dr["ItemID"].ToString());
                success = ItemAccess.DeleteItem(itemId, userId);
            }
        }
        else
        {
            success = ItemAccess.DeleteItem(itemId, userId);
        }
        
        if (success)
        {
            List.EditIndex = -1;
            BindGrid();
        }
        else 
        {
            Utility.Alert(this, "删除失败！");
        }
    }

    //取消操作
    protected void List_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        List.EditIndex = -1;
        BindGrid();
    }

    //更新操作
    protected void List_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int itemId = Int32.Parse(List.DataKeys[e.RowIndex].Value.ToString());
        string itemName = ((TextBox)List.Rows[e.RowIndex].FindControl("ItemNameBox")).Text.Trim();
        if (itemName == "")
        {
            Utility.Alert(this, "商品名称未填写！");
            return;
        }
        string itemType = ((DropDownList)List.Rows[e.RowIndex].FindControl("ItemTypeDropDown")).SelectedValue.ToString();
        HiddenField itemTypeIdHid = (HiddenField)List.Rows[e.RowIndex].FindControl("ItemTypeIDHid");
        int catTypeId = Int32.Parse(((DropDownList)List.Rows[e.RowIndex].FindControl("CatTypeDropDown")).SelectedValue.ToString());
        string itemPrice = ((TextBox)List.Rows[e.RowIndex].FindControl("ItemPriceBox")).Text.Trim();
        HiddenField itemPriceHid = (HiddenField)List.Rows[e.RowIndex].FindControl("ItemPriceHid");
        DateTime itemBuyDate = DateTime.Parse(((TextBox)List.Rows[e.RowIndex].FindControl("ItemBuyDateBox")).Text.Trim() + " " + DateTime.Now.ToString("HH:mm:ss"));
        int recommend = Int32.Parse(((HiddenField)List.Rows[e.RowIndex].FindControl("RecommendHid")).Value);
        int itemAppId = Int32.Parse(((HiddenField)List.Rows[e.RowIndex].FindControl("ItemAppIDHid")).Value);
        int regionId = Int32.Parse(((HiddenField)List.Rows[e.RowIndex].FindControl("RegionIDHid")).Value);
        string regionType = ((HiddenField)List.Rows[e.RowIndex].FindControl("RegionTypeHid")).Value;
        int cardId = Int32.Parse(((DropDownList)List.Rows[e.RowIndex].FindControl("CardDropDown")).SelectedValue.ToString());

        ItemEntity item = ItemAccess.GetItemListById(itemId);
        item.ItemID = itemId;
        item.ItemType = itemType;
        item.ItemName = itemName;
        item.CategoryTypeID = catTypeId;
        item.ItemPrice = Double.Parse(itemPrice);
        item.ItemBuyDate = itemBuyDate;
        item.Synchronize = 1;
        item.CardID = cardId;

        int monthRegion = 1;
        bool success = false;
        if (regionId > 0)
        {
            DataTable dt = ItemAccess.GetItemListByRegionId(userId, regionId);
            monthRegion = dt.Rows.Count;
            foreach (DataRow dr in dt.Rows)
            {
                itemId = Int32.Parse(dr["ItemID"].ToString());
                itemAppId = Int32.Parse(dr["ItemAppID"].ToString());
                itemBuyDate = DateTime.Parse(dr["ItemBuyDate"].ToString());
                recommend = Int32.Parse(dr["Recommend"].ToString());

                item.ItemID = itemId;
                item.ItemAppID = itemAppId;
                item.ItemBuyDate = itemBuyDate;
                item.Recommend = recommend;

                success = ItemAccess.UpdateItem(item, 1);
            }
        }
        else
        {
            success = ItemAccess.UpdateItem(item, 1);
        }
        
        if (success)
        {
            List.EditIndex = -1;
            BindGrid();
        }
    }

    //列表为空时快速添加消费
    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        int result = SaveItem();
        if (result == 1)
        {
            Response.Redirect("ItemList.aspx");
        }
        else
        {
            Utility.Alert(this, "添加失败！");
        }
    }
    
    //列表为空时X2添加消费
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        int result = SaveItem();
        if (result == 1)
        {
            List.EditIndex = -1;
            BindGrid();
        }
        else
        {
            Utility.Alert(this, "添加失败！");
        }
    }

    //保存方法
    protected int SaveItem()
    {
        string itemName = this.ItemNameEmpIns.Text.Trim();
        if (itemName == "")
        {
            Utility.Alert(this, "商品名称未填写！");
            return 2;
        }

        string itemType = this.ItemTypeEmpIns.SelectedValue;

        int catTypeId = Int32.Parse(this.CatTypeEmpIns.SelectedValue);
        Response.Cookies["CatTypeID"].Value = catTypeId.ToString();
        Response.Cookies["CatTypeID"].Expires = DateTime.MaxValue;

        string itemPrice = this.ItemPriceEmpIns.Text.Trim();
        if (!ValidHelper.CheckDouble(itemPrice))
        {
            Utility.Alert(this, "商品价格填写错误！");
            return 2;
        }

        DateTime itemBuyDate = DateTime.Parse(today + " " + DateTime.Now.ToString("HH:mm:ss"));

        int cardId = Int32.Parse(this.CardEmpIns.SelectedValue);
        Response.Cookies["CardID"].Value = cardId.ToString();
        Response.Cookies["CardID"].Expires = DateTime.MaxValue;

        ItemEntity item = new ItemEntity();
        item.ItemType = itemType;
        item.ItemName = itemName;
        item.CategoryTypeID = catTypeId;
        item.ItemPrice = Double.Parse(itemPrice);
        item.ItemBuyDate = itemBuyDate;
        item.UserID = userId;
        item.RegionID = 0;
        item.RegionType = "";
        item.Synchronize = 1;
        item.CardID = cardId;

        bool success = ItemAccess.InsertItem(item, 1); 
        if (success)
        {
            Session["TodayDate"] = itemBuyDate.ToString("yyyy-MM-dd"); 
            return 1;
        }
        else
        {
            return 0;
        }
    }

    //点击CheckBox统计总价
    protected void ItemCheckBox_CheckedChanged(object sender, EventArgs e)
    {
        double shouruPrice = Double.Parse(this.Label2.Text);
        double zhichuPrice = Double.Parse(this.Label4.Text);
        double shouruPriceMonth = Double.Parse(this.Label1.Text);
        double zhichuPriceMonth = Double.Parse(this.Label3.Text);
        double shouruPriceYear = Double.Parse(this.Label11.Text);
        double zhichuPriceYear = Double.Parse(this.Label12.Text);

        double jiechuPrice = Double.Parse(this.Label5.Text);
        double huanruPrice = Double.Parse(this.Label6.Text);
        double jieruPrice = Double.Parse(this.Label7.Text);
        double huanchuPrice = Double.Parse(this.Label8.Text);

        try
        {
            CheckBox cb = (CheckBox)sender;
            Label price = (Label)cb.Parent.FindControl("ItemPriceLab");
            Label type = (Label)cb.Parent.FindControl("ItemTypeLab");
            if (cb.Checked)
            {
                switch (type.Text)
                {
                    case "收入":
                        shouruPrice += Double.Parse(price.Text);
                        shouruPriceMonth += Double.Parse(price.Text);
                        shouruPriceYear += Double.Parse(price.Text);
                        break;
                    case "支出":
                        zhichuPrice += Double.Parse(price.Text);
                        zhichuPriceMonth += Double.Parse(price.Text);
                        zhichuPriceYear += Double.Parse(price.Text);
                        break;
                    case "借出":
                        jiechuPrice += Double.Parse(price.Text);
                        break;
                    case "还入":
                        huanruPrice += Double.Parse(price.Text);
                        break;
                    case "借入":
                        jieruPrice += Double.Parse(price.Text);
                        break;
                    case "还出":
                        huanchuPrice += Double.Parse(price.Text);
                        break;
                }
            }
            else
            {
                switch (type.Text)
                {
                    case "收入":
                        shouruPrice -= Double.Parse(price.Text);
                        shouruPriceMonth -= Double.Parse(price.Text);
                        shouruPriceYear -= Double.Parse(price.Text);
                        break;
                    case "支出":
                        zhichuPrice -= Double.Parse(price.Text);
                        zhichuPriceMonth -= Double.Parse(price.Text);
                        zhichuPriceYear -= Double.Parse(price.Text);
                        break;
                    case "借出":
                        jiechuPrice -= Double.Parse(price.Text);
                        break;
                    case "还入":
                        huanruPrice -= Double.Parse(price.Text);
                        break;
                    case "借入":
                        jieruPrice -= Double.Parse(price.Text);
                        break;
                    case "还出":
                        huanchuPrice -= Double.Parse(price.Text);
                        break;
                }
            }
        }
        catch 
        { 
        }

        this.Label2.Text = shouruPrice.ToString("0.0##");
        this.Label4.Text = zhichuPrice.ToString("0.0##");
        this.Label1.Text = shouruPriceMonth.ToString("0.0##");
        this.Label3.Text = zhichuPriceMonth.ToString("0.0##");
        this.Label11.Text = shouruPriceYear.ToString("0.0##");
        this.Label12.Text = zhichuPriceYear.ToString("0.0##");

        this.Label5.Text = jiechuPrice.ToString("0.##");
        this.Label6.Text = huanruPrice.ToString("0.##");
        this.Label7.Text = jieruPrice.ToString("0.##");
        this.Label8.Text = huanchuPrice.ToString("0.##");

        this.Label9.Text = (jiechuPrice - huanruPrice).ToString("0.##");
        this.Label10.Text = (jieruPrice - huanchuPrice).ToString("0.##");
    }

    //点击推荐CheckBox
    protected void RecommendBox_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox cb = (CheckBox)sender;
        HiddenField itemIDHid = (HiddenField)cb.Parent.FindControl("ItemIDHid");
        HiddenField recommendHid = (HiddenField)cb.Parent.FindControl("RecommendHid");

        bool success = false;
        if (cb.Checked)
        {
            success = ItemAccess.UpdateItemRecommend(Int32.Parse(itemIDHid.Value), 1);
        }
        else
        {
            success = ItemAccess.UpdateItemRecommend(Int32.Parse(itemIDHid.Value), 0);
        }
    }

    //修改专题
    protected void SubmitButtom_Click(object sender, EventArgs e)
    {
        int itemId = Int32.Parse(this.ItemIDHid.Value);
        int zhuanTiId = Int32.Parse(this.ZhuanTiDown.SelectedValue);

        ItemEntity item = ItemAccess.GetItemListById(itemId);
        item.ZhuanTiID = zhuanTiId;
        item.Synchronize = 1;

        bool success = ItemAccess.UpdateItem(item, 1);        
        if (success)
        {
            List.EditIndex = -1;
            BindGrid();
        }
    }
}
