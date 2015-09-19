using NS_OpenApiV3;
using NS_SnsNetWork;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AuthorLogin_FixQQLogin : FirstPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void GetQQImageButton_Click(object sender, EventArgs e)
    {
        if (this.AppID.Text.Trim() == "" || this.AppKey.Text.Trim() == "" || this.OpenIDBox.Text.Trim() == "" || this.AccessTokenBox.Text.Trim() == "")
        {
            this.ResultLabel.Text = "{ empty. }";
            return;
        }

        int appid = Int32.Parse(this.AppID.Text.Trim());
        string appkey = this.AppKey.Text.Trim();
        string server_name = "openapi.tencentyun.com";//"119.147.19.43";//
        string openid = this.OpenIDBox.Text.Trim();
        string openkey = this.AccessTokenBox.Text.Trim();

        OpenApiV3 sdk = new OpenApiV3(appid, appkey);
        sdk.SetServerName(server_name);
        RstArray result = new RstArray();

        result = GetUserInfo(sdk, openid, openkey, "qzone");
        //Response.Write("<br>ret = " + result.Ret + "<br>msg = " + result.Msg);
        string qqStr = result.Msg;
        QQInfoClass qq = JsonHelper.JsonDeserialize<QQInfoClass>(qqStr);

        string userStr = "";
        DataTable dt = OAuthAccess.GetOAuthByOpenId(openid);
        if (dt.Rows.Count > 0)
        {
            int userId = Int32.Parse(dt.Rows[0]["UserID"].ToString());
            UserEntity user = UserAccess.GetUserById(userId);
            user.UserNickName = qq.nickname;
            user.UserImage = qq.figureurl;
            bool success = UserAccess.UpdateUser(user);
            if (success)
            {
                userStr = "{ " + user.UserImage + " }";
            }
            else
            {
                userStr = "{ error. }";
            }

        }

        this.ResultLabel.Text = userStr + "<br><br>" + qqStr;
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

    class QQInfoClass
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