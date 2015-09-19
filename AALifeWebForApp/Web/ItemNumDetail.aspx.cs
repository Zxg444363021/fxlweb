using System;
using System.Data;

public partial class ItemNumDetail : BasePage
{
    public string today = "";
    private int userId = 0;
    public string itemName = "";
    public string itemType = "";
    public string catTypeId = "0";

    protected void Page_Load(object sender, EventArgs e)
    {
        itemName = Request.QueryString["itemName"] ?? "";
        itemType = Request.QueryString["itemType"] ?? "";
        
        //比较分析明细进入使用
        today = Session["TodayDate"].ToString();
        if (Request.QueryString["date"] != null && Request.QueryString["date"] != "")
        {
            if (ValidHelper.CheckDate(Request.QueryString["date"]))
            {
                today = Request.QueryString["date"];
            }
        }

        userId = Int32.Parse(Session["UserID"].ToString());

        if (Request.QueryString["catTypeId"] != null && Request.QueryString["catTypeId"] != "")
        {
            catTypeId = Request.QueryString["catTypeId"];
        }

        if (!IsPostBack)
        {
            PopulateControls();
        }
    }

    protected void PopulateControls()
    {
        double priceMax = 0;
        DataTable dt = ItemAccess.GetItemNumDetailList(itemName, itemType, userId, Int32.Parse(catTypeId), today, "list", out priceMax);
        List.DataSource = dt;
        List.DataBind();

        this.hidChartData.Value = ItemHelper.GetChartData(dt, "ItemBuyDate");
    }
}