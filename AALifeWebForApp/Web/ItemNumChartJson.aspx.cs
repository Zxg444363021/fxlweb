using System;
using System.Text;
using System.Data;

public partial class ItemNumChartJson : BasePage
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
        int countMax = 0;
        DataTable dt = ItemAccess.GetItemNumTopList(today, userId, out countMax);

        string max = "1";
        string step = "1";
        string itemName = "";
        string countNum = "";

        if (dt.Rows.Count > 0)
        {
            max = countMax.ToString();
            step = Math.Floor(Double.Parse(max) / 10).ToString();

            int i = 0;
            foreach (DataRow dr in dt.Rows)
            {
                if (i == 15) break;
                string dot = (i < 15-1 && i < dt.Rows.Count - 1 ? "," : "");
                itemName += "{\"text\":\"" + dr["ItemName"].ToString() + "\",\"rotate\":90}" + dot;
                countNum += dr["CountNum"].ToString() + dot;
                i++;
            }

        }

        Response.Write(GetChartJsonString(itemName, countNum, max, step));
        Response.End();
    }

    protected string GetChartJsonString(string itemName, string countNum, string max, string step)
    {
        StringBuilder items = new StringBuilder();
        items.Append("{\"title\":{\"text\":\"消费次数排行\",\"style\":\"font-size:14px;font-family:Microsoft YaHei;text-align:center;\"},");
        items.Append("\"x_axis\":{\"labels\":{\"size\":12,\"labels\":[" + itemName + "]}},");
        items.Append("\"y_axis\":{\"steps\":" + step + ",\"max\":" + max + "},");
        items.Append("\"bg_colour\":\"#ffffff\",\"elements\":[");
        items.Append("{\"type\":\"bar_glass\",\"tip\":\"#val# 次<br>#x_label#\",\"values\":[" + countNum + "],\"on-click\":\"chart_click\",\"colour\":\"#0000ff\"}]}");

        return items.ToString();
    }
}