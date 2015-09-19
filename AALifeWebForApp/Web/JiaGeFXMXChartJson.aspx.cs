using System;
using System.Text;
using System.Data;

public partial class JiaGeFXMXChartJson : BasePage
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
        string itemName = Request.QueryString["itemName"] ?? "";
        string itemType = Request.QueryString["itemType"] ?? "";
        int userId = Int32.Parse(Session["UserID"].ToString());
        double priceMax = 0;
        int pageNumber = 1;
        int howManyItems = 0;
        DataTable dt = ItemAccess.GetJiaGeFenXiMingXiList(itemName, itemType, userId, pageNumber, out howManyItems, out priceMax);
 
        string max = "1";
        string step = "1";
        string itemBuyDate = "";
        string itemPrice = "";

        if (dt.Rows.Count > 0)
        {
            max = Math.Floor(priceMax).ToString();
            step = Math.Floor(Double.Parse(max) / 10).ToString();
            
            int i = 0;
            foreach (DataRow dr in dt.Rows)
            {
                if (i == 15) break;
                string dot = (i < 15 - 1 && i < dt.Rows.Count - 1 ? "," : "");
                itemBuyDate += "{\"text\":\"" + DateTime.Parse(dr["ItemBuyDate"].ToString()).ToString("yyyy-MM-dd") + "\",\"rotate\":90}" + dot;
                itemPrice += dr["ItemPrice"].ToString() + dot;
                i++;
            }
        }

        Response.Write(GetChartJsonString(itemBuyDate, itemPrice, max, step));
        Response.End();
    }

    protected string GetChartJsonString(string itemBuyDate, string itemPrice, string max, string step)
    {
        StringBuilder items = new StringBuilder();
        items.Append("{\"title\":{\"text\":\"消费价格明细\",\"style\":\"font-size:14px;font-family:Microsoft YaHei;text-align:center;\"},");
        items.Append("\"x_axis\":{\"labels\":{\"labels\":[" + itemBuyDate + "]}},");
        items.Append("\"y_axis\":{\"steps\":" + step + ", \"min\":0, \"max\":" + max + "},");
        items.Append("\"bg_colour\":\"#ffffff\",\"elements\":[");
        items.Append("{\"type\":\"area\",\"dot-style\":{\"type\":\"solid-dot\",\"tip\":\"￥#val# 元<br>#x_label#\",\"on-click\":\"chart_click\",\"dot-size\":4,\"halo-size\":1},\"values\":[" + itemPrice + "],\"colour\":\"#0000ff\",\"fill-alpha\":0.3,\"fill\":\"#0000ff\"}]}");

        return items.ToString();
    }
}