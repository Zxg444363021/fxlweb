using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// CreateSQLBusiness 的摘要说明
/// </summary>
public class CreateSQLBusiness
{
	public CreateSQLBusiness()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}

    //根据SQL返回数据集
    public static DataTable GetDataFromSQL(string sqlStr)
    {
        string connStr = ConfigurationManager.AppSettings["conn"];
        SqlConnection conn = new SqlConnection(connStr);

        DataTable dt = new DataTable();
        try
        {
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            conn.Open();

            command.CommandText = sqlStr;
            SqlDataReader sdr = command.ExecuteReader();
            dt.Load(sdr);
        }
        catch { }
        finally { conn.Close(); }

        return dt;
    }

    //取表列头
    public static DataTable GetTabColumn(string tabName, string isFirst)
    {
        string sqlStr = "select name from syscolumns where id=object_id('[" + tabName + "]')";
        DataTable dt = GetDataFromSQL(sqlStr);
        try
        {
            if (isFirst == "n") dt.Rows.RemoveAt(0);
        }
        catch { }

        return dt;
    }

    //取SQL语句
    public static string CreateSQL(string tabName, List<List<string>> lists, string[] qryArr)
    {
        List<string> names = lists[0];
        string insert = GetInsertSql(tabName, names);

        StringBuilder sql = new StringBuilder();
        for (int i = 1; i < lists.Count; i++)
        {
            List<string> list = lists[i];
            int n = 0;

            sql.Append(GetExistsSql(tabName, qryArr, list));
            sql.Append(insert);
            sql.Append("  values (<br />");
            foreach (string str in list)
            {
                Guid g = Guid.Empty;
                string dot = (n == list.Count - 1 ? "" : ",");
                if (str == null || str.Trim() == "")
                {
                    sql.Append("  null");
                }
                else if(Guid.TryParse(str, out g))
                //else if (str.Trim() == "newid()")
                {
                    sql.Append("  newid()");
                }
                else
                {
                    sql.Append("  '" + str + "'");
                }
                sql.Append(dot + " --" + names[n] + "<br />");
                n++;
            }
            sql.Append("  )<br />");
            sql.Append("go<br /><br />");
        }

        return sql.ToString();
    }

    //插入字段
    private static string GetInsertSql(string tabName, List<string> list)
    {
        StringBuilder insert = new StringBuilder();

        insert.Append("  insert into " + tabName + " (");
        foreach (string name in list)
        {
            insert.Append(name + ",");
        }
        insert.Remove(insert.Length - 1, 1);
        insert.Append(")<br />");

        return insert.ToString();
    }

    //插入判断
    private static string GetExistsSql(string tabName, string[] strs, List<string> list)
    {
        StringBuilder exists = new StringBuilder();

        string qryStr = " where " + strs[0] + "='" + list[Int32.Parse(strs[1])] + "'";
        if (strs.Length >= 4)
        {
            qryStr += " and " + strs[2] + "='" + list[Int32.Parse(strs[3])] + "'";
        }
        if (strs.Length >= 6)
        {
            qryStr += " and " + strs[4] + "='" + list[Int32.Parse(strs[5])] + "'";
        }

        exists.Append("if not exists (select * from " + tabName + qryStr + ")<br />");

        return exists.ToString();
    }

    //取表所有字段
    public static List<List<string>> GetAllData(List<List<string>> lists, string tabName, string isFirst)
    {
        //取列头
        DataTable dt = GetTabColumn(tabName, isFirst);

        string[,] strArr = new string[lists.Count, dt.Rows.Count];
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            string name = dt.Rows[i][0].ToString();
            try
            {
                string item = lists[0][i];
                if (name == item)
                {
                    continue;
                }
                else
                {
                    throw new Exception();
                }
            }
            catch
            {
                lists[0].Insert(i, name);
                InsertDataEmpty(lists, i, name);
            }
        }

        return lists;
    }

    //插入空值列
    private static void InsertDataEmpty(List<List<string>> lists, int idx, string name)
    {
        for (int i = 1; i < lists.Count; i++)
        {
            string obj = "";
            switch (name)
            {
                case "SystemCode":
                    obj = "RMS";
                    break;
                case "MnuClassGuid":
                case "ContextMenuGuid":
                    obj = Guid.NewGuid().ToString();
                    break;
                default:
                    obj = "";
                    break;

            }
            lists[i].Insert(idx, obj);
        }
    }

}