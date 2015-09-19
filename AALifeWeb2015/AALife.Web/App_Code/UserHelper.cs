using AALife.BLL;
using AALife.Model;
using NS_OpenApiV3;
using NS_SnsNetWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// UserHelper 的摘要说明
/// </summary>
public class UserHelper
{
	public UserHelper()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}

    //保存用户Session
    public static void SaveSession(UserInfo user)
    {
        HttpContext.Current.Session["UserID"] = user.UserID;
        HttpContext.Current.Session["UserName"] = user.UserName;
        HttpContext.Current.Session["UserNickName"] = user.UserNickName;
        HttpContext.Current.Session["UserTheme"] = user.UserTheme;
        HttpContext.Current.Session["UserLevel"] = user.UserLevel.ToString();
        HttpContext.Current.Session["UserFrom"] = user.UserFrom;
        HttpContext.Current.Session["UserWorkDay"] = user.UserWorkDay;
        HttpContext.Current.Session["UserFunction"] = user.UserFunction;
        HttpContext.Current.Session["CategoryRate"] = user.CategoryRate;
        HttpContext.Current.Session["IsUpdate"] = user.IsUpdate;
    }

    //取用户功能设置链接
    public static string GetUserFunctionText(string str)
    {
        string result = "<p><img src='/Images/Others/ico_meet.gif' border='0' alt='' /> 常用功能：</p>";

        if (str != "")
        {
            string[] arr = str.Split(',');

            for (int i = 0; i < arr.Length; i++)
            {
                switch (arr[i])
                {
                    case "1":
                        result += "<a href='FenLeiZongJi.aspx'>消费分类排行</a>";
                        break;
                    case "2":
                        result += "<a href='ItemNumTop.aspx'>消费次数排行</a>";
                        break;
                    case "3":
                        result += "<a href='ItemPriceTop.aspx'>消费单价排行</a>";
                        break;
                    case "4":
                        result += "<a href='ItemDateTop.aspx'>消费日期排行</a>";
                        break;
                    case "5":
                        result += "<a href='QuJianTongJi.aspx'>消费区间统计</a>";
                        break;
                    case "6":
                        result += "<a href='TuiJianFenXi.aspx'>消费推荐统计</a>";
                        break;
                    case "7":
                        result += "<a href='BiJiaoFenXi.aspx'>消费分析比较</a>";
                        break;
                    case "8":
                        result += "<a href='JianGeFenXi.aspx'>消费间隔分析</a>";
                        break;
                    case "9":
                        result += "<a href='TianShuFenXi.aspx'>消费天数分析</a>";
                        break;
                    case "10":
                        result += "<a href='JiaGeFenXi.aspx'>消费价格分析</a>";
                        break;
                    case "11":
                        result += "<a href='JieHuanFenXi.aspx'>收支借还分析</a>";
                        break;
                    case "12":
                        result += "<a href='QuWeiTongJi.aspx'>趣味统计分析</a>";
                        break;
                    case "13":
                        result += "<a href='UserAdmin.aspx'>用户资料</a>";
                        break;
                    case "14":
                        result += "<a href='UserBoundAdmin.aspx'>用户绑定</a>";
                        break;
                    case "15":
                        result += "<a href='UserCategoryAdmin.aspx'>类别管理</a>";
                        break;
                    case "16":
                        result += "<a href='UserDataAdmin.aspx'>数据管理</a>";
                        break;
                    case "17":
                        result += "<a href='UserFunctionSetting.aspx'>功能设置</a>";
                        break;
                    case "18":
                        result += "<a href='SearchItem.aspx'>消费搜索</a>";
                        break;
                    case "19":
                        result += "<a href='UserLogout.aspx'>用户退出</a>";
                        break;
                    case "20":
                        result += "<a href='UserZhuanTi.aspx'>用户专题</a>";
                        break;
                    case "21":
                        result += "<a href='Helper.aspx'>网站说明</a>";
                        break;
                    case "22":
                        result += "<a href='UserCardAdmin.aspx'>钱包管理</a>";
                        break;
                }
            }

            result += "<a href='UserFunctionSetting.aspx' class='linkedit'>更改</a>";
        }
        else
        {
            result += "<a href='UserFunctionSetting.aspx'>未设置</a>";
        }

        return result;
    }

    public static RstArray GetUserInfo(OpenApiV3 sdk, string openid, string openkey, string pf)
    {
        Dictionary<string, string> param = new Dictionary<string, string>();
        param.Add("openid", openid);
        param.Add("openkey", openkey);
        param.Add("pf", pf);
        //param.Add("userip", "127.0.0.1");

        string script_name = "/v3/user/get_info";
        return sdk.Api(script_name, param);
    }

    public static string GetUserName(string from)
    {
        UserTableBLL bll = new UserTableBLL();
        UserInfo user = new UserInfo();

        string userName = "";
        do
        {
            userName = from + Utility.GetRandomNumber(10000, 99999);
            user = bll.GetUserByUserName(userName);
        } while (user.UserID > 0);

        return userName;
    }

    public static int JoinDay(DateTime date)
    {
        int day = 0;
        day = ((TimeSpan)(DateTime.Now - date)).Days;

        return day + 1;
    }

}