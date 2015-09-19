using System;

public partial class AALifeWeb_SyncItemListWebBack : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int itemId = Int32.Parse(Request.Form["itemid"].ToString());
        int itemAppId = Int32.Parse(Request.Form["itemappid"].ToString());

        bool success = SyncHelper.SyncItemListWebBack(itemId, itemAppId);

        string result = "{";
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