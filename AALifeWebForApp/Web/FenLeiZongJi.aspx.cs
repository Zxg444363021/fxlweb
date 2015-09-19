using System;
using System.Data;

public partial class FenLeiZongJi : BasePage
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
        DataTable dt = ItemAccess.GetFenLeiZongJiList(today, userId);
        List.DataSource = dt;
        List.DataBind(); 
        
        double priceTotal = 0;
        foreach (DataRow dr in dt.Rows)
        {
            priceTotal += Double.Parse(dr["ItemPriceTotal"].ToString());
        }

        this.Label2.Text = priceTotal.ToString("0.0##");

        this.hidChartData.Value = ItemHelper.GetChartData(dt, "PageUrl");
    }

    public string GetCategoryDen(double catPrice, double price) {
        double catRate = Double.Parse(Session["CategoryRate"].ToString());
        double[] denArr = GetDenArray(catPrice, catRate);
        string result = "";
        if (price > 0 && catPrice > 0)
        {
            if (price >= denArr[0] && price < denArr[1])
            {
                result = "<img src='/Images/Others/Bullet-Yellow.png' alt='临界' title='临界 " + denArr[0] + " ~ " + denArr[1] + "' />";
            }
            else if (price > denArr[1])
            {
                result = "<img src='/Images/Others/Bullet-Red.png' alt='超出' title='超出 " + denArr[0] + " ~ " + denArr[1] + "' />";
            }
            else
            {
                result = "<img src='/Images/Others/Bullet-Blue.png' alt='正常' title='正常 " + denArr[0] + " ~ " + denArr[1] + "' />";
            }
        }
        else
        {
            result = "<img src='/Images/Others/Bullet-White.png' alt='空值' title='空值' />";
        }

        return result;
    }

    protected double[] GetDenArray(double catPrice, double catRate)
    {
        double num = catPrice - catPrice * (catRate / 100);
        double[] result = new double[2];
        result[0] = catPrice - num;
        result[1] = catPrice + num;

        return result;
    }

}