using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

/// <summary>
/// ItemHelper 的摘要说明
/// </summary>
public class ItemHelper
{
	static ItemHelper()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
    }

    //借还价格格式
    public static string JieHuanColor(string str, int type)
    {
        double price = Double.Parse(str);
        if (price == 0)
        {
            return "pricenone";
        }
        else if (price < 0)
        {
            return type == 0 ? "pricered" : "priceblue";
        }
        else
        {
            return type == 0 ? "priceblue" : "pricered";
        }
    }

    //取区间数量
    public static int GetMonthRegion(DateTime date1, DateTime date2, string type)
    {
        int result = 0;
        switch (type)
        {
            case "d":
            case "b":
                result = ((TimeSpan)(date2 - date1)).Days;
                break;
            case "w":
                result = (int)Math.Floor((double)((TimeSpan)(date2 - date1)).Days / 7);
                break;
            case "m":
                result = (date2.Year - date1.Year) * 12 + (date2.Month - date1.Month);
                break;
            case "y":
                result = (date2.Year - date1.Year);
                break;
        }

        return result;
    }

    //判断是否工作日
    public static bool GetWorkDayFinal(DateTime date, string day)
    {
        int week = Convert.ToInt32(date.DayOfWeek);
        switch (day)
        {
            case "1":
                if (week != 1) return false;
                break;
            case "2":
                if (week > 2 || week == 0) return false;
                break;
            case "3":
                if (week > 3 || week == 0) return false;
                break;
            case "4":
                if (week > 4 || week == 0) return false;
                break;
            case "5":
                if (week > 5 || week == 0) return false;
                break;
            case "6":
                if (week == 0) return false;
                break;
        }
        return true;
    }

    //隐藏用户名
    public static string HideUserName(string name)
    {
        string result = name;
        if (name.StartsWith("aa") || name.StartsWith("qz") || name.StartsWith("qq") || name.StartsWith("py") || name.StartsWith("qw") || name.StartsWith("sjqq"))
        {
            result = name.Remove(name.Length - 2) + "**";
        }

        return result;
    }

    //取用户来自
    public static string GetUserFrom(string userFrom)
    {
        string str = "";
        int strNum = userFrom.IndexOf("_");
        if (strNum != -1)
        {
            userFrom = userFrom.Substring(0, strNum);
        }
        switch (userFrom)
        {
            case "qz":
                str = "QQ空间";
                break;
            case "qw":
                str = "WEB QQ";
                break;
            case "qq":
                str = "QQ登录";
                break;
            case "sjqq":
                str = "手机QQ登录";
                break;
            case "py":
                str = "朋友网";
                break;
            case "web":
                str = "网站";
                break;
            case "sj":
                str = "手机";
                break;
            case "sjweb":
                str = "手机网站";
                break;
            case "sjapp":
            default:
                str = "Android";
                break;
        }
        return str;
    }

    //取星期
    public static string GetWeekString(string date, int type)
    {
        DateTime d = DateTime.Parse(date);

        string[,] weekArr = { { "周日", "周一", "周二", "周三", "周四", "周五", "周六" }, { "日", "一", "二", "三", "四", "五", "六" } };

        return weekArr[type, Convert.ToInt32(d.DayOfWeek)];
    }

    //取图表数据
    public static string GetChartData(DataTable dd, string prop)
    {
        string strData = "";
        if (dd.Rows.Count > 0)
        {
            int index = 0;
            foreach (DataRow dr in dd.Rows)
            {
                index++;
                if (prop == "ItemBuyDate")
                {
                    strData += DateTime.Parse(dr["ItemBuyDate"].ToString()).ToString("yyyy-MM-dd");
                }
                else
                {
                    strData += dr[prop].ToString();
                }
                if (index < dd.Rows.Count) strData += ",";
            }
        }

        return strData;
    }

}