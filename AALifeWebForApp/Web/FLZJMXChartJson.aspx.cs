﻿using System;
using System.Text;
using System.Data;

public partial class FLZJMXChartJson : BasePage
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
        int catTypeId = Int32.Parse(Request.QueryString["catTypeId"]);
        string today = Session["TodayDate"].ToString();
        int userId = Int32.Parse(Session["UserID"].ToString());
        double priceMax = 0;
        DataTable dt = ItemAccess.GetFenLeiZongJiMingXiList(catTypeId, today, userId, out priceMax);

        string max = "1";
        string max2 = "1";
        string step = "1";
        string step2 = "1";
        string itemName = "";
        string itemPrice = "";
        string countNum = "";

        if (dt.Rows.Count > 0)
        {
            max = Math.Ceiling(priceMax).ToString();
            max2 = dt.Rows[0]["CountNum"].ToString();
            step = Math.Floor(Double.Parse(max) / 10).ToString();
            step2 = Math.Floor(Double.Parse(max2) / 10).ToString();

            int i = 0;
            foreach (DataRow dr in dt.Rows)
            {
                if (i == 15) break;
                string dot = (i < 15-1 && i < dt.Rows.Count - 1 ? "," : "");
                itemName += "{\"text\":\"" + dr["ItemName"].ToString() + "\",\"rotate\":90}" + dot;
                itemPrice += dr["ItemPrice"].ToString() + dot;
                countNum += dr["CountNum"].ToString() + dot;
                i++;
            }
        }

        Response.Write(GetChartJsonString(itemName, itemPrice, countNum, max, step, max2, step2));
        Response.End();
    }

    protected string GetChartJsonString(string itemName, string itemPrice, string countNum, string max, string step, string max2, string step2)
    {
        StringBuilder items = new StringBuilder(); 
        items.Append("{\"title\":{\"text\":\"消费分类明细\",\"style\":\"font-size:14px;font-family:Microsoft YaHei;text-align:center;\"},");
        items.Append("\"x_axis\":{\"colour\":\"#909090\",\"3d\":5,\"labels\":{\"size\":12,\"labels\":[" + itemName + "]}},");
        items.Append("\"y_axis\":{\"steps\":" + step + ",\"max\":" + max + "},\"y_axis_right\":{\"grid-colour\":\"#000000\",\"steps\":" + step2 + ",\"max\":" + max2 + "},");
        items.Append("\"bg_colour\":\"#ffffff\",\"elements\":[");
        items.Append("{\"type\":\"bar_3d\",\"tip\":\"￥#val# 元<br>#x_label#\",\"values\":[" + itemPrice + "],\"on-click\":\"chart_click\",\"colour\":\"#ff8800\"},");
        items.Append("{\"type\":\"line\",\"values\":[" + countNum + "],\"dot-style\":{\"type\":\"solid-dot\",\"on-click\":\"chart_click\",\"tip\":\"#val# 次<br>#x_label#\",\"dot-size\":5},\"colour\":\"#000000\",\"axis\":\"right\"}]}");

        return items.ToString();
    }
}