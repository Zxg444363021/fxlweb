using System;
using System.Web.UI.WebControls;
using System.Data;

public partial class UserZhuanTi : BasePage
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
        this.List.DataSource = ZhuanTiAccess.GetZhuanTiList(userId);
        this.List.DataBind();
    }

    //更新操作
    protected void List_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int zhuanTiId = Int32.Parse(List.DataKeys[e.RowIndex].Value.ToString());

        string zhuanTiImage = ((HiddenField)List.Rows[e.RowIndex].FindControl("ZhuanTiImageHid")).Value;
        FileUpload zhuanTiImageUpload = (FileUpload)List.Rows[e.RowIndex].FindControl("ZhuanTiImageUpload");
        if (zhuanTiImageUpload.HasFile)
        {
            string imageExt = ImageHelper.GetImageExt(zhuanTiImageUpload.FileName);
            string imageName = ImageHelper.GetImageName(zhuanTiImage);
            if (imageExt != ".jpg" && imageExt != ".png" && imageExt != ".bmp" && imageExt != ".gif")
            {
                Utility.Alert(this, "图片文件格式不支持！");
                return;
            }
            if (imageName == "none")
            {
                imageName = "zt_" + userId + "_" + Utility.GetRandomNumber(1000, 9999);
            }
            zhuanTiImage = imageName + imageExt;
            string imagePath = Server.MapPath("/Images/ZhuanTi/") + zhuanTiImage;
            try
            {
                zhuanTiImageUpload.SaveAs(imagePath);
                ImageHelper.SaveImage(imagePath, 200, 200);
            }
            catch
            {
                Utility.Alert(this, "专题图片上传失败！");
                return;
            }
        }

        TextBox zhuanTiNameBox = (TextBox)List.Rows[e.RowIndex].FindControl("ZhuanTiNameBox");
        string zhuanTiName = zhuanTiNameBox.Text.Trim();
        if (zhuanTiName == "")
        {
            Utility.Alert(this, "专题名称未填写！");
            return;
        }

        ZhuanTiEntity zhuanTi = ZhuanTiAccess.GetZhuanTiListById(zhuanTiId, userId);
        zhuanTi.ZhuanTiImage = zhuanTiImage;
        zhuanTi.ZhuanTiName = zhuanTiName;
        zhuanTi.UserID = userId;
        
        bool success = ZhuanTiAccess.UpdateZhuanTi(zhuanTi);
        if (success)
        {
            Utility.Alert(this, "更新成功。");

            List.EditIndex = -1;
            BindGrid();
        }
        else
        {
            Utility.Alert(this, "更新失败！");
        }
    }

    //取消操作
    protected void List_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        List.EditIndex = -1;
        BindGrid();
    }

    //更新进入操作
    protected void List_RowEditing(object sender, GridViewEditEventArgs e)
    {
        List.EditIndex = e.NewEditIndex;
        BindGrid();
    }

    //添加操作
    protected void Button1_Click(object sender, EventArgs e)
    {
        string zhuanTiImage = "";
        if (this.ZhuanTiImageIns.HasFile)
        {
            string imageExt = ImageHelper.GetImageExt(this.ZhuanTiImageIns.FileName);
            if (imageExt != ".jpg" && imageExt != ".png" && imageExt != ".bmp" && imageExt != ".gif")
            {
                Utility.Alert(this, "图片文件格式不支持！"); 
                return;
            }
            zhuanTiImage = "zt_" + userId + "_" + Utility.GetRandomNumber(1000, 9999) + imageExt;
            string imagePath = Server.MapPath("/Images/ZhuanTi/") + zhuanTiImage;
            try
            {
                this.ZhuanTiImageIns.SaveAs(imagePath);
                ImageHelper.SaveImage(imagePath, 200, 200);
            }
            catch
            {
                Utility.Alert(this, "专题图片上传失败！");
                return;
            }
        }
        else
        {
            Utility.Alert(this, "专题图片未选择！");
            return;
        }

        string zhuanTiName = this.ZhuanTiNameIns.Text.Trim();
        if (zhuanTiName == "")
        {
            Utility.Alert(this, "专题名称未填写！");
            return;
        }

        ZhuanTiEntity zhuanTi = new ZhuanTiEntity();
        zhuanTi.ZhuanTiName = zhuanTiName;
        zhuanTi.ZhuanTiImage = zhuanTiImage;
        zhuanTi.ZhuanTiLive = 1;
        zhuanTi.Synchronize = 1;
        zhuanTi.UserID = userId;

        bool success = ZhuanTiAccess.InsertZhuanTi(zhuanTi);
        if (success)
        {
            Utility.Alert(this, "添加成功。", "UserZhuanTi.aspx");
        }
        else
        {
            Utility.Alert(this, "添加失败！");
        }
    }

    //删除操作
    protected void List_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int zhuanTiId = Int32.Parse(List.DataKeys[e.RowIndex].Value.ToString());

        ZhuanTiEntity zhuanTi = ZhuanTiAccess.GetZhuanTiListById(zhuanTiId, userId);
        zhuanTi.ZhuanTiLive = 0;
        zhuanTi.Synchronize = 1;

        bool success = ZhuanTiAccess.DeleteZhuanTi(zhuanTiId, userId);
        if (success)
        {
            success = ZhuanTiAccess.UpdateZhuanTi(zhuanTi);
            if (success)
            {
                Utility.Alert(this, "删除成功。");

                List.EditIndex = -1;
                BindGrid();
            }
        }
        else
        {
            Utility.Alert(this, "删除失败！");
        }
    }

}
