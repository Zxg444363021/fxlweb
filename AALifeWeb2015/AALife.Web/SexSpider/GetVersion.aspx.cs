using System;

public partial class SexSpider_GetVersion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        String result = "{ \"version\":\"261\" }";
        
        Response.Write(result);
        Response.End();
    }
}