using System;
using System.Text;
using System.Data;

public partial class ItemPriceChartJson : BasePage
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
        DataTable dt = ItemAccess.GetItemPriceTopList(today, userId);

        string max = "1";
        string step = "1";
        string itemName = "";
        string itemPrice = "";

        if (dt.Rows.Count > 0)
        {
            max = Math.Ceiling(Double.Parse(dt.Rows[0]["ItemPrice"].ToString())).ToString();
            step = Math.Floor(Double.Parse(max) / 10).ToString();

            int i = 0;
            foreach (DataRow dr in dt.Rows)
            {
                if (i == 15) break;
                string dot = (i < 15 - 1 && i < dt.Rows.Count - 1 ? "," : "");
                itemName += "{\"text\":\"" + dr["ItemName"].ToString() + "\",\"rotate\":90}" + dot;
                itemPrice += dr["ItemPrice"].ToString() + dot;
                i++;
            }

            
        }

        Response.Write(GetChartJsonString(itemName, itemPrice, max, step));
        Response.End();
    }

    protected string GetChartJsonString(string itemName, string itemPrice, string max, string step)
    {
        StringBuilder items = new StringBuilder();
        items.Append("{\"title\":{\"text\":\"消费单价排行\",\"style\":\"font-size:14px;font-family:Microsoft YaHei;text-align:center;\"},");
        items.Append("\"x_axis\":{\"labels\":{\"size\":12,\"labels\":[" + itemName + "]}},");
        items.Append("\"y_axis\":{\"steps\":" + step + ",\"max\":" + max + "},");
        items.Append("\"bg_colour\":\"#ffffff\",\"elements\":[");
        items.Append("{\"type\":\"bar_cylinder\",\"tip\":\"￥#val# 元<br>#x_label#\",\"values\":[" + itemPrice + "],\"on-click\":\"chart_click\",\"colour\":\"#ff0000\"}]}");

        return items.ToString();
    }
}