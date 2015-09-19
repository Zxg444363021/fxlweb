using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AuthorLogin_Test : FirstPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //QQ登录
        Response.Redirect("/AuthorLogin/OAuth.aspx?u=qq&openId=F8B2F4BCBDDBD5AAAEAF8F991871D43E&accessToken=6C5BBB9529CA944AE84B6B496268942F&name=我才天生&image=http://qzapp.qlogo.cn/qzapp/100294524/F8B2F4BCBDDBD5AAAEAF8F991871D43E/50");
        
        //QZone
        //Response.Redirect("/AuthorLogin/OAuth.aspx?u=qz&openId=A5E2E1AE14FF027D3926CC30B31EF814&accessToken=700EA8F1F4D679210FBA638518D844A1&name=我才天生&image=http://qzapp.qlogo.cn/qzapp/100294524/F8B2F4BCBDDBD5AAAEAF8F991871D43E/50");
    }
}