using System;
using System.Text;
using System.Data;

public partial class ItemNumDetailChartJson : BasePage
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
        string title = Request.QueryString["title"];
        string itemName = Request.QueryString["itemName"] ?? "";
        string itemType = Request.QueryString["itemType"] ?? "";
        string today = Session["TodayDate"].ToString();
        string catTypeId = "0";
        if (Request.QueryString["catTypeId"] != null && Request.QueryString["catTypeId"] != "")
        {
            catTypeId = Request.QueryString["catTypeId"];
        }
        //比较分析明细进入使用
        if (Request.QueryString["date"] != null && Request.QueryString["date"] != "")
        {
            if (ValidHelper.CheckDate(Request.QueryString["date"]))
            {
                today = Request.QueryString["date"];
            }
        }
        int userId = Int32.Parse(Session["UserID"].ToString());
        double priceMax = 0;
        DataTable dt = ItemAccess.GetItemNumDetailList(itemName, itemType, userId, Int32.Parse(catTypeId), today, "list", out priceMax);

        string max = "1";
        string step = "1";
        string itemNameValue = "";
        string itemPrice = "";

        if (dt.Rows.Count > 0)
        {
            max = Math.Ceiling(priceMax).ToString();
            step = Math.Floor(Double.Parse(max) / 10).ToString();

            int i = 0;
            foreach (DataRow dr in dt.Rows)
            {
                if (i == 15) break;
                string dot = (i < 15 - 1 && i < dt.Rows.Count - 1 ? "," : "");
                itemNameValue += "{\"text\":\"" + DateTime.Parse(dr["ItemBuyDate"].ToString()).ToString("yyyy-MM-dd") + "\",\"rotate\":90}" + dot;
                itemPrice += dr["ItemPrice"].ToString() + dot;
                i++;
            }
        }
        else
        {
            itemNameValue = "{\"text\":\"0\"},{\"text\":\"1\"}";
        }

        Response.Write(GetChartJsonString(itemNameValue, itemPrice, title, max, step));
        Response.End();
    }

    protected string GetChartJsonString(string itemNameValue, string itemPrice, string title, string max, string step)
    {
        StringBuilder items = new StringBuilder();
        items.Append("{\"title\":{\"text\":\"" + title + "\",\"style\":\"font-size:14px;font-family:Microsoft YaHei;text-align:center;\"},");
        items.Append("\"x_axis\":{\"labels\":{\"labels\":[" + itemNameValue + "]}},");
        items.Append("\"y_axis\":{\"steps\":" + step + ", \"min\":0, \"max\":" + max + "},");
        items.Append("\"bg_colour\":\"#ffffff\",\"elements\":[");
        items.Append("{\"type\":\"area\",\"dot-style\":{\"type\":\"solid-dot\",\"dot-size\":4,\"halo-size\":1,\"tip\":\"￥#val# 元<br>#x_label#\",\"on-click\":\"chart_click\"},\"values\":[" + itemPrice + "],\"colour\":\"#0000ff\",\"fill-alpha\":0.3,\"fill\":\"#0000ff\"}]}");

        return items.ToString();
    }
}