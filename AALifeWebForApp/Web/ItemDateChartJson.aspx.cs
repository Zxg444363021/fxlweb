using System;
using System.Text;
using System.Data;

public partial class ItemDateChartJson : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PopulateControls();
        }
    }

    protected void PopulateControls()
    {
        string today = Session["TodayDate"].ToString();
        int userId = Int32.Parse(Session["UserID"].ToString());
        string orderBy = Request.QueryString["orderBy"] ?? "chart";
        double priceMax = 0;
        DataTable dt = ItemAccess.GetItemDateTopList(today, userId, orderBy, out priceMax);

        string max = "1";
        string step = "1";
        string itemBuyDate = "";
        string shouruPrice = "";
        string zhichuPrice = "";

        string tip = (orderBy == "list" ? "#x_label#" : DateTime.Parse(today).ToString("yyyy-MM-") + "#x_label#");

        if (dt.Rows.Count > 0)
        {
            max = Math.Floor(priceMax).ToString();
            step = Math.Floor(Double.Parse(max) / 10).ToString();

            int i = 0;
            foreach (DataRow dr in dt.Rows)
            {
                string dot = (i < dt.Rows.Count - 1 ? "," : "");
                string date = (orderBy == "list" ? DateTime.Parse(dr["ItemBuyDate"].ToString()).ToString("yyyy-MM-dd") : DateTime.Parse(dr["ItemBuyDate"].ToString()).ToString("dd"));
                int rotate = (orderBy == "list" ? 90 : 0);
                itemBuyDate += "{\"text\":\"" + date + "\",\"rotate\":" + rotate + "}" + dot;
                shouruPrice += dr["ShouRuPrice"].ToString() + dot;
                zhichuPrice += dr["ZhiChuPrice"].ToString() + dot;
                i++;
            }
        }
        else
        {
            itemBuyDate = "{\"text\":\"0\"},{\"text\":\"1\"}";
        }

        Response.Write(GetChartJsonString(itemBuyDate, shouruPrice, zhichuPrice, max, step, tip));
        Response.End();
    }

    protected string GetChartJsonString(string itemBuyDate, string shouruPrice, string zhichuPrice, string max, string step, string tip)
    {
        StringBuilder items = new StringBuilder();
        items.Append("{\"title\":{\"text\":\"消费日期排行\",\"style\":\"font-size:14px;font-family:Microsoft YaHei;text-align:center;\"},");
        items.Append("\"x_axis\":{\"labels\":{\"labels\":[" + itemBuyDate + "]}},");
        items.Append("\"y_axis\":{\"steps\":" + step + ",\"min\":0,\"max\":" + max + "},");
        items.Append("\"bg_colour\":\"#ffffff\",\"elements\":[");
        items.Append("{\"type\":\"area\",\"dot-style\":{\"on-click\":\"chart_click\",\"type\":\"solid-dot\",\"dot-size\":4,\"halo-size\":1,\"tip\":\"￥#val# 元<br>" + tip + "\"},\"values\":[" + shouruPrice + "],\"colour\":\"#ff0000\",\"fill-alpha\":0.3,\"fill\":\"#ff0000\"},");
        items.Append("{\"type\":\"area\",\"dot-style\":{\"on-click\":\"chart_click\",\"type\":\"solid-dot\",\"dot-size\":4,\"halo-size\":1,\"tip\":\"￥#val# 元<br>" + tip + "\"},\"values\":[" + zhichuPrice + "],\"colour\":\"#00aa00\",\"fill-alpha\":0.3,\"fill\":\"#00aa00\"}]}");

        return items.ToString();
    }
}