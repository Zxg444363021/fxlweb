using System;
using System.Data;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Web;

public partial class _Default : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Calendar1.VisibleDate = DateTime.Parse(Session["TodayDate"].ToString());
        this.Calendar1.SelectedDate = DateTime.Parse(Session["TodayDate"].ToString());

        if (!IsPostBack)
        {
            BindGrid();
        }
    }

    protected void BindGrid()
    {
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

        string today = Session["TodayDate"].ToString();
        int userId = Int32.Parse(Session["UserID"].ToString());

        //图表点击事件
        double priceMax = 0;
        DataTable dd = ItemAccess.GetItemDateTopList(today, userId, "chart", out priceMax);
        this.hidChartData.Value = ItemHelper.GetChartData(dd, "ItemBuyDate");

        #region 每日消费代码
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
        DataTable jiehuan = ItemAccess.GetItemListJieHuanYear(today, userId, out jiechuPrice, out huanruPrice, out jieruPrice, out huanchuPrice);
        this.Label5.Text = jiechuPrice.ToString("0.##");
        this.Label6.Text = huanruPrice.ToString("0.##");
        this.Label7.Text = jieruPrice.ToString("0.##");
        this.Label8.Text = huanchuPrice.ToString("0.##");

        this.Label9.Text = (jiechuPrice - huanruPrice).ToString("0.##");
        this.Label10.Text = (jieruPrice - huanchuPrice).ToString("0.##");
        #endregion

        //首页功能链接
        string userFunction = "";
        if(Session["UserFunction"] != null) 
        {
            userFunction = Session["UserFunction"].ToString();
        }
        this.Label13.Text = UserAccess.GetUserFunctionText(userFunction);

        //钱包列表
        this.CardList.DataSource = CardAccess.GetCardList(userId);
        this.CardList.DataTextField = "CardName";
        this.CardList.DataValueField = "CardID";
        this.CardList.DataBind();
        if (Request.Cookies["CardID"] != null)
        {
            string cardId = Request.Cookies["CardID"].Value;
            this.CardList.SelectedValue = cardId;
        }
        CardList_SelectionChanged(this.CardList, null);
    }

    //钱包更改
    protected void CardList_SelectionChanged(object sender, EventArgs e)
    {
        int userId = Int32.Parse(Session["UserID"].ToString());
        int cardId = Int32.Parse(this.CardList.SelectedValue);

        Response.Cookies["CardID"].Value = cardId.ToString();
        Response.Cookies["CardID"].Expires = DateTime.MaxValue; 

        CardEntity card = CardAccess.GetCardByCardId(cardId, userId);
        this.Label14.Text = "￥ " + card.CardMoney.ToString("0.0##");
    }

    //选择日期
    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        this.Calendar1.VisibleDate = this.Calendar1.SelectedDate;
        Session["TodayDate"] = this.Calendar1.SelectedDate.ToString("yyyy-MM-dd");
        Response.Redirect("Default.aspx");
    }

    //选择月份
    protected void Calendar1_VisibleMonthChanged(object sender, MonthChangedEventArgs e)
    {
        this.Calendar1.SelectedDate = new DateTime(e.NewDate.Year, e.NewDate.Month, e.PreviousDate.Day);
        Session["TodayDate"] = this.Calendar1.SelectedDate.ToString("yyyy-MM-dd");
        Response.Redirect("Default.aspx");
    }

}