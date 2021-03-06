﻿using System;
using System.Text;
using System.Data;

public partial class JianGeFXChartJson : BasePage
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
        int userId = Int32.Parse(Session["UserID"].ToString());
        int notBuyMax = 0;
        int pageNumber = 1;
        int howManyItems = 0;
        DataTable dt = ItemAccess.GetJianGeFenXiList(userId, pageNumber, out howManyItems, out notBuyMax);

        string max = "1";
        string step = "1";
        string itemName = "";
        string notBuy = "";

        if (dt.Rows.Count > 0)
        {
            max = notBuyMax.ToString();
            step = Math.Floor(Double.Parse(max) / 10).ToString();
            
            int i = 0;
            foreach (DataRow dr in dt.Rows)
            {
                if (i == 15) break;
                string dot = (i < 15 - 1 && i < dt.Rows.Count - 1 ? "," : "");
                itemName += "{\"text\":\"" + dr["ItemName"].ToString() + "\",\"rotate\":90}" + dot;
                notBuy += dr["NotBuy"].ToString() + dot;
                i++;
            }
        }

        Response.Write(GetChartJsonString(itemName, notBuy, max, step));
        Response.End();
    }

    protected string GetChartJsonString(string itemName, string notBuy, string max, string step)
    {
        StringBuilder items = new StringBuilder();
        items.Append("{\"title\":{\"text\":\"消费间隔分析\",\"style\":\"font-size:14px;font-family:Microsoft YaHei;text-align:center;\"},");
        items.Append("\"x_axis\":{\"labels\":{\"size\":12,\"labels\":[" + itemName + "]}},");
        items.Append("\"y_axis\":{\"steps\":" + step + ",\"max\":" + max + "},");
        items.Append("\"bg_colour\":\"#ffffff\",\"elements\":[");
        items.Append("{\"type\":\"bar_dome\",\"tip\":\"#val# 天<br>#x_label#\",\"values\":[" + notBuy + "],\"on-click\":\"chart_click\",\"colour\":\"#ff0000\"}]}");

        return items.ToString();
    }
}