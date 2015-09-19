using System;
using System.Web.UI.WebControls;
using System.Data;

public partial class UserCardAdmin : BasePage
{
    private int userId = 0;
    public double totalMoney = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        userId = Int32.Parse(Session["UserID"].ToString());

        if (!IsPostBack)
        {
            BindGrid();
        }
    }

    protected void BindGrid()
    {
        DataTable dt = CardAccess.GetCardList(userId);
        this.CardList.DataSource = dt;
        this.CardList.DataBind();

        foreach (DataRow dr in dt.Rows)
        {
            totalMoney += Double.Parse(dr["CardMoney"].ToString());
        }
    } 

    //类别更新操作
    protected void CardList_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int cardId = Int32.Parse(CardList.DataKeys[e.RowIndex].Value.ToString());
        TextBox cardNameBox = (TextBox)CardList.Rows[e.RowIndex].FindControl("CardNameBox");
        string cardName = cardNameBox.Text.Trim();
        if (cardName == "")
        {
            Utility.Alert(this, "名称未填写！");
            return;
        }
        TextBox cardMoneyBox = (TextBox)CardList.Rows[e.RowIndex].FindControl("CardMoneyBox");
        string cardMoney = cardMoneyBox.Text.Trim();
        if (!ValidHelper.CheckDouble(cardMoney))
        {
            Utility.Alert(this, "余额填写错误！");
            return;
        }

        bool success = false;
        if (cardId == 0)
        {
            success = UserAccess.UpdateUserMoneyNew(userId, Double.Parse(cardMoney));
        }
        else
        {
            CardEntity card = new CardEntity();
            card.CardID = cardId;
            card.CardName = cardName;
            card.CardMoney = Double.Parse(cardMoney);
            card.UserID = userId;
            card.CardLive = 1;
            card.Synchronize = 1;

            success = CardAccess.UpdateCard(card);
        }

        if (success)
        {
            Utility.Alert(this, "更新成功。");

            CardList.EditIndex = -1;
            BindGrid();
        }
        else
        {
            Utility.Alert(this, "更新失败！");
        }
    }

    //类别取消操作
    protected void CardList_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        CardList.EditIndex = -1;
        BindGrid();
    }

    //类别更新进入操作
    protected void CardList_RowEditing(object sender, GridViewEditEventArgs e)
    {
        CardList.EditIndex = e.NewEditIndex;
        BindGrid();

        int cardId = Int32.Parse(CardList.DataKeys[e.NewEditIndex].Value.ToString());
        TextBox cardNameBox = (TextBox)CardList.Rows[e.NewEditIndex].FindControl("CardNameBox");
        if (cardId == 0)
        {
            cardNameBox.Attributes.Add("readonly", "readonly");
            cardNameBox.Style.Add("background", "#F4F4F4");
        }
    }

    //添加类别操作
    protected void Button1_Click(object sender, EventArgs e)
    {
        string cardName = this.CardNameEmpIns.Text.Trim();
        if (cardName == "")
        {
            Utility.Alert(this, "名称未填写！");
            return;
        }
        string cardMoney = this.CardMoneyEmpIns.Text.Trim();
        if (cardMoney != "")
        {
            if (!ValidHelper.CheckDouble(cardMoney))
            {
                Utility.Alert(this, "余额填写错误！");
                return;
            }
        }
        else
        {
            cardMoney = "0";
        }

        CardEntity card = new CardEntity();
        card.CardName = cardName;
        card.CardMoney = Double.Parse(cardMoney);
        card.UserID = userId;
        card.CardLive = 1;
        card.Synchronize = 1;

        bool success = CardAccess.InsertCard(card);
        if (success)
        {
            Utility.Alert(this, "添加成功。", "UserCardAdmin.aspx");
        }
        else
        {
            Utility.Alert(this, "添加失败！");
        }
    }

    //类别删除操作
    protected void CardList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int cardId = Int32.Parse(CardList.DataKeys[e.RowIndex].Value.ToString());

        if (cardId == 0)
        {
            Utility.Alert(this, "不能删除我的钱包！");
            return;
        }

        CardEntity card = CardAccess.GetCardByCardId(cardId, userId);
        card.CardLive = 0;
        card.Synchronize = 1;

        bool success = CardAccess.CheckItemListByCardId(userId, cardId);
        if (!success)
        {
            success = CardAccess.UpdateCard(card);
            if (success)
            {
                Utility.Alert(this, "删除成功。");

                CardList.EditIndex = -1;
                BindGrid();
            }
            else
            {
                Utility.Alert(this, "删除失败！");
            }
        }
        else
        {
            Utility.Alert(this, "不能删除已使用的钱包！");
        }
    }

}
