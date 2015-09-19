using System;
using System.Data;
using System.Web.UI.WebControls;

public partial class SearchItem : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataTable dt = new DataTable();
            SearchItemList.DataSource = dt;
            SearchItemList.DataBind();

            UpdateTotalPrice(dt);
        }
    }

    protected void SubmitButtom_Click(object sender, EventArgs e)
    {
        int userId = Int32.Parse(Session["UserID"].ToString());

        string keywords = this.Keywords.Text.Trim().Replace("%", "");
        if (keywords == "")
        {
            Utility.Alert(this, "关键字不能为空！");
            return;
        }

        DataTable dt = ItemAccess.GetItemListByKeywords(keywords, userId);
        SearchItemList.DataSource = dt;
        SearchItemList.DataBind();

        UpdateTotalPrice(dt);
    }

    //点击CheckBox统计总价
    protected void ItemCheckBox_CheckedChanged(object sender, EventArgs e)
    {
        double shouruPrice = Double.Parse(this.Label2.Text);
        double zhichuPrice = Double.Parse(this.Label3.Text);

        try
        {
            CheckBox cb = (CheckBox)sender;
            Label price = (Label)cb.Parent.FindControl("ItemPriceLab");
            Label type = (Label)cb.Parent.FindControl("ItemTypeLab");
            if (cb.Checked)
            {
                switch (type.Text)
                {
                    case "收入":
                    case "还入":
                    case "借入":
                        shouruPrice += Double.Parse(price.Text);
                        break;
                    case "支出":
                    case "借出":
                    case "还出":
                        zhichuPrice += Double.Parse(price.Text);
                        break;
                }
            }
            else
            {
                switch (type.Text)
                {
                    case "收入":
                    case "还入":
                    case "借入":
                        shouruPrice -= Double.Parse(price.Text);
                        break;
                    case "支出":
                    case "借出":
                    case "还出":
                        zhichuPrice -= Double.Parse(price.Text);
                        break;
                }
            }
        }
        catch
        {
        }

        this.Label2.Text = shouruPrice.ToString("0.00#");
        this.Label3.Text = zhichuPrice.ToString("0.00#");
    }

    protected void UpdateTotalPrice(DataTable dt)
    {
        double zhichuPrice = 0;
        double shouruPrice = 0;
        foreach (DataRow dr in dt.Rows)
        {
            string itemType = dr["ItemTypeValue"].ToString();
            double itemPrice = Double.Parse(dr["ItemPrice"].ToString());
            if (itemType == "zc" || itemType == "jc" || itemType == "hc")
            {
                zhichuPrice += itemPrice;
            }
            else
            {
                shouruPrice += itemPrice;
            }
        }

        this.Label2.Text = shouruPrice.ToString("0.00#");
        this.Label3.Text = zhichuPrice.ToString("0.00#");
    }

}
