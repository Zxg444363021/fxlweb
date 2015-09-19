using System;
using System.Data;
using System.Text.RegularExpressions;

public partial class AALifeWeb_SyncLoginQQNew : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string openId = Request.Form["openid"].ToString();
        string accessToken = Request.Form["accesstoken"].ToString();
        string oAuthFrom = Request.Form["oauthfrom"].ToString();
        string nickName = Request.Form["nickname"].ToString();
        string userImage = Request.Form["userimage"].ToString();
        int type = Int32.Parse(Request.Form["type"].ToString());

        string userFrom = "";
        if (oAuthFrom.Length > 4)
        {
            userFrom = oAuthFrom.Replace("_", "");
            userFrom = userFrom.Insert(4, "_");
            oAuthFrom = userFrom.Substring(0, 4);
        }
        else
        {
            userFrom = oAuthFrom;
        }

        UserEntity user = new UserEntity();
        user.UserName = oAuthFrom + Utility.GetRandomNumber(10000, 99999);
        user.UserPassword = "aalife";
        user.UserNickName = nickName;
        user.UserImage = (userImage=="" ? "none.gif" : userImage);
        user.UserEmail = "";
        user.UserPhone = "";
        user.UserTheme = "main";
        user.UserFrom = userFrom;
        user.UserCity = "";

        OAuthEntity oAuth = new OAuthEntity();
        oAuth.OpenID = openId;
        oAuth.AccessToken = accessToken;
        oAuth.User = user;
        oAuth.OAuthFrom = oAuthFrom;
        oAuth.OAuthBound = 1;

        bool success = OAuthAccess.CheckOAuthLogin(oAuth.OpenID);
        if (!success)
        {
            success = OAuthAccess.InsertOAuth(oAuth);
            if (!success)
            {
                Response.Write("{\"result\":\"userid\":\"0\"}");
                Response.End();
            }
        }

        DataTable odt = OAuthAccess.GetOAuthByOpenId(oAuth.OpenID);
        int userId = Int32.Parse(odt.Rows[0]["UserID"].ToString());
        
        string result = "{";

        if (success)
        {
            user = UserAccess.GetUserById(userId);

            result += "\"userid\":\"" + userId + "\",";
            result += "\"username\":\"" + user.UserName + "\",";
            result += "\"userpass\":\"" + user.UserPassword + "\",";
            result += "\"usernickname\":\"" + user.UserNickName + "\",";
            result += "\"useremail\":\"" + user.UserEmail + "\",";
            result += "\"userphone\":\"" + user.UserPhone + "\",";
            result += "\"userimage\":\"" + user.UserImage + "\",";
            result += "\"userworkday\":\"" + user.UserWorkDay + "\",";
            result += "\"usermoney\":\"" + user.UserMoney + "\",";

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
            
            result += "\"userbound\":\"1\"";
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
            result += "\"categoryrate\":\"0\",";
            result += "\"hassync\":\"0\",";
            result += "\"userbound\":\"0\"";
        }

        result += "}";

        Response.Write(result);
        Response.End();
    }
}