using System;
using System.Data;

public partial class MonthList : BasePage
{
    private int userId = 0;
    private string today = "";

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
        DataTable dt = ItemAccess.GetMonthList(today, userId);
        List.DataSource = dt;
        List.DataBind();

        double zhichuPrice = 0;
        double shouruPrice = 0;
        double jiePrice = 0;
        double huanPrice = 0;
        foreach (DataRow dr in dt.Rows)
        {
            zhichuPrice += Double.Parse(dr["ZhiChuPrice"].ToString());
            shouruPrice += Double.Parse(dr["ShouRuPrice"].ToString());
            jiePrice -= Double.Parse(dr["JiePrice"].ToString());
            huanPrice -= Double.Parse(dr["HuanPrice"].ToString());
        }

        this.Label2.Text = zhichuPrice.ToString("0.0##");
        this.Label3.Text = shouruPrice.ToString("0.0##");
        this.Label4.Text = jiePrice.ToString("0.##");
        this.Label5.Text = huanPrice.ToString("0.##");
    }
}
