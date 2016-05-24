using System;

public partial class AALifeWeb_GetWebVersion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        String result = "{ \"version\":\"5.6.2\" }";
        
        Response.Write(result);
        Response.End();
    }
}