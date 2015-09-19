using System;
using System.Web;

public partial class AALifeWeb_SyncNewUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string userName = Request.Form["username"].ToString();
        string userPassword = Request.Form["userpass"].ToString();
        string userNickName = Request.Form["usernickname"].ToString();
        string userImage = "user.gif";
        string userEmail = Request.Form["useremail"].ToString();
        string userFrom = Request.Form["userfrom"] ?? "sjapp";
        string userWorkDay = Request.Form["userworkday"].ToString();
        string userMoney = Request.Form["usermoney"] ?? "0";
        string categoryRate = Request.Form["categoryrate"] ?? "90";

        if (userFrom.Length > 5)
        {
            userFrom = userFrom.Replace("_", "");
            userFrom = userFrom.Insert(5, "_");
        }

        UserEntity user = new UserEntity();
        user.UserName = userName;
        user.UserPassword = userPassword;
        user.UserNickName = userNickName;
        user.UserImage = userImage;
        user.UserPhone = "";
        user.UserEmail = userEmail;
        user.UserTheme = "main";
        user.UserFrom = userFrom;
        user.UserWorkDay = userWorkDay;
        user.UserMoney = Double.Parse(userMoney);
        user.CategoryRate = Double.Parse(categoryRate);
                
        string result = "{";

        bool repeat = UserAccess.CheckUserRepeat(userName);
        if (repeat)
        {
            result += "\"result\":\"2\"";
        }
        else
        {
            int userId = 0;
            bool success = UserAccess.InsertUser(user, out userId);
            if (success)
            {
                result += "\"result\":\"1\"";
            }
            else
            {
                result += "\"result\":\"0\"";
            }
        }

        result += "}";

        Response.Write(result);
        Response.End();
    }
}