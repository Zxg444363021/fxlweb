using System.Data;
using System.Data.Common;
using System.IO;
using System.Text;

public class BackupHelper
{
    static BackupHelper()
    {
    }
    
    //备份写sql文件
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

    //从sql文件恢复备份
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
    
}