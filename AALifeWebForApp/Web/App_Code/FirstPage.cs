using System.Web;

public class FirstPage : System.Web.UI.Page
{
    public FirstPage()
    {
        HttpContext.Current.Response.AddHeader("P3P", "CP= CURa ADMa DEVa PSAo PSDo OUR BUSUNI PUR INT DEM STA PRE COM NAV OTC NOI DSP COR ");
    }
}