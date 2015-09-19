using System;
using System.Data;

public partial class AALifeWeb_SyncCheckWebData : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int userId = Int32.Parse(Request.Form["userid"].ToString());

        string result = "{";

        DataTable dt = SyncHelper.SyncGetItemListWeb(userId);
        if (dt.Rows.Count == 0)
        {
            dt = SyncHelper.SyncGetDeleteListWeb(userId);
        }
        if (dt.Rows.Count == 0)
        {
            dt = SyncHelper.SyncGetCategoryWeb(userId);
        }
        if (dt.Rows.Count == 0)
        {
            dt = SyncHelper.SyncGetZhuanTiWeb(userId);
        }
        if (dt.Rows.Count == 0)
        {
            dt = SyncHelper.SyncGetCardWeb(userId);
        }
        if (dt.Rows.Count == 0)
        {
            dt = SyncHelper.SyncGetUserInfoWeb(userId);
        }
        
        if (dt.Rows.Count > 0)
        {
            result += "\"result\":\"ok\"";
        }
        else
        {
            result += "\"result\":\"error\"";
        } 

        result += "}";

        Response.Write(result);
        Response.End();
    }
}