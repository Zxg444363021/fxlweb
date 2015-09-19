using System;
using System.Text;
using System.Data;

public partial class FLZJChartJson : BasePage
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
        string date = Session["TodayDate"].ToString();
        int userId = Int32.Parse(Session["UserID"].ToString());
        DataTable dt = ItemAccess.GetFenLeiZongJiList(date, userId);

        string value = "";

        if (dt.Rows.Count > 0 && Double.Parse(dt.Rows[0]["ItemPriceTotal"].ToString()) > 0)
        {
            foreach (DataRow dr in dt.Rows)
            {
                if (Double.Parse(dr["ItemPriceTotal"].ToString()) > 0)
                {
                    value += "{\"value\":" + dr["ItemPriceTotal"].ToString() + ",\"label\":\"" + dr["CategoryTypeName"].ToString() + "\",\"text\":\"" + dr["CategoryTypeName"].ToString() + "\"},";
                }
            }

            value = value.Remove(value.Length - 1);
        }
        else
        {
            value = "{\"value\":100,\"label\":\"空记录\",\"text\":\"空记录\"}";
        }

        Response.Write(GetChartJsonString(value));
        Response.End();
    }

    protected string GetChartJsonString(string value)
    {
        StringBuilder items = new StringBuilder();
        items.Append("{\"title\":{\"text\":\"消费分类排行\",\"style\":\"font-size:14px;font-family:Microsoft YaHei;text-align:center;\"},");
        items.Append("\"bg_colour\":\"#ffffff\",\"elements\":[");
        items.Append("{\"type\":\"pie\",\"tip\":\"￥#val#<br>#label# #percent#\",\"values\":[" + value + "],\"on-click\":\"chart_click\",\"start-angle\":35,\"animate\":[{\"type\":\"fade\"},{\"type\":\"bounce\",\"distance\":4}],\"gradient-fill\":true,\"alpha\":0.5,");
        items.Append("\"colours\":[\"#ff0000\",\"#00ff00\",\"#0000ff\",\"#ff9900\",\"#ff00ff\",\"#FFFF00\",\"#6699FF\",\"#339933\",\"#00ff00\"]}]}");
        
        return items.ToString();
    }
}