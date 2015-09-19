using System;
using System.Web.UI.WebControls;
using System.Data;

public partial class AdminItemList : AdminPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            DataTable dt = ItemAccess.GetAdminItemListToday();
            this.List.DataSource = dt;
            this.List.DataBind();
            this.Label1.Text = "记录：" + dt.Rows.Count;
        }
    }

    protected void BindGrid()
    {
        DataTable dt = ItemAccess.GetAdminItemList();
        this.List.DataSource = dt;
        this.List.DataBind();
        this.Label1.Text = "记录：" + dt.Rows.Count;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        this.List.AllowPaging = true;
        this.List.PageSize = 36;
        BindGrid();
    }

    protected void List_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.List.PageIndex = e.NewPageIndex;
        BindGrid();
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        string keywords = this.KeyBox.Text.Trim().Replace("%", "");
        if (keywords == "")
        {
            Utility.Alert(this, "关键字不能为空！");
            return;
        }

        DataTable dt = ItemAccess.GetAdminItemListByKeywords(keywords);
        this.List.AllowPaging = false;
        this.List.PageIndex = 0;
        this.List.DataSource = dt;
        this.List.DataBind();
        this.Label1.Text = "记录：" + dt.Rows.Count;
    }
}