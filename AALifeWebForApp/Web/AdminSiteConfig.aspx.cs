using System;

public partial class AdminSiteConfig : AdminPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
        }
    }

    protected void BindData()
    {
        this.SiteNameBox.Text = WebConfiguration.SiteName;
        this.SiteAuthorBox.Text = WebConfiguration.SiteAuthor;
        this.SiteKeywordsBox.Text = WebConfiguration.SiteKeywords;
        this.SiteDescriptionBox.Text = WebConfiguration.SiteDescription;
        this.PagePerNumberBox.Text = WebConfiguration.PagePerNumber;
        this.SiteTipsBox.Text = Utility.UnReplaceString(WebConfiguration.SiteTips);
        this.MessageCode.Text = WebConfiguration.MessageCode;
        this.SiteMessage.Text = Utility.UnReplaceString(WebConfiguration.SiteMessage);
        this.PhoneMessage.Text = Utility.UnReplaceString(WebConfiguration.PhoneMessage);
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string siteName = this.SiteNameBox.Text;
        string siteAuthor = this.SiteAuthorBox.Text;
        string siteKeywords = this.SiteKeywordsBox.Text;
        string siteDescription = this.SiteDescriptionBox.Text;
        string pagePerNumber = this.PagePerNumberBox.Text;
        string siteTips = Utility.ReplaceString(this.SiteTipsBox.Text);
        string messageCode = this.MessageCode.Text;
        string siteMessage = Utility.ReplaceString(this.SiteMessage.Text);
        string phoneMessage = Utility.ReplaceString(this.PhoneMessage.Text);

        string strXmlFile = Server.MapPath("~/Site.Config");
        XmlControl xmlTool = new XmlControl(strXmlFile);
        xmlTool.Update("Root/SiteName", siteName);
        xmlTool.Update("Root/SiteAuthor", siteAuthor);
        xmlTool.Update("Root/SiteKeywords", siteKeywords);
        xmlTool.Update("Root/SiteDescription", siteDescription);
        xmlTool.Update("Root/PagePerNumber", pagePerNumber);
        xmlTool.Update("Root/SiteTips", siteTips);
        xmlTool.Update("Root/MessageCode", messageCode);
        xmlTool.Update("Root/SiteMessage", siteMessage);
        xmlTool.Update("Root/PhoneMessage", phoneMessage);
        
        bool success = xmlTool.Save();
        xmlTool.Dispose();
        if (success)
        {
            WebConfiguration.GetConfig();
            Utility.Alert(this, "修改成功。", "AdminSiteConfig.aspx");
        }
        else
        {
            Utility.Alert(this, "修改失败！");
        }
    }
}