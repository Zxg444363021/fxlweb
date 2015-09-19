<%@ WebHandler Language="C#" Class="SyncUserImage" %>

using System;
using System.Web;

public class SyncUserImage : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";

        int count = context.Request.Files.Count;

        for (int i = 0; i < count; i++) 
        {
            HttpPostedFile aFile = context.Request.Files[i];

            if (aFile.ContentLength == 0 || String.IsNullOrEmpty(aFile.FileName))
            {
                continue;
            }
            
            string displayFileName = System.IO.Path.GetFileName(aFile.FileName);
            string realFileName = System.Web.HttpContext.Current.Server.MapPath("/Images/Users/") + displayFileName;
            string imageFileName = displayFileName;

            try
            {
                aFile.SaveAs(realFileName);
            }
            catch
            {
                imageFileName = "user.gif";
            }

            bool success = UserAccess.UpdateUserImage(getUserId(displayFileName), imageFileName);
            if (success)
            {
                context.Response.Write(1);
            }
            else
            {
                context.Response.Write(0);
            }
        }
    }
 
    public bool IsReusable 
    {
        get 
        {
            return false;
        }
    }

    private int getUserId(string fileName)
    {
        int start = fileName.LastIndexOf(".");
        string name = fileName.Substring(0, start);
        name = name.Replace("tu_", "");

        return Int32.Parse(name);
    }

}