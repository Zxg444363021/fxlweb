using System;
using System.Web.UI.WebControls;
using System.Data;

public partial class UserZhuanTiShow : BasePage
{
    private int userId = 0;
    private int zhuanTiId = 0;
    private DataTable catTypeList = null;
    private DataTable itemTypeList = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        userId = Int32.Parse(Session["UserID"].ToString());
        zhuanTiId = Int32.Parse(Request.QueryString["ztid"]); 
        catTypeList = UserCategoryAccess.GetCategoryTypeList(userId);
        itemTypeList = ItemAccess.GetItemListType();

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

            if (Session["TodayDate"] != null)
            {
                string today = Session["TodayDate"].ToString();
                this.ItemBuyDateEmpIns.Text = today;
            }
        }
    }

    protected void BindGrid()
    {
        DataTable dt = ZhuanTiAccess.GetZhuanTiListDetail(zhuanTiId, userId);
        List.DataSource = dt;
        List.DataBind();

        ZhuanTiEntity zhuanTi = ZhuanTiAccess.GetZhuanTiListById(zhuanTiId, userId);
        this.ZhuanTiDate.Text = zhuanTi.ZhuanTiDate;
        this.ZhuanTiShouRu.Text = zhuanTi.ZhuanTiShouRu.ToString("0.0##");
        this.ZhuanTiZhiChu.Text = zhuanTi.ZhuanTiZhiChu.ToString("0.0##");
    }

    //进入编辑操作
    protected void List_RowEditing(object sender, GridViewEditEventArgs e)
    {
        List.EditIndex = e.NewEditIndex;
        BindGrid();

        HiddenField itemTypeIdHid = (HiddenField)List.Rows[e.NewEditIndex].FindControl("ItemTypeIDHid");
        DropDownList itemTypeDropDown = (DropDownList)List.Rows[e.NewEditIndex].FindControl("ItemTypeDropDown");
        TextBox itemBuyDate = (TextBox)List.Rows[e.NewEditIndex].FindControl("ItemBuyDateBox");

        itemTypeDropDown.DataSource = itemTypeList;
        itemTypeDropDown.DataTextField = "ItemTypeName";
        itemTypeDropDown.DataValueField = "ItemTypeValue";
        itemTypeDropDown.DataBind(); 
        
        if (itemTypeIdHid.Value != "")
        {
            itemTypeDropDown.Items.FindByValue(itemTypeIdHid.Value).Selected = true;
        }
        else
        {
            itemTypeDropDown.SelectedIndex = 0;
        }
    }

    //删除操作
    protected void List_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int itemId = Int32.Parse(List.DataKeys[e.RowIndex].Value.ToString());

        bool success = ItemAccess.DeleteItem(itemId, userId); 
        if (success)
        {
            List.EditIndex = -1;
            BindGrid();
        }
        else
        {
            Utility.Alert(this, "删除失败！");
            return;
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
        double itemPrice = Double.Parse(((TextBox)List.Rows[e.RowIndex].FindControl("ItemPriceBox")).Text.Trim());
        DateTime itemBuyDate = DateTime.Parse(((TextBox)List.Rows[e.RowIndex].FindControl("ItemBuyDateBox")).Text.Trim() + " " + DateTime.Now.ToString("HH:mm:ss"));
        
        ItemEntity item = ItemAccess.GetItemListById(itemId);
        item.ItemID = itemId;
        item.ItemType = itemType;
        item.ItemName = itemName;
        item.ItemPrice = itemPrice;
        item.ItemBuyDate = itemBuyDate;
        item.Synchronize = 1;

        bool success = ItemAccess.UpdateItem(item, 1);
        if (success)
        {
            Session["TodayDate"] = itemBuyDate.ToString("yyyy-MM-dd");

            List.EditIndex = -1;
            BindGrid();
        }
    }
    
    //快速添加消费
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        string itemName = this.ItemNameEmpIns.Text.Trim();
        if (itemName == "")
        {
            Utility.Alert(this, "商品名称未填写！");
            return;
        }

        string itemType = this.ItemTypeEmpIns.SelectedValue;

        int catTypeId = Int32.Parse(this.CatTypeEmpIns.SelectedValue);
        Response.Cookies["CatTypeID"].Value = catTypeId.ToString();
        Response.Cookies["CatTypeID"].Expires = DateTime.MaxValue; 

        string itemPrice = this.ItemPriceEmpIns.Text.Trim();
        if (!ValidHelper.CheckDouble(itemPrice))
        {
            Utility.Alert(this, "商品价格填写错误！");
            return;
        }

        string itemBuyDateStr = this.ItemBuyDateEmpIns.Text;
        DateTime itemBuyDate = DateTime.Parse(itemBuyDateStr + " " + DateTime.Now.ToString("HH:mm:ss"));

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
        item.ZhuanTiID = zhuanTiId;

        bool success = ItemAccess.InsertItem(item, 1);
        if (success)
        {
            Session["TodayDate"] = itemBuyDate.ToString("yyyy-MM-dd");
            this.ItemNameEmpIns.Text = "";
            this.ItemPriceEmpIns.Text = "";

            List.EditIndex = -1;
            BindGrid();
        }
        else
        {
            Utility.Alert(this, "添加失败！");
            return;
        }
    }
}
