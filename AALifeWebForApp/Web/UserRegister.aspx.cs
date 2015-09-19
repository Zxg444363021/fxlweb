using System;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;

public partial class UserRegister : FirstPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.UserWorkDay.Items.AddRange(UserAccess.GetUserWorkDayData());
            this.UserWorkDay.Items.FindByValue("5").Selected = true;
        }
    }

    protected void SubmitButtom_Click(object sender, EventArgs e)
    {
        string userName = this.UserName.Text.Trim();
        string userPassword = this.UserPassword.Text.Trim();
        string userPassword2 = this.UserPassword2.Text.Trim();
        string userNickName = this.UserNickName.Text.Trim();
        string userEmail = this.UserEmail.Text.Trim();
        string userTheme = "main"; 
        string userWorkDay = this.UserWorkDay.SelectedValue;

        if (!ValidHelper.CheckLength(userName, 2))
        {
            Utility.Alert(this, "用户名填写错误！");
            return;
        }

        bool repeat = UserAccess.CheckUserRepeat(userName);
        if (repeat)
        {
            Utility.Alert(this, "用户名重复！");
            return;
        }

        if (!ValidHelper.CheckLength(userPassword, 2))
        {
            Utility.Alert(this, "密码填写错误！");
            return;
        }

        if (userPassword2 == "")
        {
            Utility.Alert(this, "重复密码未填写！");
            return;
        }

        if (userPassword != userPassword2)
        {
            Utility.Alert(this, "两次密码不一致！");
            return;
        }

        if (userEmail != "")
        {
            if (!ValidHelper.CheckEmail(userEmail))
            {
                Utility.Alert(this, "邮箱格式填写错误！");
                return;
            }
        }
        
        if (Request.Cookies["ThemeCookie"] != null)
        {
            userTheme = Request.Cookies["ThemeCookie"].Value;
        }

        UserEntity user = new UserEntity();
        user.UserName = userName;
        user.UserPassword = userPassword;
        user.UserNickName = userNickName;
        user.UserImage = "none.gif";
        user.UserEmail = userEmail;
        user.UserWorkDay = userWorkDay;
        user.UserTheme = userTheme;
        user.UserFrom = "web";
        user.UserPhone = "";
        user.UserMoney = 0;
        user.CategoryRate = 90;

        int userId = 0;
        bool success = UserAccess.InsertUser(user, out userId);
        if (success)
        {
            Session["TodayDate"] = DateTime.Now.ToString("yyyy-MM-dd");

            UserEntity newUser = UserAccess.GetUserById(userId);
            Session["UserID"] = newUser.UserID;
            Session["UserName"] = newUser.UserName;
            Session["UserNickName"] = newUser.UserNickName;
            Session["UserTheme"] = newUser.UserTheme;
            Session["UserLevel"] = newUser.UserLevel.ToString();
            Session["UserFrom"] = newUser.UserFrom;
            Session["UserWorkDay"] = newUser.UserWorkDay;
            Session["UserFunction"] = newUser.UserFunction;
            Session["CategoryRate"] = user.CategoryRate;
            
            Utility.Alert(this, "注册成功。", "Default.aspx");
        }
        else
        {
            Utility.Alert(this, "注册失败！");
        }
    }
}
