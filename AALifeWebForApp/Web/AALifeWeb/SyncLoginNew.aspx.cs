using System;
using System.Data;
using System.Text.RegularExpressions;

public partial class AALifeWeb_SyncLoginNew : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string userName = Request.Form["username"].ToString();
        string userPassword = Request.Form["userpass"].ToString();
        int type = Int32.Parse(Request.Form["type"].ToString());
        
        string result = "{";

        int userId = 0;
        bool success = UserAccess.CheckUserLogin(userName, userPassword, out userId);
        if (success)
        {
            UserEntity user = UserAccess.GetUserById(userId);

            result += "\"userid\":\"" + userId + "\",";
            result += "\"username\":\"" + user.UserName + "\",";
            result += "\"userpass\":\"" + user.UserPassword + "\",";
            result += "\"usernickname\":\"" + user.UserNickName + "\",";
            result += "\"useremail\":\"" + user.UserEmail + "\",";
            result += "\"userphone\":\"" + user.UserPhone + "\",";
            result += "\"userimage\":\"" + user.UserImage + "\",";
            result += "\"userworkday\":\"" + user.UserWorkDay + "\",";
            result += "\"usermoney\":\"" + user.UserMoney + "\",";
            result += "\"categoryrate\":\"" + user.CategoryRate + "\",";

            DataTable dt = null;
            if (type == 1)
            {
                dt = SyncHelper.SyncGetItemListWebFirst(userId);
            }
            else
            {
                dt = SyncHelper.SyncGetItemListWeb(userId);
            }
            if (dt.Rows.Count > 0)
            {
                result += "\"hassync\":\"1\",";
            }
            else
            {
                result += "\"hassync\":\"0\",";
            }

            bool isBound = SyncHelper.CheckOAuthBound(userId);
            if (!isBound)
            {
                result += "\"userbound\":\"0\"";
            }
            else
            {
                result += "\"userbound\":\"1\"";
            }
        }
        else
        {
            result += "\"userid\":\"0\",";
            result += "\"username\":\"\",";
            result += "\"userpass\":\"\",";
            result += "\"usernickname\":\"\",";
            result += "\"useremail\":\"\",";
            result += "\"userphone\":\"\",";
            result += "\"userimage\":\"\",";
            result += "\"userworkday\":\"\",";
            result += "\"usermoney\":\"0\",";
            result += "\"categoryrate\":\"90\",";
            result += "\"hassync\":\"0\",";
            result += "\"userbound\":\"0\"";
        }

        result += "}";

        Response.Write(result);
        Response.End();
    }
}