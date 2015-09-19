using System;
using System.Data;

public partial class JieHuanFenXi : BasePage
{
    public string today = "";
    private string type = "year";
    private int userId = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        userId = Int32.Parse(Session["UserID"].ToString());
        
        if (Request.QueryString["type"] != null && Request.QueryString["type"] != "")
        {
            type = Request.QueryString["type"];
        }

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
        DataTable dt = ItemAccess.GetJieHuanFenXiList(userId, today, type);
        List.DataSource = dt;
        List.DataBind();
        
        double zhichuPrice = 0;
        double shouruPrice = 0;
        double jieruPrice = 0;
        double huanchuPrice = 0;
        double jiechuPrice = 0;
        double huanruPrice = 0;
        foreach (DataRow dr in dt.Rows)
        {
            zhichuPrice += Double.Parse(dr["ZhiChuPrice"].ToString());
            shouruPrice += Double.Parse(dr["ShouRuPrice"].ToString());
            jiechuPrice += Double.Parse(dr["JieChuPrice"].ToString());
            huanruPrice += Double.Parse(dr["HuanRuPrice"].ToString());
            jieruPrice += Double.Parse(dr["JieRuPrice"].ToString());
            huanchuPrice += Double.Parse(dr["HuanChuPrice"].ToString());
        }

        this.Label2.Text = zhichuPrice.ToString("0.0##");
        this.Label3.Text = shouruPrice.ToString("0.0##");
        this.Label4.Text = jiechuPrice.ToString("0.##");
        this.Label5.Text = huanruPrice.ToString("0.##");
        this.Label6.Text = jieruPrice.ToString("0.##");
        this.Label7.Text = huanchuPrice.ToString("0.##");

        this.Label8.Text = (shouruPrice - zhichuPrice).ToString("0.0##");
        this.Label9.Text = (jiechuPrice - huanruPrice).ToString("0.##");
        this.Label10.Text = (jieruPrice - huanchuPrice).ToString("0.##");
    }

    public string GetURL(string date)
    {
        if (type == "year")
        {
            return "JieHuanFenXi.aspx?date=" + date + "-01-01&type=month";
        }
        else
        {
            return "MonthList.aspx?date=" + date + "-01";
        }
    }

}