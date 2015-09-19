using System;
using System.Data;
using System.Text;
using System.Web.UI.WebControls;
using System.IO;
using System.Web;

public partial class AdminTongJi : AdminPage
{        
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.DateBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            this.DateBox2.Text = DateTime.Now.ToString("yyyy-MM-dd");

            TotalList.DataSource = BackupAccess.GetAdminTongJiQuanBu();
            TotalList.DataBind();

            BindGrid();
        }
    }

    protected void BindGrid()
    {
        string date = this.DateBox.Text;
        string date2 = this.DateBox2.Text;

        CreateList.DataSource = BackupAccess.GetAdminTongJiXinJian(date, date2);
        CreateList.DataBind();

        ActiveList.DataSource = BackupAccess.GetAdminTongJiHuoDong(date, date2);
        ActiveList.DataBind();
    }

    //查询//
    protected void Button2_Click(object sender, EventArgs e)
    {
        BindGrid();
    }
    

}