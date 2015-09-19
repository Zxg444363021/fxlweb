using System;

public partial class AALifeWeb_SyncUserEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int userId = Int32.Parse(Request.Form["userid"].ToString());
        string userName = Request.Form["username"].ToString();
        string userPassword = Request.Form["userpass"].ToString();
        string userNickName = Request.Form["nickname"].ToString();
        string userEmail = Request.Form["useremail"].ToString();
        string userImage = Request.Form["userimage"].ToString();
        string userFrom = Request.Form["userfrom"].ToString();
        string userWorkDay = Request.Form["userworkday"].ToString();
        string categoryRate = Request.Form["categoryrate"] ?? "";

        if (userFrom.Length > 5)
        {
            userFrom = userFrom.Replace("_", "");
            userFrom = userFrom.Insert(5, "_");
        }

        UserEntity user = UserAccess.GetUserById(userId);
        user.UserName = userName;
        user.UserPassword = userPassword;
        user.UserNickName = userNickName;
        user.UserImage = userImage;
        user.UserEmail = userEmail;
        user.UserFrom = userFrom;
        user.UserWorkDay = userWorkDay;
        if (categoryRate != "") user.CategoryRate = Double.Parse(categoryRate);
                
        string result = "{";

        bool login = SyncHelper.SyncCheckUserLogin(userName, userId);
        if (login)
        {
            result += UpdateUserInfo(user);
        }
        else
        {
            bool repeat = UserAccess.CheckUserRepeat(userName);
            if (repeat)
            {
                result += "\"result\":\"2\"";
            }
            else
            {
                result += UpdateUserInfo(user);
            }
        }

        result += "}";

        Response.Write(result);
        Response.End();
    }

    protected string UpdateUserInfo(UserEntity user)
    {
        bool success = UserAccess.UpdateUser(user);
        if (success)
        {
            return "\"result\":\"1\"";
        }
        else
        {
            return "\"result\":\"0\"";
        }
    }

}