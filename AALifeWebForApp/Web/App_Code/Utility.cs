using System;
using System.Web.UI;

public class Utility
{
    static Utility()
    {
    }

    //进入页面后提示不转向
    public static void Alert(Page page, string msg)
    {
        string key = "AlertMessage";
        string script = String.Format("alert('{0}');", msg);
        page.ClientScript.RegisterStartupScript(typeof(Page), key, script, true);
    }

    //进入页面前提示转向
    public static void Alert(Page page, string msg, string url)
    {
        string key = "AlertMessage";
        string script = String.Format("alert('{0}');window.location='{1}';", msg, url);
        page.ClientScript.RegisterStartupScript(typeof(Page), key, script, true);//RegisterClientScriptBlock
    }

    //confirm
    public static void Confirm(Page page, string msg, string page1, string page2)
    {
        string key = "ConfirmMessage";
        string script = String.Format("confirm('{0}')?window.location='{1}':window.location='{2}';", msg, page1, page2);
        page.ClientScript.RegisterStartupScript(typeof(Page), key, script, true);
    }

    //替换字符
    public static string ReplaceString(string str)
    {
        str = str.Replace("<", "&lt;");
        str = str.Replace(">", "&gt;");
        str = str.Replace("\"", "&quot;");
        str = str.Replace("'", "''");
        //str = str.Replace(Convert.ToChar(13).ToString(), "<br />");
        return str;
    }

    //还原字符
    public static string UnReplaceString(string str)
    {
        str = str.Replace("&lt;", "<");
        str = str.Replace("&gt;", ">");
        str = str.Replace("&quot;", "\"");
        str = str.Replace("''", "'");
        //str = str.Replace("<br />", Convert.ToChar(13).ToString());
        return str;
    }
    
    //取随机数
    public static string GetRandomNumber(int minNum, int maxNum)
    {
        Random rad = new Random();
        return rad.Next(minNum, maxNum).ToString();
    }
}
