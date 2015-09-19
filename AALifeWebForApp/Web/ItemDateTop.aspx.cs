using System;
using System.Data;

public partial class ItemDateTop : BasePage
{
    private string today = "";
    private int userId = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        userId = Int32.Parse(Session["UserID"].ToString());

        #region 传入日期
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
        #endregion
        today = Session["TodayDate"].ToString();

        if (!IsPostBack)
        {
            PopulateControls();
        }
    }

    protected void PopulateControls()
    {
        double priceMax = 0;
        DataTable dt = ItemAccess.GetItemDateTopList(today, userId, "list", out priceMax);
        DateTop.DataSource = dt;
        DateTop.DataBind();

        this.hidChartData.Value = ItemHelper.GetChartData(dt, "ItemBuyDate");
    }
}