using System;
using System.Collections.Specialized;
using System.Web;

public partial class AuthorLogin_QQWeb : FirstPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        NameValueCollection get = HttpUtility.ParseQueryString(Request.QueryString.ToString());
        string app_openid = get["app_openid"];
        string app_openkey = get["app_openkey"];
        
        //此处请替换真实的AppID和AppSecret
        QPlusOpen qplus = new QPlusOpen("400014753", "BUsgDNBXv9t7ZWer", "2052");

        string jsonString = qplus.GetUserInfo(app_openid, app_openkey, Request);
        
        QQJsonClass qq = JsonHelper.JsonDeserialize<QQJsonClass>(jsonString);
        
        string oId = app_openid;
        string aToken = "";
        string userNickName = HttpUtility.UrlEncode(qq.info.nick);
        string userImage = HttpUtility.UrlEncode(qq.info.face);

        //this.Label1.Text = userNickName+","+userImage;
        Response.Redirect("OAuth.aspx?u=qw&openId=" + oId + "&accessToken=" + aToken + "&name=" + userNickName + "&image=" + userImage);
    }


    public class QQInfoClass
    {
        public string face;
        public string gender;
        public string nick;
        public string outh;
    }

    public class QQJsonClass
    {
        public int ret;
        public QQInfoClass info;
    }   
}
 