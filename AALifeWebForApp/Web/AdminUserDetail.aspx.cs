using System;
using System.Web.UI.WebControls;

public partial class AdminUserDetail : AdminPage
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PupolateControls();
        }
    }

    protected void PupolateControls()
    {
        int userId = 0;
        if (Request.QueryString["userId"] != "" && Request.QueryString["userId"] != null)
        {
            userId = Int32.Parse(Request.QueryString["userId"]);
        }

        UserList.DataSource = UserAccess.GetAdminUserListById(userId);
        UserList.DataBind();

        OAuthList.DataSource = OAuthAccess.GetAdminOAuthList(userId);
        OAuthList.DataBind();

        UserCategoryList.DataSource = UserCategoryAccess.GetAdminUserCategoryList(userId);
        UserCategoryList.DataBind();

        ZhuanTiList.DataSource = ZhuanTiAccess.GetAdminZhuanTiList(userId);
        ZhuanTiList.DataBind();

        CardList.DataSource = CardAccess.GetAdminCardList(userId);
        CardList.DataBind();

        List.DataSource = ItemAccess.GetAdminItemListByUserId(userId);
        List.DataBind();
    }

    protected void List_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        List.PageIndex = e.NewPageIndex;
        PupolateControls();
    }
}