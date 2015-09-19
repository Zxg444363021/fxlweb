using System.Data;
using System.Data.Common;
using System.IO;
using System.Text;

public class BackupAccess
{
    static BackupAccess()
    {
    }

    //取所有删除消费列表//
    public static DataTable BackupDeleteTable()
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "BackupDeleteTable_v4";

        return GenericDataAccess.ExecuteCommand(comm);
    }

    //备份用户表//
    public static DataTable BackupUserTable(string bakDate, string bakDate2)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "BackupUserTable_v4";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@BakDate";
        param.Value = bakDate;
        param.DbType = DbType.String;
        param.Size = 10;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@BakDate2";
        param.Value = bakDate2;
        param.DbType = DbType.String;
        param.Size = 10;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteCommand(comm);
    }

    //备份第三方登录表//
    public static DataTable BackupOAuthTable(string bakDate, string bakDate2)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "BackupOAuthTable_v4";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@BakDate";
        param.Value = bakDate;
        param.DbType = DbType.String;
        param.Size = 10;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@BakDate2";
        param.Value = bakDate2;
        param.DbType = DbType.String;
        param.Size = 10;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteCommand(comm);
    }

    //备份商品表//
    public static DataTable BackupItemTable(string bakDate, string bakDate2)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "BackupItemTable_v4";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@BakDate";
        param.Value = bakDate;
        param.DbType = DbType.String;
        param.Size = 10;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@BakDate2";
        param.Value = bakDate2;
        param.DbType = DbType.String;
        param.Size = 10;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteCommand(comm);
    }

    //备份用户类别表//
    public static DataTable BackupUserCategoryTable(string bakDate, string bakDate2)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "BackupUserCategoryTable_v4";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@BakDate";
        param.Value = bakDate;
        param.DbType = DbType.String;
        param.Size = 10;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@BakDate2";
        param.Value = bakDate2;
        param.DbType = DbType.String;
        param.Size = 10;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteCommand(comm);
    }

    //备份用户专题表//
    public static DataTable BackupZhuanTiTable(string bakDate, string bakDate2)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "BackupZhuanTiTable_v4";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@BakDate";
        param.Value = bakDate;
        param.DbType = DbType.String;
        param.Size = 10;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@BakDate2";
        param.Value = bakDate2;
        param.DbType = DbType.String;
        param.Size = 10;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteCommand(comm);
    }

    //备份钱包表//
    public static DataTable BackupCardTable(string bakDate, string bakDate2)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "BackupCardTable_v4";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@BakDate";
        param.Value = bakDate;
        param.DbType = DbType.String;
        param.Size = 10;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@BakDate2";
        param.Value = bakDate2;
        param.DbType = DbType.String;
        param.Size = 10;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteCommand(comm);
    }

    //备份商品表根据用户ID//
    public static DataTable BackupItemTableById(int userId)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "BackupItemTableById_v4";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@UserID";
        param.Value = userId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteCommand(comm);
    }

    //备份用户类别导出App//
    public static DataTable GetAdminUserCatTypeById(int userId)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "GetAdminUserCatTypeById_v4";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@UserID";
        param.Value = userId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        return GenericDataAccess.ExecuteCommand(comm);
    }

    //备份写sql文件//
    public static void WriteBackupFile(string path, string content)
    {
        if (!File.Exists(path))
        {
            FileStream fs = File.Create(path);
            fs.Close();
        }

        Encoding enc = new UTF8Encoding(false);
        StreamWriter sw = new StreamWriter(path, false, enc);
        sw.WriteLine(content.Trim());
        sw.Close();
        sw.Dispose();
    }

    //从sql文件恢复备份//
    public static void ReaderBackupFile(string path)
    {
        string dbProviderName = WebConfiguration.DbProviderName;
        string dbConnectionString = WebConfiguration.DbConnectionString;
        DbProviderFactory factory = DbProviderFactories.GetFactory(dbProviderName);
        using (DbConnection conn = factory.CreateConnection())
        {
            conn.ConnectionString = dbConnectionString;
            conn.Open();
            DbTransaction trans = conn.BeginTransaction();
            DbCommand comm = conn.CreateCommand();
            comm.Connection = conn;
            comm.Transaction = trans;

            StreamReader sr = null;
            try
            {
                sr = new StreamReader(path, Encoding.GetEncoding("utf-8"));
                string str = "";
                while ((str = sr.ReadLine()) != null)
                {
                    comm.CommandText += str + "\r\n";
                }
                comm.ExecuteNonQuery();
                trans.Commit();
            }
            catch
            {
                trans.Rollback();
                throw;
            }
            finally
            {
                sr.Close();
                conn.Close();
            }
        }
    }

    //取总统计数据//
    public static DataTable GetAdminTongJiQuanBu()
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "GetAdminTongJiQuanBu_v4";

        return GenericDataAccess.ExecuteCommand(comm);
    }

    //取活动统计数据//
    public static DataTable GetAdminTongJiHuoDong(string date, string date2)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "GetAdminTongJiHuoDong_v4";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@Date";
        param.Value = date;
        param.DbType = DbType.String;
        param.Size = 10;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@Date2";
        param.Value = date2;
        param.DbType = DbType.String;
        param.Size = 10;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteCommand(comm);
    }

    //取创建统计数据//
    public static DataTable GetAdminTongJiXinJian(string date, string date2)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "GetAdminTongJiXinJian_v4";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@Date";
        param.Value = date;
        param.DbType = DbType.String;
        param.Size = 10;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@Date2";
        param.Value = date2;
        param.DbType = DbType.String;
        param.Size = 10;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteCommand(comm);
    }

}