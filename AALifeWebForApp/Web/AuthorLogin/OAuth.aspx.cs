using System;
using System.Data;
using System.Web;
using System.Web.UI.HtmlControls;

public partial class AuthorLogin_OAuth : FirstPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
        }
    }

    protected void BindData()
    {
        string u = Request.QueryString["u"];

        UserEntity user = new UserEntity();
        user.UserName = u + Utility.GetRandomNumber(10000, 99999);
        user.UserPassword = "aalife";
        user.UserNickName = Request.QueryString["name"] ?? "";
        user.UserImage = Request.QueryString["image"] == "" ? "none.gif" : Request.QueryString["image"];
        user.UserEmail = "";
        user.UserPhone = "";
        user.UserTheme = "main";
        user.UserFrom = u;
        user.UserCity = "";

        OAuthEntity oAuth = new OAuthEntity();
        oAuth.OpenID = Request.QueryString["openId"];
        oAuth.AccessToken = Request.QueryString["accessToken"];
        oAuth.User = user;
        oAuth.OAuthFrom = u;
        oAuth.OAuthBound = 0;
        
        bool success = OAuthAccess.CheckOAuthLogin(oAuth.OpenID);
        if (!success)
        {
            success = OAuthAccess.InsertOAuth(oAuth);
            if (!success)
            {
                Response.Write("自动登录错误！");
                Response.End();
            }            
        }

        DataTable dt = OAuthAccess.GetOAuthByOpenId(oAuth.OpenID);
        int userId = Int32.Parse(dt.Rows[0]["UserID"].ToString());

        UserLogin(userId);

        Response.Redirect("/Default.aspx");
    }

    protected void UserLogin(int userId)
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
    }
}