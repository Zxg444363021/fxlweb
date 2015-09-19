using System;
using System.Data;

public partial class BiJiaoFenXi : BasePage
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
        DataTable dt = ItemAccess.GetBiJiaoFenXiList(today, userId, "", out priceMax);
        List.DataSource = dt;
        List.DataBind();

        double totalCur = 0;
        double totalPrev = 0;
        foreach (DataRow dr in dt.Rows)
        {
            totalCur += Double.Parse(dr["ItemPriceCur"].ToString());
            totalPrev += Double.Parse(dr["ItemPricePrev"].ToString());
        }

        this.Label2.Text = totalCur.ToString("0.0##");
        this.Label3.Text = totalPrev.ToString("0.0##");

        DataTable dd = ItemAccess.GetBiJiaoFenXiList(today, userId, "chart", out priceMax);
        this.hidChartData.Value = ItemHelper.GetChartData(dd, "PageUrl");
    }
}