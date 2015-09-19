using System;
using System.Web.UI.WebControls;

public partial class UserControl_MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void ImageButton_Command(object sender, CommandEventArgs e)
    {
        int userId = 0;
        string theme = e.CommandArgument.ToString();

        Response.Cookies["ThemeCookie"].Value = theme;
        Response.Cookies["ThemeCookie"].Expires = DateTime.MaxValue;

        if (Session["UserID"] != null && Session["UserID"].ToString() != "")
        {
            userId = Int32.Parse(Session["UserID"].ToString());

            UserAccess.UpdateUserTheme(userId, theme);
        }

        Response.Redirect(Request.Url.ToString());
    }
}
