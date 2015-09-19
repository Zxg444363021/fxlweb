using System;
using System.Data;

public partial class FenLeiZongJiMingXi : BasePage
{
    private string today = "";
    private int userId = 0;
    public int catTypeId = 0;

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

        userId = Int32.Parse(Session["UserID"].ToString()); 
        today = Session["TodayDate"].ToString();

        if (!IsPostBack)
        {
            PopulateControls();
        }
    }

    protected void PopulateControls()
    {
        double priceMax = 0;
        DataTable dt = ItemAccess.GetFenLeiZongJiMingXiList(catTypeId, today, userId, out priceMax);
        List.DataSource = dt;
        List.DataBind();

        this.hidChartData.Value = ItemHelper.GetChartData(dt, "PageUrl");
    }
}