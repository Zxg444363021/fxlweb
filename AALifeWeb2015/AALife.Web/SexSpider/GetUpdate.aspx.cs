using System;

public partial class SexSpider_GetUpdate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        String result = "{ \"update\":\"16\" }";
        
        Response.Write(result);
        Response.End();
    }
}