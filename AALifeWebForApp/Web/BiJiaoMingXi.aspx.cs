using System;
using System.Data;

public partial class BiJiaoMingXi : BasePage
{
    private string today = "";
    private int userId = 0;
    private int catTypeId = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["catTypeId"] != null && Request.QueryString["catTypeId"] != "")
        {
            if (!ValidHelper.CheckNumber(Request.QueryString["catTypeId"]))
            {
                Response.Redirect("FenLeiZongJi.aspx");
            }
            else
            {
                catTypeId = Int32.Parse(Request.QueryString["catTypeId"]);
            }
        }

        today = Session["TodayDate"].ToString();
        userId = Int32.Parse(Session["UserID"].ToString());

        if (!IsPostBack)
        {
            PopulateControls();
        }
    }

    protected void PopulateControls()
    {
        double priceMax = 0;
        int countMax = 0;
        DataTable dt = ItemAccess.GetBiJiaoMingXiList(catTypeId, today, userId, out priceMax, out countMax);
        CatTypeList.DataSource = dt;
        CatTypeList.DataBind();

        this.hidChartData.Value = ItemHelper.GetChartData(dt, "PageUrlCur");
        this.hidChartData2.Value = ItemHelper.GetChartData(dt, "PageUrlPrev");
    }
}