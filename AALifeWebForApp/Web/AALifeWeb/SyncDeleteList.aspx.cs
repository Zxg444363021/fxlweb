using System;

public partial class AALifeWeb_SyncDeleteList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int itemId = Int32.Parse(Request.Form["itemid"].ToString());
        int itemWebId = Int32.Parse(Request.Form["itemwebid"].ToString());
        int userId = Int32.Parse(Request.Form["userid"].ToString());
        
        string result = "{";
        bool success = SyncHelper.SyncDeleteList(itemId, itemWebId, userId);
        if (success)
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