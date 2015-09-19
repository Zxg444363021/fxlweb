using System;
using System.Web;
//泛型
using System.Collections.Generic;
//sdk自定义类
using NS_OpenApiV3;
using NS_SnsNetWork;

public partial class AuthorLogin_PengYou : FirstPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int appid = 100651351;
        string appkey = "e358f5d6c4c5cd822419911c13a18e73";
        string server_name = "openapi.tencentyun.com";//"119.147.19.43";//
        string openid = Request.QueryString["openid"];
        string openkey = Request.QueryString["openkey"];
        string pf = Request.QueryString["pf"];

        OpenApiV3 sdk = new OpenApiV3(appid, appkey);
        sdk.SetServerName(server_name);
        RstArray result = new RstArray();

        //get_info接口
        result = GetUserInfo(sdk, openid, openkey, pf);

        //HttpContext.Current.Response.Write("<br>ret = " + result.Ret + "<br>msg = " + result.Msg);

        string jsonString = result.Msg;
        QQInfoClass qq = JsonHelper.JsonDeserialize<QQInfoClass>(jsonString);

        string u = "py";
        string oId = openid;
        string aToken = openkey;
        string userNickName = HttpUtility.UrlEncode(qq.nickname);
        string userImage = HttpUtility.UrlEncode(qq.figureurl);

        Response.Redirect("OAuth.aspx?u=" + u + "&openId=" + oId + "&accessToken=" + aToken + "&name=" + userNickName + "&image=" + userImage);
    }
    
    RstArray GetUserInfo(OpenApiV3 sdk, string openid, string openkey, string pf)
    {
        Dictionary<string, string> param = new Dictionary<string, string>();
        param.Add("openid", openid);
        param.Add("openkey", openkey);
        param.Add("pf", pf);
        //param.Add("userip", "127.0.0.1");

        string script_name = "/v3/user/get_info";
        return sdk.Api(script_name, param);
    }
    
    public class QQInfoClass
    {
        public int ret;
        public int is_lost;
        public string nickname;
        public string gender;
        public string country;
        public string province;
        public string city;
        public string figureurl;
        public int is_yellow_vip;
        public int is_yellow_year_vip;
        public int yellow_vip_level;
        public int is_yellow_high_vip;
    }
}