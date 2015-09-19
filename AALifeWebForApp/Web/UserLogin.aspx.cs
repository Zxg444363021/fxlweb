using System;
using System.Data;

public partial class UserLogin : FirstPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.Cookies["UserCookie"] != null)
            {
                this.UserName.Text = Request.Cookies["UserCookie"].Value; 
            }
        }
    }

    protected void SubmitButtom_Click(object sender, EventArgs e)
    {
        string userName = this.UserName.Text.Trim();
        string userPassword = this.UserPassword.Text.Trim();

        if (userName == "")
        {
            Utility.Alert(this, "用户名未填写！");
            return;
        }

        if (userPassword == "")
        {
            Utility.Alert(this, "密码未填写！");
            return;
        }

        //保留用户名Cookie
        Response.Cookies["UserCookie"].Value = userName;
        Response.Cookies["UserCookie"].Expires = DateTime.MaxValue;

        int userId = 0;
        bool success = UserAccess.CheckUserLogin(userName, userPassword, out userId);
        if (success)
        {
            Session["TodayDate"] = DateTime.Now.ToString("yyyy-MM-dd");

            UserEntity user = UserAccess.GetUserById(userId);
            Session["UserID"] = user.UserID;
            Session["UserName"] = user.UserName;
            Session["UserNickName"] = user.UserNickName;
            Session["UserTheme"] = user.UserTheme;
            Session["UserLevel"] = user.UserLevel.ToString();
            Session["UserFrom"] = user.UserFrom;
            Session["UserWorkDay"] = user.UserWorkDay;
            Session["UserFunction"] = user.UserFunction;
            Session["CategoryRate"] = user.CategoryRate;

            Response.Cookies["ThemeCookie"].Value = user.UserTheme;
            Response.Cookies["ThemeCookie"].Expires = DateTime.MaxValue;
            
            string url = Request.QueryString["url"];
            if (url == "" || url == null)
            {
                url = "Default.aspx";
            }

            Response.Redirect(url);
        }
        else
        {
            Utility.Alert(this, "登录失败！");
        }
    }
}
