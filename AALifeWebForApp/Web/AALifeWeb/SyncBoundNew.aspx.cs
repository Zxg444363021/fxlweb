using System;
using System.Data;
using System.Text.RegularExpressions;

public partial class AALifeWeb_SyncBoundNew : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string openId = Request.Form["openid"].ToString();
        string accessToken = Request.Form["accesstoken"].ToString();
        string oAuthFrom = Request.Form["oauthfrom"].ToString();
        int userId = Int32.Parse(Request.Form["userid"].ToString());

        OAuthEntity oAuth = new OAuthEntity();
        oAuth.OpenID = openId;
        oAuth.AccessToken = accessToken;
        oAuth.User = UserAccess.GetUserById(userId);
        oAuth.OAuthFrom = oAuthFrom;
        oAuth.OAuthBound = 1;

        string result = "{";

        bool success = false;
        int bound = OAuthAccess.CheckOAuthBoundByOpenId(oAuth.OpenID);
        if (bound == 2)
        {
            success = SyncHelper.SyncInsertOAuth(oAuth);
            if (success)
            {
                result += "\"result\":\"1\"";
            }
            else
            {
                result += "\"result\":\"0\"";
            }
        }
        else if (bound == 0)
        {
            oAuth.OAuthBound = 1;
            success = SyncHelper.SyncUpdateOAuth(oAuth);
            if (success)
            {
                result += "\"result\":\"1\"";
            }
            else
            {
                result += "\"result\":\"0\"";
            }
        }
        else
        {
            result += "\"result\":\"2\"";
        }

        result += "}";

        Response.Write(result);
        Response.End();
    }
}