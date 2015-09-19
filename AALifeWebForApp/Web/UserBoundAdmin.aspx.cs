using System;
using System.Web.UI.WebControls;
using System.Data;

public partial class UserBoundAdmin : BasePage
{
    private int userId = 0;
    public bool isBound = false;

    protected void Page_Load(object sender, EventArgs e)
    {
        userId = Int32.Parse(Session["UserID"].ToString());

        isBound = OAuthAccess.CheckOAuthBound(userId);

        if (!IsPostBack)
        {
            PopulateControls();
        }
    }

    protected void PopulateControls()
    {
        this.BoundList.DataSource = OAuthAccess.GetOAuthByUserId(userId);
        this.BoundList.DataBind();
    }

    //绑定新帐号
    protected void NewButton_Click(object sender, EventArgs e)
    {
        string userName = this.UserNameNew.Text.Trim();
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

        string userPassword = this.UserPasswordNew.Text.Trim();
        if (!ValidHelper.CheckLength(userPassword, 2))
        {
            Utility.Alert(this, "密码填写错误！");
            return;
        }

        bool success = OAuthAccess.OAuthBoundNew(userId, userName, userPassword);
        if (success)
        {
            PopulateControls();
            Utility.Alert(this, "绑定成功。", "UserBoundAdmin.aspx");
        }
        else
        {
            Utility.Alert(this, "绑定失败！");
        }
    }
    //绑定已有帐号
    protected void BoundButton_Click(object sender, EventArgs e)
    {
        string userName = this.UserNameBound.Text.Trim();
        if (!ValidHelper.CheckLength(userName, 2))
        {
            Utility.Alert(this, "用户名填写错误！");
            return;
        }

        string userPassword = this.UserPasswordBound.Text.Trim();
        if (!ValidHelper.CheckLength(userPassword, 2))
        {
            Utility.Alert(this, "密码填写错误！");
            return;
        }

        int newUserId = 0;
        bool success = UserAccess.CheckUserLogin(userName, userPassword, out newUserId);
        if (success)
        {
            UserEntity user = UserAccess.GetUserById(newUserId);
            success = OAuthAccess.OAuthBoundUser(userId, user.UserID);
            if (success)
            {
                Session["UserID"] = userId = user.UserID;
                Session["UserName"] = user.UserName;
                Session["UserNickName"] = user.UserNickName;
                Session["UserTheme"] = user.UserTheme;
                Session["UserLevel"] = user.UserLevel.ToString();
                Session["UserFrom"] = user.UserFrom;
                Session["UserWorkDay"] = user.UserWorkDay;
                Session["UserFunction"] = user.UserFunction;
                Session["CategoryRate"] = user.CategoryRate;

                Response.Cookies["ThemeCookie"].Value = user.UserTheme;
                Response.Cookies["ThemeCookie"].Expires = DateTime.MaxValue;

                PopulateControls();
                Utility.Alert(this, "绑定成功。", "UserBoundAdmin.aspx");
            }
            else
            {
                Utility.Alert(this, "绑定失败！");
            }
        }
        else
        {
            Utility.Alert(this, "登录失败！");
        }
    }
    //解除绑定
    protected void Button3_Command(object sender, CommandEventArgs e)
    {
        string[] str = e.CommandArgument.ToString().Split(',');

        int oauthId = Int32.Parse(str[0]);
        int oldUserId = Int32.Parse(str[1]);
        bool success = OAuthAccess.OAuthBoundCancel(oauthId, oldUserId);
        if (success)
        {
            PopulateControls();
            Utility.Alert(this, "解除成功。", "UserBoundAdmin.aspx");
        }
        else
        {
            Utility.Alert(this, "解除失败！");
        }
    }
}
