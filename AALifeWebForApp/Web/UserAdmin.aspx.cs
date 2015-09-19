using System;
using System.Data;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

public partial class UserAdmin : BasePage
{
    private int userId = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        userId = Int32.Parse(Session["UserID"].ToString());

        bool isBound = OAuthAccess.CheckOAuthBound(userId);
        //未绑定帐号跳转
        if (!isBound)
        {
            Response.Redirect("UserBoundAdmin.aspx");
        }

        if (!IsPostBack)
        {
            PopulateControls();
        }
    }

    protected void PopulateControls()
    {
        UserEntity user = UserAccess.GetUserById(userId);

        this.UserNickName.Text = user.UserNickName;

        string userImage = user.UserImage;
        if (Regex.IsMatch(userImage, "^http"))
        {
            this.UserImage.ImageUrl = userImage;
        }
        else
        {
            this.UserImage.ImageUrl = "/Images/Users/" + userImage;
        }

        this.UserWorkDay.Items.AddRange(UserAccess.GetUserWorkDayData());
        this.UserPhone.Text = user.UserPhone;
        this.UserEmail.Text = user.UserEmail;
        this.UserWorkDay.Items.FindByValue(user.UserWorkDay).Selected = true;
        this.CategoryRate.Text = user.CategoryRate.ToString();
    }
    //修改密码
    protected void Button2_Click(object sender, EventArgs e)
    {
        string userPassword = "";
        try
        {
            userPassword = UserAccess.GetUserPasswordById(userId);
        }
        catch 
        {
            Utility.Alert(this, "修改失败！");
            return;
        }

        string oldPassword = this.UserPassword.Text.Trim();
        if (oldPassword == "")
        {
            this.Label2.Text = "旧密码未填写！";
            return;
        }
        else
        {
            if (oldPassword != userPassword)
            {
                this.Label2.Text = "旧密码不正确！";
                return;
            }
        }

        string newPassword = this.NewPassword.Text.Trim();
        string newPassword2 = this.NewPassword2.Text.Trim();
        if (!ValidHelper.CheckLength(newPassword, 2))
        {
            this.Label1.Text = "新密码填写错误！";
            return;
        }
        if (newPassword != newPassword2)
        {
            this.Label4.Text = "两次新密码不一致！";
            return;
        }

        bool success = UserAccess.UpdateUserPassword(userId, newPassword);
        if (success)
        {
            Utility.Alert(this, "修改成功。", "UserLogout.aspx");
        }
        else
        {
            Utility.Alert(this, "修改失败！");
        }
    }
    //修改资料
    protected void SubmitButton_Click(object sender, EventArgs e)
    {
        string userNickName = this.UserNickName.Text.Trim();

        this.Label3.Text = "";
        string userEmail = this.UserEmail.Text.Trim();
        if (userEmail != "")
        {
            if (!ValidHelper.CheckEmail(userEmail))
            {
                this.Label3.Text = "邮箱格式填写错误！";
                return;
            }
        }

        string userPhone = this.UserPhone.Text.Trim();
        if (userPhone != "")
        {
            if (!ValidHelper.CheckPhone(userPhone))
            {
                this.Label6.Text = "手机号码填写错误！";
                return;
            }
        }

        string userWorkDay = this.UserWorkDay.SelectedValue;

        string categoryRate = this.CategoryRate.Text.Trim();
        if (!ValidHelper.CheckDouble(categoryRate))
        {
            Utility.Alert(this, "预算率填写错误！");
            return;
        }

        UserEntity user = UserAccess.GetUserById(userId);
        user.UserNickName = userNickName;
        user.UserEmail = userEmail;
        user.UserPhone = userPhone;
        user.UserWorkDay = userWorkDay;
        user.CategoryRate = Double.Parse(categoryRate);
        user.Synchronize = 1;

        bool success = UserAccess.UpdateUser(user);
        if (success)
        {
            Session["UserNickName"] = user.UserNickName;
            Session["UserWorkDay"] = user.UserWorkDay;
            Session["CategoryRate"] = user.CategoryRate;
            Utility.Alert(this, "修改成功。", "UserAdmin.aspx");
        }
        else
        {
            Utility.Alert(this, "修改失败！");
        }
    }
    //修改头像
    protected void Button1_Click(object sender, EventArgs e)
    {
        string userImage = this.UserImage.ImageUrl;
        if (!Regex.IsMatch(userImage, "^http"))
        {
            userImage = ImageHelper.GetImageFullName(userImage);
        }

        if (this.UserImageUpload.HasFile)
        {
            this.Label5.Text = "";
            string imageExt = ImageHelper.GetImageExt(this.UserImageUpload.FileName);
            if (imageExt != ".jpg" && imageExt != ".png" && imageExt != ".bmp" && imageExt != ".gif")
            {
                this.Label5.Text = "头像文件格式不支持！";
                return;
            }
            userImage = "tu_" + userId + imageExt;
            string imagePath = Server.MapPath("/Images/Users/") + userImage;
            try
            {
                this.UserImageUpload.SaveAs(imagePath);
                ImageHelper.SaveImage(imagePath, 100, 100);
            }
            catch
            {
                this.Label5.Text = "头像上传失败！";
                return;
            }
        }

        bool success = UserAccess.UpdateUserImage(userId, userImage);
        if (success)
        {
            Utility.Alert(this, "修改成功。", "UserAdmin.aspx");
        }
        else
        {
            Utility.Alert(this, "修改失败！");
        }
    }
}
