using System;

public partial class SexSpider_GetSettings : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        String result = "{ \"update\":\"19\",\"version\":\"265\",\"key\":\"sexspider2\" }";
        
        Response.Write(result);
        Response.End();
    }
}