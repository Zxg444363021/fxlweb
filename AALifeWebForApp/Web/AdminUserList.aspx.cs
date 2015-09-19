using System;
using System.Web.UI.WebControls;
using System.Data;

public partial class AdminUserList : AdminPage
{
    private string date = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["date"] != null && Request.QueryString["date"] != "")
        {
            date = Request.QueryString["date"];
        }
        else
        {
            date = DateTime.Now.ToString("yyyy-MM-dd");
        }

        if (!IsPostBack)
        {
            PopulateControls();
        }
    }

    protected void PopulateControls()
    {
        this.TypeHid.Value = "0";

        DataTable dt = UserAccess.GetAdminUserListByDate(date);
        AdminList.DataSource = dt;
        AdminList.DataBind();
        this.Label1.Text = "记录：" + dt.Rows.Count;
    }

    protected void BindGrid()
    {
        this.TypeHid.Value = "2";

        DataTable dt = UserAccess.GetAdminUserList();
        AdminList.DataSource = dt;
        AdminList.DataBind();
        this.Label1.Text = "记录：" + dt.Rows.Count;
    }

    protected void List_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int userId = Int32.Parse(AdminList.DataKeys[e.RowIndex].Value.ToString());

        bool success = UserAccess.DeleteUser(userId);
        if (success)
        {
            Utility.Alert(this, "删除成功。");
        }
        else
        {
            Utility.Alert(this, "删除失败！");
            return;
        }

        AdminList.EditIndex = -1;
        SwitchData();
    }

    protected void List_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        bool success = false;

        int userId = Int32.Parse(AdminList.DataKeys[e.RowIndex].Value.ToString());

        string oldUserName = ((HiddenField)AdminList.Rows[e.RowIndex].FindControl("UserNameHid")).Value;
        string userName = ((TextBox)AdminList.Rows[e.RowIndex].FindControl("UserNameBox")).Text.Trim();
        if (userName == "")
        {
            Utility.Alert(this, "用户名未填写！");
            return;
        }
        if (oldUserName != userName)
        {
            success = UserAccess.CheckUserRepeat(userName);
            if (success)
            {
                Utility.Alert(this, "用户名重复！");
                return;
            }
        }

        string userPassword = ((TextBox)AdminList.Rows[e.RowIndex].FindControl("UserPassBox")).Text.Trim();
        if (userPassword == "")
        {
            Utility.Alert(this, "密码未填写！");
            return;
        }

        string userNickName = ((TextBox)AdminList.Rows[e.RowIndex].FindControl("UserNickBox")).Text.Trim();

        string userImage = ((HiddenField)AdminList.Rows[e.RowIndex].FindControl("UserImageHid")).Value;
        FileUpload userImageUpload = (FileUpload)AdminList.Rows[e.RowIndex].FindControl("UserImageUpload");
        if (userImageUpload.HasFile)
        {
            userImage = "tu_" + userId + ImageHelper.GetImageExt(userImageUpload.FileName);
            string imagePath = Server.MapPath("Images/Users/") + userImage;
            try
            {
                userImageUpload.SaveAs(imagePath);
                ImageHelper.SaveImage(imagePath, 100, 100);
            }
            catch
            {
                Utility.Alert(this, "头像上传失败！");
                return;
            }
        }
        
        string userEmail = ((TextBox)AdminList.Rows[e.RowIndex].FindControl("UserEmailBox")).Text.Trim();
        string userTheme = ((TextBox)AdminList.Rows[e.RowIndex].FindControl("UserThemeBox")).Text.Trim();
        int userLevel = Int32.Parse(((TextBox)AdminList.Rows[e.RowIndex].FindControl("UserLevelBox")).Text.Trim());
        string userFrom = ((TextBox)AdminList.Rows[e.RowIndex].FindControl("UserFromBox")).Text.Trim();
        string categoryRate = ((TextBox)AdminList.Rows[e.RowIndex].FindControl("CategoryRateBox")).Text.Trim();
        string userMoney = ((TextBox)AdminList.Rows[e.RowIndex].FindControl("UserMoneyBox")).Text.Trim();

        UserEntity user = UserAccess.GetUserById(userId);
        user.UserName = userName;
        user.UserPassword = userPassword;
        user.UserNickName = userNickName;
        user.UserImage = userImage;
        user.UserEmail = userEmail;
        user.UserTheme = userTheme;
        user.UserLevel = userLevel;
        user.UserFrom = userFrom;
        user.CategoryRate = Double.Parse(categoryRate);
        user.UserMoney = (userMoney == "" ? 0 : Double.Parse(userMoney));
        user.Synchronize = 1;

        success = UserAccess.UpdateUser(user);
        if (success)
        {
            Utility.Alert(this, "更新成功。");
        }
        else
        {
            Utility.Alert(this, "更新失败！");
            return;
        }

        AdminList.EditIndex = -1;
        SwitchData();
    }

    protected void List_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        AdminList.EditIndex = -1;
        SwitchData();
    }

    protected void List_RowEditing(object sender, GridViewEditEventArgs e)
    {
        AdminList.EditIndex = e.NewEditIndex;
        SwitchData();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        AdminList.AllowPaging = true;
        AdminList.PageSize = 36;
        BindGrid();
    }

    //昨天按钮
    protected void Button2_Click(object sender, EventArgs e)
    {
        date = DateTime.Parse(date).AddDays(-1).ToString("yyyy-MM-dd");
        Response.Redirect("AdminUserList.aspx?date=" + date);
    }

    //明天按钮
    protected void Button3_Click(object sender, EventArgs e)
    {
        date = DateTime.Parse(date).AddDays(1).ToString("yyyy-MM-dd");
        Response.Redirect("AdminUserList.aspx?date=" + date);
    }

    protected void List_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        AdminList.PageIndex = e.NewPageIndex;
        BindGrid();
    }

    //搜索按钮
    protected void Button4_Click(object sender, EventArgs e)
    {
        string keywords = this.KeyBox.Text.Trim().Replace("%", "");
        if (keywords == "")
        {
            Utility.Alert(this, "关键字不能为空！");
            return;
        }

        this.TypeHid.Value = "1";

        DataTable dt = UserAccess.GetAdminUserListByKeywords(keywords);
        AdminList.AllowPaging = false;
        AdminList.PageIndex = 0;
        AdminList.DataSource = dt;
        AdminList.DataBind();
        this.Label1.Text = "记录：" + dt.Rows.Count;
    }

    protected void SwitchData()
    {
        if (this.TypeHid.Value == "0")
        {
            PopulateControls();
        }
        else if (this.TypeHid.Value == "1")
        {
            Button4_Click(null, null);
        }
        else
        {
            Button1_Click(null, null);
        }
    }
}