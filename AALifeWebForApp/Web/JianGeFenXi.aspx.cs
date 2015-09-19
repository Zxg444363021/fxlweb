using System;
using System.Data;

public partial class JianGeFenXi : BasePage
{
    private int userId = 0;
    public int howManyItems = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        userId = Int32.Parse(Session["UserID"].ToString());

        if (!IsPostBack)
        {
            PopulateControls();
        }
    }

    protected void PopulateControls()
    {
        int notBuyMax = 0;
        int pageNumber = 1;
        DataTable dt = ItemAccess.GetJianGeFenXiList(userId, pageNumber, out howManyItems, out notBuyMax);
        List.DataSource = dt;
        List.DataBind();

        this.hidChartData.Value = ItemHelper.GetChartData(dt, "ItemBuyDate");
    }
}