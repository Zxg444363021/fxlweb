using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
//泛型
using System.Collections.Generic;
//sdk自定义类
using NS_OpenApiV3;
using NS_SnsNetWork;
using NS_SnsSigCheck;
using NS_SnsStat;

/**
	 * OpenAPI V3 SDK 示例代码，普通请求类参考"GetUserInfo"方法，上传文件类参考"AddWeiboPic"方法
	 *
	 * @version 3.0.0
	 * @author open.qq.com
	 * @copyright © 2012, Tencent Corporation. All rights reserved.
	 * @ History:
	 *               3.0.0 | coolinchen | 2013-1-11 11:11:11 | initialization
	 */

public partial class testOpenApiV3 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int appid = 100657839;
        string appkey = "b96b85196a04ff2ef08707f43979db15"; 
        string server_name = "119.147.19.43";
        string openid = "97AEE444260111D8F9D6846C5DE6F481";
        string openkey = "465A2A1A3FE02C9E9CD7AD7A799ED4B4";
        string pf = "qzone";

        OpenApiV3 sdk = new OpenApiV3(appid,appkey);
        sdk.SetServerName (server_name);
        RstArray result = new RstArray();

		//get_info接口
        result = GetUserInfo(sdk, openid, openkey, pf);

		//add_weibo接口
        result = AddWeiboPic(sdk, openid, openkey, pf);
		HttpContext.Current.Response.Write("<br>ret = "+ result.Ret + "<br>msg = " + result.Msg);

    }

    RstArray GetUserInfo(OpenApiV3 sdk, string openid, string openkey, string pf)
    {
        Dictionary<string, string> param = new Dictionary<string, string>();
        param.Add("openid", openid);
        param.Add("openkey", openkey);
        param.Add("pf", pf);
        param.Add("userip","112.90.139.30");

        string script_name = "/v3/user/get_info";
        return sdk.Api(script_name, param);
    }

    RstArray AddWeiboPic(OpenApiV3 sdk, string openid, string openkey, string pf)
    {
        Dictionary<string, string> param = new Dictionary<string, string>();
        param.Add("openid", openid);
        param.Add("openkey", openkey);
        param.Add("pf", "tapp");
        param.Add("userip", "112.90.139.30");
        param.Add("content", "图片描述。。@xxx");

        //filename填写接口所要求的，和文件对应的参数名
        string filename = "pic";
        string filepath = "D:\\picture.jpg";
        string script_name = "/v3/t/add_pic_t";

        return sdk.ApiWithFile(script_name, param,filename, filepath);
    }
     
}
