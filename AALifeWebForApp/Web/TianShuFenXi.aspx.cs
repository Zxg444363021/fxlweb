using System;
using System.Data;

public partial class TianShuFenXi : BasePage
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
        int pageNumber = 1;
        int notBuyMax = 0;
        DataTable dt = ItemAccess.GetTianShuFenXiList(userId, pageNumber, out howManyItems, out notBuyMax);
        List.DataSource = dt;
        List.DataBind();

        this.hidChartData.Value = ItemHelper.GetChartData(dt, "ItemBuyDate");
    }
}