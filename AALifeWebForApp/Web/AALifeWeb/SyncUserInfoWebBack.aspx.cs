﻿using System;

public partial class AALifeWeb_SyncUserInfoWebBack : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int userId = Int32.Parse(Request.Form["userid"].ToString());

        bool success = SyncHelper.SyncUserInfoWebBack(userId);
        string result = "{";
        if (success)
        {
            result += "\"result\":\"ok\"";
        }
        else
        {
            result += "\"result\":\"error\"";
        }
        result += "}";

        Response.Write(result);
        Response.End();
    }
}