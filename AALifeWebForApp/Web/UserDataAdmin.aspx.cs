using System;
using System.Data;
using System.Web;
using System.IO;
using Aspose.Cells;
using System.Data.Common;
using System.Text;

public partial class UserDataAdmin : BasePage
{
    private int userId = 0;
    private DataTable all = null;
    private DataTable catTypeList;

    protected void Page_Load(object sender, EventArgs e)
    {
        userId = Int32.Parse(Session["UserID"].ToString());
    }
    
    //导出数据
    protected void Button2_Click(object sender, EventArgs e)
    {
        DataTable dt = UserAccess.ExportUserData(userId);
        string fileName = "AA生活记账数据导出(" + userId + ").xlsx";
        string savePath = Server.MapPath("/Backup/Export/") + fileName;

        try
        {
            AsposeExport(dt, savePath);
            DownExcel(savePath, fileName);
        }
        catch 
        {
            Utility.Alert(this, "数据导出错误！");
        }
    }
    
    //导出下载
    protected void DownExcel(string filePath, string fileName)
    {
        FileStream fileStream = new FileStream(filePath, FileMode.Open);
        long fileSize = fileStream.Length;
        Context.Response.ContentType = "application/octet-stream";
        //中文文件名需要UTF8编码
        Context.Response.AddHeader("Content-Disposition", "attachment; filename=\"" + HttpUtility.UrlEncode(fileName, System.Text.Encoding.UTF8) + "\"");
        Context.Response.AddHeader("Content-Length", fileSize.ToString());
        byte[] fileBuffer = new byte[fileSize];
        fileStream.Read(fileBuffer, 0, (int)fileSize);
        fileStream.Close();
        Context.Response.BinaryWrite(fileBuffer);
        Context.Response.End();
    }

    //Aspose导出
    protected void AsposeExport(DataTable dt, string savePath)
    {
        Workbook workbook = new Workbook();
        Worksheet sheet = workbook.Worksheets[0];
        Cells cells = sheet.Cells;

        Aspose.Cells.Style styleTitle = workbook.Styles[workbook.Styles.Add()];
        styleTitle.Font.IsBold = true;

        int colnums = dt.Columns.Count;
        int rownums = dt.Rows.Count;

        for (int i = 0; i < colnums; i++)
        {
            cells[0, i].PutValue(dt.Columns[i].ColumnName);
            cells[0, i].SetStyle(styleTitle);
            cells.SetColumnWidth(i, 15);
        }

        for (int i = 0; i < rownums; i++)
        {
            for (int j = 0; j < colnums; j++)
            {
                cells[1 + i, j].PutValue(dt.Rows[i][j].ToString());
            }
        }

        workbook.Save(savePath);
    }
    
    //导入数据
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (this.FileUpload1.HasFile == false)
        {
            Utility.Alert(this, "请选择导入的Excel文件！");
            return;
        }
        string fileName = FileUpload1.FileName;
        string fileExt = System.IO.Path.GetExtension(fileName).ToString().ToLower();
        if (fileExt != ".xls" && fileExt != ".xlsx")
        {
            Utility.Alert(this, "只可以导入Excel文件！");
            return;
        }

        fileName = "(" + userId + ")" + fileName;
        string savePath = Server.MapPath("/Backup/Import/") + fileName;
        FileUpload1.SaveAs(savePath);
        DataTable dt = AsposeImport(savePath);

        if (dt.Rows.Count > 0)
        {
            try
            {
                if (!CheckExcel(dt))
                {
                    Utility.Alert(this, "导入的模板文件错误！");
                    return;
                }

                int[] arr = new int[2];
                arr = SaveExcel(dt);
                Utility.Alert(this, string.Format("成功导入 {0} 条，重复的 {1} 条。", arr[0], arr[1]));
            }
            catch
            {
                Utility.Alert(this, "导入失败！");
                return;
            }
        }
        else
        {
            Utility.Alert(this, "没有要导入的数据！");
        }
    }

    //检查Excel文件
    protected bool CheckExcel(DataTable dt)
    {
        return dt.Columns.Contains("分类") && dt.Columns.Contains("商品名称") && dt.Columns.Contains("商品类别") && dt.Columns.Contains("商品价格") && dt.Columns.Contains("购买日期") && dt.Columns.Contains("推荐否");
    }

    //Aspose导入
    protected DataTable AsposeImport(string filePath)
    {
        Workbook workbook = new Workbook(filePath);
        Worksheet sheet = workbook.Worksheets[0];
        Cells cells = sheet.Cells;

        return cells.ExportDataTableAsString(0, 0, cells.MaxDataRow + 1, 6, true);
    }

    //导入保存
    protected int[] SaveExcel(DataTable dt)
    {
        int[] arr = new int[2];
        all = UserAccess.ExportUserData(userId);

        catTypeList = UserCategoryAccess.GetCategoryTypeList(userId);

        string dbProviderName = WebConfiguration.DbProviderName;
        string dbConnectionString = WebConfiguration.DbConnectionString;
        DbProviderFactory factory = DbProviderFactories.GetFactory(dbProviderName);
        using (DbConnection conn = factory.CreateConnection())
        {
            conn.ConnectionString = dbConnectionString;
            conn.Open();
            DbTransaction tran = conn.BeginTransaction();
            DbCommand comm = conn.CreateCommand();
            comm.Connection = conn;
            comm.Transaction = tran;

            try
            {
                int n1 = 0;
                int n2 = 0;
                StringBuilder sb = new StringBuilder();
                foreach (DataRow dr in dt.Rows)
                {
                    string _itemType = GetItemTypeValue(dr["分类"].ToString());
                    string _itemName = dr["商品名称"].ToString();
                    int _catTypeId = GetCategoryTypeId(dr["商品类别"].ToString(), catTypeList);
                    string _itemPrice = dr["商品价格"].ToString();
                    DateTime _itemBuyDate = DateTime.Parse(dr["购买日期"].ToString());
                    int _recommend = (dr["推荐否"].ToString() == "否" ? 0 : 1);

                    ItemEntity item = new ItemEntity();
                    item.ItemType = _itemType;
                    item.ItemName = _itemName;
                    item.CategoryTypeID = _catTypeId;
                    item.ItemPrice = (_itemPrice== "" ? 0 : Double.Parse(_itemPrice));
                    item.ItemBuyDate = _itemBuyDate;
                    item.Recommend = _recommend;

                    if (CheckRepeat(item, catTypeList))
                    {
                        n2++;
                        continue;
                    }
                    sb.AppendLine("INSERT INTO ItemTable(ItemType, ItemName, CategoryTypeID, ItemPrice, ItemBuyDate, UserID, Recommend) VALUES('" +
                                   item.ItemType + "','" + item.ItemName + "','" + item.CategoryTypeID + "','" + item.ItemPrice + "','" +
                                   item.ItemBuyDate.ToString("yyyy-MM-dd") + " " + DateTime.Now.ToString("HH:mm:ss") + "','" + userId + "','" + item.Recommend + "');");
                    n1++;
                }
                
                arr[0] = n1;
                arr[1] = n2;
                if (sb.ToString() == "") return arr;

                comm.CommandText = sb.ToString();
                comm.ExecuteNonQuery();
                tran.Commit();
            }
            catch
            {
                tran.Rollback();
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        return arr;
    }

    //检查数据重复
    protected bool CheckRepeat(ItemEntity _item, DataTable catList)
    {
        foreach (DataRow dr in all.Rows)
        {
            string _itemName = dr["商品名称"].ToString();
            DateTime _itemBuyDate = DateTime.Parse(dr["购买日期"].ToString());
            int _recommend = (dr["推荐否"].ToString() == "否" ? 0 : 1);

            ItemEntity item = new ItemEntity();
            item.ItemName = _itemName;
            item.ItemBuyDate = _itemBuyDate;
            item.Recommend = _recommend;

            if (item.Equals(_item))
            {
                return true;
            } 
        }

        return false;
    }

    //取类别ID
    protected int GetCategoryTypeId(string name, DataTable dt)
    {
        foreach (DataRow dr in dt.Rows)
        {
            if (name == dr["CategoryTypeName"].ToString())
            {
                return Int32.Parse(dr["CategoryTypeID"].ToString());
            }
        }

        UserCategoryEntity userCat = new UserCategoryEntity();
        userCat.CategoryTypeName = name;
        userCat.UserID = userId;
        userCat.CategoryTypeLive = 1;
        userCat.Synchronize = 1;

        int catTypeId = 0;
        bool success = UserCategoryAccess.InsertCategoryType(userCat, out catTypeId);
        if (!success)
        {
            throw new Exception();
        }

        return catTypeId;
    }
    
    //取支出收入分类
    protected string GetItemTypeValue(string name)
    {
        string value = "zc";
        switch (name)
        {
            case "支出":
                value = "zc";
                break;
            case "收入":
                value = "sr";
                break;
            case "借出":
                value = "jc";
                break;
            case "还入":
                value = "hr";
                break;
            case "借入":
                value = "jr";
                break;
            case "还出":
                value = "hc";
                break;
        }

        return value;
    }
}
