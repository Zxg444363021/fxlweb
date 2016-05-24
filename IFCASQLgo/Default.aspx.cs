using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Web.Services;

public partial class _default : System.Web.UI.Page
{
    public string result = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        /*
        * id: 名称
        * tab: 表
        * strs: exists数组
        * isFirst: 是否生成第1字段(id字段)，y：生成，n：不生成
        * 说明：位置从除去id字段，从0开始数
        */

        CreateHtml("string", "CF_String", new string[]{ "StringCode", "2" }, "n");
        CreateHtml("menu", "Sys_Menu", new string[]{ "MnuNo", "3", "MnuSystem", "0" }, "n");
        CreateHtml("contextmenuclass", "Sys_ContextMenuClass", new string[]{ "MnuClass", "0" }, "y");
        CreateHtml("contextmenu", "Sys_ContextMenu", new string[]{ "MnuClass", "1", "ContextMnuNo", "0", "MnuNo", "2" }, "n");
        CreateHtml("base", "Sys_Base", new string[]{ "BseNo", "1" }, "n");
        CreateHtml("basedt", "Sys_BaseDt", new string[]{ "BdtBseNo", "0", "BdtFldName", "1" }, "n");
        CreateHtml("list", "Sys_List", new string[]{ "LstNo", "0", "LstBseNo", "6", "LstOrder", "1" }, "n");
        CreateHtml("listdt", "Sys_ListDt", new string[]{ "LdtLstNo", "0", "LdtFldName", "2", "LdtLstOrder", "1" }, "n");
        CreateHtml("filter", "Sys_Filter", new string[]{ "FltLstNo", "1", "FltName", "21" }, "n");
        CreateHtml("tab", "Sys_Tab", new string[]{ "TabNo", "0", "TabBseNo", "2" }, "n");
        CreateHtml("tabdt", "Sys_TabDt", new string[]{ "TdtTabNo", "1", "TdtFldName", "3" }, "n");
        CreateHtml("tabclass", "Sys_TabClass", new string[]{ "TcsTabNo", "0", "TcsNo", "1" }, "n");
        CreateHtml("tabcard", "Sys_TabCard", new string[]{ "TcdCardNo", "1", "TcdTabNo", "0" }, "n");
        CreateHtml("select", "Sys_Select", new string[]{ "SelNo", "0" }, "n");
        CreateHtml("popuplst", "CF_PopupLst", new string[]{ "Type", "4" }, "n");
        CreateHtml("popuplstelement", "CF_PopupLstElement", new string[]{ "PopType", "17", "ElementCode", "5" }, "n");
        CreateHtml("report", "Sys_Report", new string[]{ "ReportNo", "0" }, "y");
        CreateHtml("reportfilter", "Sys_ReportFilter", new string[]{ "ReportNo", "0", "FldName", "2" }, "n");
        //不需要配置，由报表模板配置。CreateHtml("reportdefine", "Sys_ReportDefine", new string[]{ "ReportNo", "3" }, "n");
        //不明，貌似是旧版。CreateHtml("workflowentity", "OA_WorkflowEntity", new string[]{ "EntiInterface", "2" }, "n");
        CreateHtml("wfentity", "WF_Entity", new string[]{ "EntiName", "2" }, "y");
        CreateHtml("lettertype", "CF_LetterType", new string[]{ "LetterTypeID", "0", "LetterName", "2" }, "y");
        CreateHtml("lettersubtable", "CF_LetterSubTable", new string[]{ "LetterTypeID", "0", "BseNo", "2" }, "n");
        CreateHtml("countrylettertyperelate", "CF_CountryLetterTypeRelate", new string[]{ "LetterTypeID", "1", "CountryID", "0" }, "n");
        //由菜单模板配置。CreateHtml("menudefine", "Sys_MenuDefine", new string[]{ "MdfNo", "3", "MdfSystem", "1" }, "n");
        CreateHtml("importtype", "Sys_ImportType", new string[]{ "ImportType", "0" }, "y");
        CreateHtml("importtypedetail", "Sys_ImportTypeDetail", new string[] { "ImportType", "0", "FldName", "1" }, "y");
        CreateHtml("showfields", "Sys_ShowFields", new string[] { "ShwNo", "0", "ShwType", "1", "ShwFldName", "2" }, "n");
        CreateHtml("alerttype", "Sys_AlertType", new string[] { "AlertTypeName", "0", "ApplicationCode", "1" }, "y");
        CreateHtml("alertitemquery", "Sys_AlertItemQuery", new string[] { "AlertTypeName", "0" }, "y");
        CreateHtml("mapconfig", "Sys_MapConfig", new string[] { "MapNo", "2", "ElementType", "3", "ElementStringCode", "6" }, "n");
        CreateHtml("doccode", "CF_DocCode", new string[] { "DocCodeNo", "1", "ApplicationID", "0" }, "n");

    }

    //创建界面
    private void CreateHtml(string id, string tabName, string[] strs, string isFirst)
    {
        //取表列头
        DataTable dt = CreateSQLBusiness.GetTabColumn(tabName, isFirst);

        StringBuilder sb = new StringBuilder();
        StringBuilder sb_input = new StringBuilder();
        sb.Append("<div><a href=\"javascript:void(0)\" onclick=\"f_expand('#" + id + "',this)\">+ " + id.ToUpper() + "</a></div>");
        sb.Append("<div id=\"" + id + "\" class=\"main\">");
        sb.Append("<fieldset>");
        sb.Append("<legend>" + tabName + "</legend>");
        sb.Append("<div class=\"txtdata autoscroll\">");
        sb.Append("<p>" + strs[0] + " <input type=\"checkbox\" id=\"" + id + "like\" class=\"like\" style=\"width:18px;\" />Like <input id=\"" + id + "search\" type=\"input\" class=\"searchtxt\" style=\"width:100px;border:1px solid #999;\" />&nbsp;");
        sb.Append("<input id=\"submit\" type=\"button\" onclick=\"f_search('#" + id + "','" + tabName + "','" + strs[0] + "','" + isFirst + "')\" value=\"查找\" class=\"btncss\" />&nbsp;&nbsp;<img src='common/loading.gif' class='imgcss' style='vertical-align:middle;display:none;' /></p>");
        sb.Append("</div>");
        sb.Append("<div class=\"txtmain autoscroll\">");
        sb.Append("<table border=\"1\" width=\"1\" class=\"tabadd\">");
        sb.Append("<tr>");
        sb_input.Append("<tr class=\"datarow\">");
        foreach (DataRow dr in dt.Rows)
        {
            sb.Append("<td class=\"th\"><pre>" + dr["name"].ToString() + "</pre></td>");
            sb_input.Append("<td><input type=\"text\" id=\"" + dr["name"].ToString() + "\" value=\"\" autocomplete=\"off\" /></td>");
        }
        sb.Append("</tr>");
        sb_input.Append("</tr>");
        sb.Append(sb_input);
        sb.Append("</table>");        
        sb.Append("</div>");
        sb.Append("<div class=\"txtsql autoscroll\"></div>");
        sb.Append("<input id=\"" + id + "add\" type=\"button\" onclick=\"f_add('#" + id + "')\" value=\"加行\" class=\"btncss\" />&nbsp;");
        sb.Append("<input id=\"" + id + "del\" type=\"button\" onclick=\"f_del('#" + id + "')\" value=\"减行\" class=\"btncss\" />&nbsp;");
        sb.Append("<input id=\"" + id + "go\" type=\"button\" onclick=\"f_sqlgo('#" + id + "','" + tabName + "','" + String.Join(",", strs) + "')\" value=\"生成\" class=\"btncss\" />&nbsp;");
        sb.Append("<input id=\"" + id + "copy\" type=\"button\" onclick=\"f_copy('#" + id + "')\" value=\"复制\" class=\"btncss\" />");
        sb.Append("<input id=\"" + id + "_hidcount\" type=\"hidden\" value=\"0\" />");
        sb.Append("</fieldset>");
        sb.Append("</div>");

        result += sb.ToString();
    }

    //生成SQL
    [WebMethod(EnableSession = true)]
    public static string CreateSQL(string tabName, List<List<string>> lists, List<string> qryArr)
    {
        //调用业务类方法
        return CreateSQLBusiness.CreateSQL(tabName, lists, qryArr.ToArray());
    }
    
    //搜索
    [WebMethod(EnableSession = true)]
    public static string GetTable(string id, string tabName, string str1, string val1, string isFirst, string isLike)
    {
        string sqlStr = "";
        if (isLike.ToLower() == "true")
            sqlStr = "select * from " + tabName + " where " + str1 + " like '%" + val1 + "%'";
        else
            sqlStr = "select * from " + tabName + " where " + str1 + " = '" + val1 + "'";

        StringBuilder sb = new StringBuilder();
        DataTable dt = CreateSQLBusiness.GetDataFromSQL(sqlStr);

        if (dt.Rows.Count > 0)
        {
            sb.Append("<table border=\"1\" width=\"1\" class=\"tabdata\">");
            sb.Append("<tr>");
            sb.Append("<td class=\"th\"><input type=\"checkbox\" onclick=\"f_checkall(this,'" + id + "')\"/></td>");
            int count = 0;
            foreach (DataColumn dc in dt.Columns)
            {
                if (count == 0 && isFirst == "n")
                    count++;
                else
                    sb.Append("<td class=\"th\">" + dc.ColumnName + "</td>");
            }
            sb.Append("</tr>");
            foreach (DataRow dr in dt.Rows)
            {
                sb.Append("<tr>");
                sb.Append("<td><input type=\"checkbox\" onclick=\"f_check(this,'" + id + "')\"/></td>");
                int num = 0;
                foreach (object item in dr.ItemArray)
                {
                    if (num == 0 && isFirst == "n")
                        num++;
                    else
                        sb.Append("<td>" + item.ToString() + "</td>");
                }
                sb.Append("</tr>");
            }
            sb.Append("</table>");
        }

        return sb.ToString();
    }

}