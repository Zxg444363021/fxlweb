using System;
using System.Data;

public partial class AALifeWeb_SyncGetCardWeb : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int userId = Int32.Parse(Request.Form["userid"].ToString());

        DataTable dt = SyncHelper.SyncGetCardWeb(userId);

        string result = "{";
        if (dt.Rows.Count > 0)
        {
            result += "\"cardlist\":[";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                result += "{\"cardid\":\"" + dt.Rows[i]["CardID"].ToString() + "\",";
                result += "\"cardname\":\"" + dt.Rows[i]["CardName"].ToString() + "\",";
                result += "\"cardmoney\":\"" + dt.Rows[i]["CardMoney"].ToString() + "\",";
                result += "\"cardlive\":\"" + dt.Rows[i]["CardLive"].ToString() + "\"},";
            }
            result = result.Substring(0, result.Length - 1);
            result += "]";
        }
        else
        {
            result += "\"cardlist\":[]";
        }
        result += "}";

        Response.Write(result);
        Response.End();
    }
}