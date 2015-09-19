using System;
using System.Web.UI.WebControls;
using System.Data;

public partial class UserCategoryAdmin : BasePage
{
    private int userId = 0;

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
        double catRate = Double.Parse(Session["CategoryRate"].ToString());
        DataTable dt = UserCategoryAccess.GetCategoryTypeList(userId);
        dt.Columns.Add("CategoryTypeRate", typeof(string));
        foreach (DataRow dr in dt.Rows)
        {
            double catPrice = Double.Parse(dr["CategoryTypePrice"].ToString());
            double[] denArr = GetDenArray(catPrice, catRate);
            if (catPrice > 0)
            {
                dr["CategoryTypeRate"] = denArr[0] + " ~ " + denArr[1];
            }
            else
            {
                dr["CategoryTypeRate"] = "0";
            }
        }

        this.CatTypeList.DataSource = dt;
        this.CatTypeList.DataBind();
    } 

    //类别更新操作
    protected void CatTypeList_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int catTypeId = Int32.Parse(CatTypeList.DataKeys[e.RowIndex].Value.ToString());
        TextBox catTypeNameBox = (TextBox)CatTypeList.Rows[e.RowIndex].FindControl("CatTypeNameBox");
        string catTypeName = catTypeNameBox.Text.Trim();
        if (catTypeName == "")
        {
            Utility.Alert(this, "类别名称未填写！");
            return;
        }
        TextBox catTypePriceBox = (TextBox)CatTypeList.Rows[e.RowIndex].FindControl("CatTypePriceBox");
        string catTypePrice = catTypePriceBox.Text.Trim();
        if (!ValidHelper.CheckDouble(catTypePrice))
        {
            Utility.Alert(this, "类别预算填写错误！");
            return;
        }

        UserCategoryEntity userCat = new UserCategoryEntity();
        userCat.CategoryTypeID = catTypeId;
        userCat.CategoryTypeName = catTypeName;
        userCat.CategoryTypePrice = Double.Parse(catTypePrice);
        userCat.UserID = userId;
        userCat.CategoryTypeLive = 1;
        userCat.Synchronize = 1;

        bool success = UserCategoryAccess.UpdateCategoryType(userCat);
        if (success)
        {
            Utility.Alert(this, "更新成功。");

            CatTypeList.EditIndex = -1;
            BindGrid();
        }
        else
        {
            Utility.Alert(this, "更新失败！");
        }
    }

    //类别取消操作
    protected void CatTypeList_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        CatTypeList.EditIndex = -1;
        BindGrid();
    }

    //类别更新进入操作
    protected void CatTypeList_RowEditing(object sender, GridViewEditEventArgs e)
    {
        CatTypeList.EditIndex = e.NewEditIndex;
        BindGrid();
    }

    //添加类别操作
    protected void Button1_Click(object sender, EventArgs e)
    {
        string catTypeName = this.CatTypeNameEmpIns.Text.Trim();
        if (catTypeName == "")
        {
            Utility.Alert(this, "类别名称未填写！");
            return;
        }
        string catTypePrice = this.CatTypePriceEmpIns.Text.Trim();
        if (catTypePrice != "")
        {
            if (!ValidHelper.CheckDouble(catTypePrice))
            {
                Utility.Alert(this, "类别预算填写错误！");
                return;
            }
        }
        else
        {
            catTypePrice = "0";
        }

        UserCategoryEntity userCat = new UserCategoryEntity();
        userCat.CategoryTypeName = catTypeName;
        userCat.CategoryTypePrice = Double.Parse(catTypePrice);
        userCat.UserID = userId;
        userCat.CategoryTypeLive = 1;
        userCat.Synchronize = 1;

        int catTypeId = 0;
        bool success = UserCategoryAccess.InsertCategoryType(userCat, out catTypeId);
        if (success)
        {
            Utility.Alert(this, "添加成功。", "UserCategoryAdmin.aspx");
        }
        else
        {
            Utility.Alert(this, "添加失败！");
        }
    }

    //类别删除操作
    protected void CatTypeList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int catTypeId = Int32.Parse(CatTypeList.DataKeys[e.RowIndex].Value.ToString());
        string catTypeName = ((Label)CatTypeList.Rows[e.RowIndex].FindControl("CatTypeNameLab")).Text;
        string catTypePrice = ((Label)CatTypeList.Rows[e.RowIndex].FindControl("CatTypePriceLab")).Text;
        
        UserCategoryEntity userCat = new UserCategoryEntity();
        userCat.CategoryTypeID = catTypeId;
        userCat.CategoryTypeName = catTypeName;
        userCat.CategoryTypePrice = Double.Parse(catTypePrice);
        userCat.UserID = userId;
        userCat.CategoryTypeLive = 0;
        userCat.Synchronize = 1;

        bool success = UserCategoryAccess.CheckItemListByCatId(userId, catTypeId);
        if (!success)
        {
            success = UserCategoryAccess.DeleteCategoryType(userCat);
            if (success)
            {
                Utility.Alert(this, "删除成功。");

                CatTypeList.EditIndex = -1;
                BindGrid();
            }
            else
            {
                Utility.Alert(this, "删除失败！");
            }
        }
        else
        {
            Utility.Alert(this, "不能删除已使用的类别！");
        }
    }

    protected double[] GetDenArray(double catPrice, double catRate)
    {
        double num = catPrice - catPrice * (catRate / 100);
        double[] result = new double[2];
        result[0] = catPrice - num;
        result[1] = catPrice + num;

        return result;
    }

}
