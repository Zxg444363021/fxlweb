using System;
using System.Data;
using System.Text;
using System.Web.UI.WebControls;
using System.IO;
using System.Web;

public partial class AdminBackupData : AdminPage
{
    private string filePath = "";
    private string fileName = "";
        
    protected void Page_Load(object sender, EventArgs e)
    {
        filePath = Server.MapPath("Backup") + System.IO.Path.DirectorySeparatorChar;

        if (!IsPostBack)
        {
            this.BakDateBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            this.BakDateBox2.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }
    }

    //备份数据//
    protected void Button2_Command(object sender, CommandEventArgs e)
    {
        string bakDate = this.BakDateBox.Text.Trim();
        string bakDate2 = this.BakDateBox2.Text.Trim();

        string type = e.CommandArgument.ToString();
        fileName = bakDate + "~" + bakDate2 + "-bak.sql";
        if (type == "mysql")
        {
            fileName = "mysql-" + fileName;
        }

        StringBuilder sb = new StringBuilder();
        
        DataTable itemListTab = BackupAccess.BackupItemTable(bakDate, bakDate2);
        if (itemListTab.Rows.Count > 0)
        {
            sb.AppendLine("--备份消费表");
            sb.Append("DELETE FROM ItemTable WHERE ItemID IN (");
            foreach (DataRow dr in itemListTab.Rows)
            {
                sb.Append(dr["ItemID"].ToString() + ",");
            }
            sb.Remove(sb.Length - 1, 1);
            sb.AppendLine(")");

            if (type == "mssql")
            {
                sb.AppendLine("SET IDENTITY_INSERT ItemTable ON");
            }
            foreach (DataRow dr in itemListTab.Rows)
            {
                sb.AppendLine("INSERT INTO ItemTable (ItemID, ItemType, ItemName, CategoryTypeID, ItemPrice, ItemBuyDate, UserID, ModifyDate, Recommend, Synchronize, RegionID, RegionType, ZhuanTiID, CardID) VALUES (" +
                                dr["ItemID"].ToString() + ", '" +
                                dr["ItemType"].ToString() + "', '" +
                                Utility.ReplaceString(dr["ItemName"].ToString()) + "', '" +
                                dr["CategoryTypeID"].ToString() + "', '" +
                                dr["ItemPrice"].ToString() + "', '" +
                                String.Format("{0:yyyy-MM-dd HH:mm:ss}", dr["ItemBuyDate"].ToString()) + "', '" +
                                dr["UserID"].ToString() + "', '" +
                                String.Format("{0:yyyy-MM-dd HH:mm:ss}", dr["ModifyDate"].ToString()) + "', '" +
                                dr["Recommend"].ToString() + "', '" +
                                dr["Synchronize"].ToString() + "', '" +
                                dr["RegionID"].ToString() + "', '" +
                                dr["RegionType"].ToString() + "', '" +
                                dr["ZhuanTiID"].ToString() + "', '" +
                                dr["CardID"].ToString() + "')");
            }
            if (type == "mssql")
            {
                sb.AppendLine("SET IDENTITY_INSERT ItemTable OFF");
            }
            sb.AppendLine("");
        }

        DataTable userCatTypeListTab = BackupAccess.BackupUserCategoryTable(bakDate, bakDate2);
        if (userCatTypeListTab.Rows.Count > 0)
        {
            sb.AppendLine("--备份类别表");
            sb.Append("DELETE FROM UserCategoryTable WHERE UserCategoryID IN (");
            foreach (DataRow dr in userCatTypeListTab.Rows)
            {
                sb.Append(dr["UserCategoryID"].ToString() + ",");
            }
            sb.Remove(sb.Length - 1, 1);
            sb.AppendLine(")");

            if (type == "mssql")
            {
                sb.AppendLine("SET IDENTITY_INSERT UserCategoryTable ON");
            }
            foreach (DataRow dr in userCatTypeListTab.Rows)
            {
                sb.AppendLine("INSERT INTO UserCategoryTable (UserCategoryID, CategoryTypeName, CategoryTypePrice, UserID, CategoryTypeID, Synchronize, CategoryTypeLive, ModifyDate) VALUES (" +
                                dr["UserCategoryID"].ToString() + ", '" +
                                Utility.ReplaceString(dr["CategoryTypeName"].ToString()) + "', '" +
                                dr["CategoryTypePrice"].ToString() + "', '" +
                                dr["UserID"].ToString() + "', '" +
                                dr["CategoryTypeID"].ToString() + "', '" +
                                dr["Synchronize"].ToString() + "', '" +
                                dr["CategoryTypeLive"].ToString() + "', '" +
                                String.Format("{0:yyyy-MM-dd HH:mm:ss}", dr["ModifyDate"].ToString()) + "')");
            }
            if (type == "mssql")
            {
                sb.AppendLine("SET IDENTITY_INSERT UserCategoryTable OFF");
            }
            sb.AppendLine("");
        }

        DataTable zhuanTiListTab = BackupAccess.BackupZhuanTiTable(bakDate, bakDate2);
        if (zhuanTiListTab.Rows.Count > 0)
        {
            sb.AppendLine("--备份专题表");
            sb.Append("DELETE FROM ZhuanTiTable WHERE ZhuanTiID IN (");
            foreach (DataRow dr in zhuanTiListTab.Rows)
            {
                sb.Append(dr["ZhuanTiID"].ToString() + ",");
            }
            sb.Remove(sb.Length - 1, 1);
            sb.AppendLine(")");

            if (type == "mssql")
            {
                sb.AppendLine("SET IDENTITY_INSERT ZhuanTiTable ON");
            }
            foreach (DataRow dr in zhuanTiListTab.Rows)
            {
                sb.AppendLine("INSERT INTO ZhuanTiTable (ZhuanTiID, ZhuanTiName, UserID, ZTID, ZhuanTiImage, Synchronize, ZhuanTiLive, ModifyDate) VALUES (" +
                                dr["ZhuanTiID"].ToString() + ", '" +
                                Utility.ReplaceString(dr["ZhuanTiName"].ToString()) + "', '" +
                                dr["UserID"].ToString() + "', '" +
                                dr["ZTID"].ToString() + "', '" +
                                dr["ZhuanTiImage"].ToString() + "', '" +
                                dr["Synchronize"].ToString() + "', '" +
                                dr["ZhuanTiLive"].ToString() + "', '" +
                                String.Format("{0:yyyy-MM-dd HH:mm:ss}", dr["ModifyDate"].ToString()) + "')");
            }
            if (type == "mssql")
            {
                sb.AppendLine("SET IDENTITY_INSERT ZhuanTiTable OFF");
            }
            sb.AppendLine("");
        }

        DataTable cardListTab = BackupAccess.BackupCardTable(bakDate, bakDate2);
        if (cardListTab.Rows.Count > 0)
        {
            sb.AppendLine("--备份钱包表");
            sb.Append("DELETE FROM CardTable WHERE CardID IN (");
            foreach (DataRow dr in cardListTab.Rows)
            {
                sb.Append(dr["CardID"].ToString() + ",");
            }
            sb.Remove(sb.Length - 1, 1);
            sb.AppendLine(")");

            if (type == "mssql")
            {
                sb.AppendLine("SET IDENTITY_INSERT CardTable ON");
            }
            foreach (DataRow dr in cardListTab.Rows)
            {
                sb.AppendLine("INSERT INTO CardTable (CardID, CardName, UserID, CDID, CardMoney, CardNumber, CardImage, Synchronize, CardLive, ModifyDate) VALUES (" +
                                dr["CardID"].ToString() + ", '" +
                                Utility.ReplaceString(dr["CardName"].ToString()) + "', '" +
                                dr["UserID"].ToString() + "', '" +
                                dr["CDID"].ToString() + "', '" +
                                dr["CardMoney"].ToString() + "', '" +
                                dr["CardNumber"].ToString() + "', '" +
                                dr["CardImage"].ToString() + "', '" +
                                dr["Synchronize"].ToString() + "', '" +
                                dr["CardLive"].ToString() + "', '" +
                                String.Format("{0:yyyy-MM-dd HH:mm:ss}", dr["ModifyDate"].ToString()) + "')");
            }
            if (type == "mssql")
            {
                sb.AppendLine("SET IDENTITY_INSERT CardTable OFF");
            }
            sb.AppendLine("");
        }

        DataTable oauthListTab = BackupAccess.BackupOAuthTable(bakDate, bakDate2);
        if (oauthListTab.Rows.Count > 0)
        {
            sb.AppendLine("--备份授权表");
            sb.Append("DELETE FROM OAuthTable WHERE OAuthID IN (");
            foreach (DataRow dr in oauthListTab.Rows)
            {
                sb.Append(dr["OAuthID"].ToString() + ",");
            }
            sb.Remove(sb.Length - 1, 1);
            sb.AppendLine(")");

            if (type == "mssql")
            {
                sb.AppendLine("SET IDENTITY_INSERT OAuthTable ON");
            }
            foreach (DataRow dr in oauthListTab.Rows)
            {
                sb.AppendLine("INSERT INTO OAuthTable (OAuthID, OpenID, AccessToken, UserID, OldUserID, OAuthBound, OAuthFrom, ModifyDate) VALUES (" +
                                dr["OAuthID"].ToString() + ", '" +
                                dr["OpenID"].ToString() + "', '" +
                                dr["AccessToken"].ToString() + "', '" +
                                dr["UserID"].ToString() + "', '" +
                                dr["OldUserID"].ToString() + "', '" +
                                dr["OAuthBound"].ToString() + "', '" +
                                dr["OAuthFrom"].ToString() + "', '" +
                                String.Format("{0:yyyy-MM-dd HH:mm:ss}", dr["ModifyDate"].ToString()) + "')");
            }
            if (type == "mssql")
            {
                sb.AppendLine("SET IDENTITY_INSERT OAuthTable OFF");
            }
            sb.AppendLine("");
        }

        DataTable userListTab = BackupAccess.BackupUserTable(bakDate, bakDate2);
        if (userListTab.Rows.Count > 0)
        {
            sb.AppendLine("--备份用户表");
            sb.Append("DELETE FROM UserTable WHERE UserID IN (");
            foreach (DataRow dr in userListTab.Rows)
            {
                sb.Append(dr["UserID"].ToString() + ",");
            }
            sb.Remove(sb.Length - 1, 1);
            sb.AppendLine(")");

            if (type == "mssql")
            {
                sb.AppendLine("SET IDENTITY_INSERT UserTable ON");
            }
            foreach (DataRow dr in userListTab.Rows)
            {
                sb.AppendLine("INSERT INTO UserTable (UserID, UserName, UserPassword, UserNickName, UserImage, UserCity, UserMoney, UserWorkDay, CategoryRate, UserFunction, CreateDate, ModifyDate, UserPhone, UserEmail, UserTheme, UserLevel, UserFrom) VALUES (" +
                                dr["UserID"].ToString() + ", '" +
                                Utility.ReplaceString(dr["UserName"].ToString()) + "', '" +
                                Utility.ReplaceString(dr["UserPassword"].ToString()) + "', '" +
                                Utility.ReplaceString(dr["UserNickName"].ToString()) + "', '" +
                                dr["UserImage"].ToString() + "', '" +
                                dr["UserCity"].ToString() + "', '" +
                                dr["UserMoney"].ToString() + "', '" +
                                dr["UserWorkDay"].ToString() + "', '" +
                                dr["CategoryRate"].ToString() + "', '" +
                                dr["UserFunction"].ToString() + "', '" +
                                String.Format("{0:yyyy-MM-dd HH:mm:ss}", dr["CreateDate"]) + "', '" +
                                String.Format("{0:yyyy-MM-dd HH:mm:ss}", dr["ModifyDate"]) + "', '" +
                                dr["UserPhone"].ToString() + "', '" +
                                dr["UserEmail"].ToString() + "', '" +
                                dr["UserTheme"].ToString() + "', '" +
                                dr["UserLevel"].ToString() + "', '" +
                                dr["UserFrom"].ToString() + "')");
            }
            if (type == "mssql")
            {
                sb.AppendLine("SET IDENTITY_INSERT UserTable OFF");
            }
            sb.AppendLine("");
        }

        DataTable delListTab = BackupAccess.BackupDeleteTable();
        if (delListTab.Rows.Count > 0)
        {
            sb.AppendLine("--备份删除表");
            int index = 0;
            sb.Append("DELETE FROM ItemTable WHERE ItemID IN (");
            foreach (DataRow dr in delListTab.Rows)
            {
                index++;
                sb.Append(dr["ItemID"].ToString());
                if (index != delListTab.Rows.Count)
                {
                    sb.Append(", ");
                }
            }
            sb.Append(")");
        }

        BackupAccess.WriteBackupFile(filePath + fileName, sb.ToString());
        DownBackFile();
    }

    //恢复数据//
    protected void Button4_Click(object sender, EventArgs e)
    {
        string bakDate = this.BakDateBox.Text.Trim();
        string bakDate2 = this.BakDateBox2.Text.Trim();

        fileName = bakDate + "~" + bakDate2 + "-bak.sql";
        if (!File.Exists(filePath + fileName))
        {
            Utility.Alert(this, "文件不存在！（" + fileName + "）");
            return;
        }

        try 
        {
            BackupAccess.ReaderBackupFile(filePath + fileName);
            Utility.Alert(this, "恢复成功。");
        }
        catch
        {
            Utility.Alert(this, "恢复失败！");
            return;
        }
    }

    //导出数据到App//
    protected void Button1_Click(object sender, EventArgs e)
    {
        int userId = Int32.Parse(Session["UserID"].ToString());
        fileName = "aalife2.bak";

        StringBuilder sb = new StringBuilder();

        DataTable itemListTab = BackupAccess.BackupItemTableById(userId);
        if (itemListTab.Rows.Count > 0)
        {
            sb.AppendLine("DELETE FROM ItemTable;");
            foreach (DataRow dr in itemListTab.Rows)
            {
                sb.AppendLine("INSERT INTO ItemTable (ItemType, ItemName, ItemPrice, ItemBuyDate, CategoryID, Recommend, Synchronize, RegionID, RegionType, ZhuanTiID, CardID) VALUES ('" +
                                dr["ItemType"].ToString() + "', '" + 
                                dr["ItemName"].ToString() + "', '" +
                                dr["ItemPrice"].ToString() + "', '" +
                                String.Format("{0:yyyy-MM-dd}", dr["ItemBuyDate"]) + "', '" +
                                dr["CategoryTypeID"].ToString() + "', '" +
                                dr["Recommend"].ToString() + "', '0', '" +
                                dr["RegionID"].ToString() + "', '" +
                                dr["RegionType"].ToString() + "', '" +
                                dr["ZhuanTiID"].ToString() + "', '" +
                                dr["CardID"].ToString() + "');");
            }
            sb.AppendLine("");
        }

        DataTable catListTab = UserCategoryAccess.GetCategoryTypeList(userId);
        if (catListTab.Rows.Count > 0)
        {
            sb.AppendLine("DELETE FROM CategoryTable;");
            foreach (DataRow dr in catListTab.Rows)
            {
                sb.AppendLine("INSERT INTO CategoryTable (CategoryID, CategoryName, CategoryPrice, CategoryRank, CategoryDisplay, CategoryLive) VALUES ('" +
                                dr["CategoryTypeID"].ToString() + "', '" +
                                dr["CategoryTypeName"].ToString() + "', '" +
                                dr["CategoryTypePrice"].ToString() + "', '" +
                                dr["CategoryTypeID"].ToString() + "', '1', '1');");
            }
            sb.AppendLine("");
        }

        DataTable zhuanTiTab = ZhuanTiAccess.GetZhuanTiList(userId);
        if (zhuanTiTab.Rows.Count > 0)
        {
            sb.AppendLine("DELETE FROM ZhuanTiTable;");
            foreach (DataRow dr in zhuanTiTab.Rows)
            {
                sb.AppendLine("INSERT INTO ZhuanTiTable (ZTID, ZhuanTiName, ZhuanTiImage, ZhuanTiLive, Synchronize) VALUES ('" +
                                dr["ZTID"].ToString() + "', '" +
                                dr["ZhuanTiName"].ToString() + "', '" +
                                dr["ZhuanTiImage"].ToString() + "', '" +
                                dr["ZhuanTiLive"].ToString() + "', '0');");
            }
            sb.AppendLine("");
        }

        DataTable cardTab = CardAccess.GetCardList(userId);
        if (cardTab.Rows.Count > 0)
        {
            sb.AppendLine("DELETE FROM CardTable;");
            foreach (DataRow dr in cardTab.Rows)
            {
                if (dr["CardID"].ToString() == "0") 
                { 
                    continue; 
                }
                sb.AppendLine("INSERT INTO CardTable (CDID, CardName, CardMoney, CardLive, Synchronize) VALUES ('" +
                                dr["CardID"].ToString() + "', '" +
                                dr["CardName"].ToString() + "', '" +
                                dr["CardMoney"].ToString() + "', '" +
                                dr["CardLive"].ToString() + "', '0');");
            }
        }

        BackupAccess.WriteBackupFile(filePath + fileName, sb.ToString());

        //Utility.Alert(this, "导出成功。");

        DownBackFile();
    }

    //下载备份//
    protected void DownBackFile()
    {
        FileStream fileStream = new FileStream(filePath + fileName, FileMode.Open);
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

}