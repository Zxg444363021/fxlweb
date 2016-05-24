using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Services;

public partial class _one : System.Web.UI.Page
{
    public string result = "";
    private static List<List<string>> strLists;
    private string[] MainArr = { "BseNo", "BseName", "BseWriteTable", "BseIdField" };
    private string[] TabArr = { "TcsName", "TcsListNum" };
    private string[] MenuArr = { "MnuClass", "MnuNo", "MnuName", "ContextMnuNo" };
    public static string[] DetailArr = { "ListDt", "TabDt", "Filter",
                                         "BdtFldName", "BdtFldDesc", "BdtFldType", "BdtFldMaxLen", "BdtFldWidth", "BdtLstEdit", "BdtLstDisplay", "BdtFldOrder", "BdtFldList",
                                         "BdtTabDisplay", "TdtFldEdit", "BdtTabSelect", "BdtRelationName", "BdtFldBEmpty", "BdtSelNo", "BdtWriteTable", "BdtWriteField", "BdtDecimalPlace", "BdtIsCurrentDate", "BdtLstIsHyperLink", "BdtMultiRow" };

    protected void Page_Load(object sender, EventArgs e)
    {
        CreateHtml("main", "sqlgo", DetailArr);
    }

    //创建界面
    private void CreateHtml(string id, string tabName, string[] strArr)
    {
        StringBuilder sb = new StringBuilder();
        StringBuilder sb_input = new StringBuilder();
        sb.Append("<div id=\"" + id + "\" class=\"main\" style='display:block;'>");
        sb.Append("<fieldset>");
        sb.Append("<legend>" + tabName + "</legend>");
        sb.Append("<div class=\"txtdata autoscroll\">");
        sb.Append(CreateTab("bse", MainArr));
        sb.Append(CreateTab("tab", TabArr));
        sb.Append(CreateTab("menu", MenuArr));
        sb.Append("</div>");
        sb.Append("<div class=\"txtmain autoscroll\">");
        sb.Append("<table border=\"1\" width=\"1\" class=\"tabadd\">");
        sb.Append("<tr>");
        sb_input.Append("<tr class=\"datarow\">");
        foreach (string str in strArr)
        {
            sb.Append("<td class=\"th\"><pre>" + str + "</pre></td>");
            if (str == "BdtFldType" || str == "BdtFldMaxLen" || str == "BdtFldWidth")
                sb_input.Append("<td><select id=\"" + str + "\" name=\"" + str + "\"></select></td>");
            else if (str == "ListDt" || str == "TabDt" || str == "Filter" || 
                     str == "BdtLstEdit" || str == "BdtLstEdit" || str == "BdtLstDisplay" || str == "BdtTabDisplay" || str == "TdtFldEdit" || str == "BdtFldBEmpty")
                sb_input.Append("<td align=\"center\"><input type=\"checkbox\" id=\"" + str + "\" value=\"0\" /></td>");
            else
                sb_input.Append("<td><input type=\"text\" id=\"" + str + "\" value=\"\" autocomplete=\"off\" /></td>");
        }
        sb.Append("</tr>");
        sb_input.Append("</tr>");
        sb.Append(sb_input);
        sb.Append("</table>");
        sb.Append("</div>");
        sb.Append("<input id=\"" + id + "add\" type=\"button\" onclick=\"f_add('#" + id + "')\" value=\"加行\" class=\"btncss\" />&nbsp;");
        sb.Append("<input id=\"" + id + "del\" type=\"button\" onclick=\"f_del('#" + id + "')\" value=\"减行\" class=\"btncss\" />&nbsp;");
        sb.Append("<input id=\"" + id + "go\" type=\"button\" onclick=\"f_sqlgo('#" + id + "')\" value=\"生成\" class=\"btncss\" />&nbsp;");
        sb.Append("<input id=\"" + id + "clear\" type=\"button\" onclick=\"f_sqlclear('#" + id + "')\" value=\"删除\" class=\"btncss\" />&nbsp;");
        sb.Append("<input id=\"" + id + "copy\" type=\"button\" onclick=\"f_copy('#" + id + "')\" value=\"复制\" class=\"btncss\" />");
        sb.Append("&nbsp;&nbsp;<img src=\"common/loading.gif\" class=\"imgcss\" style=\"vertical-align:middle;display:none;\" />");
        sb.Append("</fieldset>");
        sb.Append("<div class=\"txtsql autoscroll\"></div>");
        sb.Append("</div>");

        result += sb.ToString();
    }
    
    //创建界面
    private string CreateTab(string id, string[] strArr)
    {
        StringBuilder sb = new StringBuilder();
        StringBuilder sb_input = new StringBuilder();
        sb.Append("<table border=\"1\" width=\"1\" class=\"txttab\" id=\"" + id + "\">");
        sb.Append("<tr>");
        sb_input.Append("<tr>");
        foreach (string str in strArr)
        {
            sb.Append("<td class=\"th\"><pre>" + str + "</pre></td>");
            sb_input.Append("<td><input type=\"text\" id=\"" + str + "\" value=\"\" autocomplete=\"off\" /></td>");
        }
        sb.Append("</tr>");
        sb_input.Append("</tr>");
        sb.Append(sb_input);
        sb.Append("</table>");

        return sb.ToString();
    }

    //生成SQL
    [WebMethod(EnableSession = true)]
    public static string CreateSQL(List<string> main, List<string> menu, List<List<string>> lists)
    {
        //CFString一次插入，先初始化
        GetCFStringData();

        StringBuilder result = new StringBuilder();
        result.Append("------------------------- " + main[1] + " 自动生成 v1.3 -------------------------<br /><br />");
        result.Append(CreateTable("Sys_ContextMenuClass", GetMenuClassData(menu), new string[] { "MnuClass", "0" }));
        result.Append(CreateTable("Sys_ContextMenu", GetMenuData(menu), new string[] { "MnuClass", "1", "ContextMnuNo", "0", "MnuNo", "2" }));
        result.Append(CreateTable("Sys_Base", GetBseData(main), new string[]{ "BseNo", "1" }));
        result.Append(CreateTable("Sys_BaseDt", GetBseDtData(lists, main), new string[] { "BdtBseNo", "0", "BdtFldName", "1" }));
        result.Append(CreateTable("Sys_List", GetListData(main), new string[] { "LstNo", "0", "LstBseNo", "6", "LstOrder", "1" }));
        result.Append(CreateTable("Sys_ListDt", GetListDtData(lists, main), new string[] { "LdtLstNo", "0", "LdtFldName", "2", "LdtLstOrder", "1" }));
        result.Append(CreateTable("Sys_Filter", GetFilterData(lists, main), new string[] { "FltLstNo", "1", "FltName", "21" }));
        result.Append(CreateTable("Sys_Tab", GetTabData(main), new string[] { "TabNo", "0", "TabBseNo", "2" }));
        result.Append(CreateTable("Sys_TabDt", GetTabDtData(lists, main), new string[] { "TdtTabNo", "0", "TdtFldName", "3" }));
        result.Append(CreateTable("Sys_TabClass", GetTabClassData(main), new string[] { "TcsTabNo", "0", "TcsNo", "1" }));
        result.Append(CreateTable("CF_String", strLists, new string[] { "StringCode", "2" }));

        return result.ToString();
    }
        
    //清除SQL
    [WebMethod(EnableSession = true)]
    public static string ClearSQL(string name)
    {
        StringBuilder result = new StringBuilder();
        result.Append("------------------------- 删除脚本 v1.3 -------------------------<br />");
        result.Append("delete from Sys_ContextMenu where MnuClass='" + name + "'<br/>");
        result.Append("delete from Sys_ContextMenuClass where MnuClass='" + name + "'<br/>");
        result.Append("delete from Sys_TabClass where TcsTabNo='" + name + "'<br/>");
        result.Append("delete from Sys_TabDt where TdtTabNo='" + name + "'<br/>");
        result.Append("delete from Sys_Tab where TabNo='" + name + "'<br/>");
        result.Append("delete from Sys_ListDt where LdtLstNo='" + name + "'<br/>");
        result.Append("delete from Sys_List where LstNo='" + name + "'<br/>");
        result.Append("delete from Sys_Filter where FltLstNo='" + name + "'<br/>");
        result.Append("delete from Sys_BaseDt where BdtBseNo='" + name + "'<br/>");
        result.Append("delete from Sys_Base where BseNo='" + name + "'<br/>");
        result.Append("delete from CF_String where StringCode like '" + name + "_%'<br/>");
        result.Append("delete from CF_String where StringCode like '%_" + name + "'<br/>");
        result.Append("delete from CF_String where StringCode like '%_" + name + "_%'<br/>");

        return result.ToString();
    }

    //取ContextMenuClass表需要的字段
    private static List<List<string>> GetMenuClassData(List<string> menu)
    {
        if (menu[0] == "") return null;

        string[] DataArr = { "MnuClass", "DescriptionStringCode" };

        List<List<string>> newLists = new List<List<string>>();
        newLists.Add(GetListForArr(DataArr));

        string MnuClass = menu[0];
        string MnuNo = menu[1];
        string MnuName = menu[2];
        string DescriptionStringCode = "MnuClass_" + MnuClass;

        List<string> newList = new List<string>();
        newList.Add(MnuClass);
        newList.Add(DescriptionStringCode);
        newLists.Add(newList);//添加到集合
        
        //CF_String表
        strLists.Add(SetCFStringData("Control", "Sys_ContextMenuClass", DescriptionStringCode, MnuName));

        return CreateSQLBusiness.GetAllData(newLists, "Sys_ContextMenuClass", "y");
    }

    //取ContextMenu表需要的字段
    private static List<List<string>> GetMenuData(List<string> menu)
    {
        string[] DataArr = { "ContextMnuNo", "MnuClass", "MnuNo", "MnuStringCode", "MnuScript", "CausesValidation", "IsInDropDown", "IsNeedPrivilege", "ImageName", "SeqNo" };

        List<List<string>> newLists = new List<List<string>>();
        newLists.Add(GetListForArr(DataArr));

        for (int i = 3; i < menu.Count; i++)
        {
            try
            {
                string[] Name = menu[i].Split('|');
                string ContextMnuNoCN = Name[1];
                string ContextMnuNo = Name[0];
                string MnuClass = menu[0];
                string MnuNo = menu[1];
                string MnuStringCode = MnuNo + "_" + MnuClass + "_" + ContextMnuNo;
                string MnuScript = "f_" + ContextMnuNo + "()";
                string CausesValidation = "1";
                string IsInDropDown = "N";
                string IsNeedPrivilege = "Y";
                string ImageName = "btn_" + ContextMnuNo + ".gif";
                string SeqNo = i.ToString();

                List<string> newList = new List<string>();
                newList.Add(ContextMnuNo);
                newList.Add(MnuClass);
                newList.Add(MnuNo);
                newList.Add(MnuStringCode);
                newList.Add(MnuScript);
                newList.Add(CausesValidation);
                newList.Add(IsInDropDown);
                newList.Add(IsNeedPrivilege);
                newList.Add(ImageName);
                newList.Add(SeqNo);
                newLists.Add(newList);//添加到集合

                //CF_String表
                strLists.Add(SetCFStringData("Common", "Sys_ContextMenu", MnuStringCode, ContextMnuNoCN));
            }
            catch { }
        }

        return CreateSQLBusiness.GetAllData(newLists, "Sys_ContextMenu", "n");
    }

    //取Bse表需要的字段
    private static List<List<string>> GetBseData(List<string> main)
    {
        if(main[0] == "") return null;

        string[] DataArr = { "BseNo", "BseName", "BseNameStringCode", "BseReadTable", "BseWriteTable", "BseDesc", "BseDescStringCode", "BseIdField" };

        List<List<string>> newLists = new List<List<string>>();
        newLists.Add(GetListForArr(DataArr));

        string BseNo = main[0];
        string BseName = main[1];
        string BseWriteTable = main[2];
        string BseIdField = main[3];
        string BseNameStringCode = "Sys_Base_Name_" + BseNo;
        string BseReadTable = "View_" + BseWriteTable;
        string BseDesc = BseName;
        string BseDescStringCode = "Sys_Base_Desc_" + BseNo;

        List<string> newList = new List<string>();
        newList.Add(BseNo);
        newList.Add(BseName);
        newList.Add(BseNameStringCode);
        newList.Add(BseReadTable);
        newList.Add(BseWriteTable);
        newList.Add(BseDesc);
        newList.Add(BseDescStringCode);
        newList.Add(BseIdField);
        newLists.Add(newList);//添加到集合

        //CF_String表
        strLists.Add(SetCFStringData("Control", "Sys_Base", BseNameStringCode, BseName));
        strLists.Add(SetCFStringData("Control", "Sys_Base", BseDescStringCode, BseName));

        return CreateSQLBusiness.GetAllData(newLists, "Sys_Base", "n");
    }

    //取BseDt表需要的字段
    private static List<List<string>> GetBseDtData(List<List<string>> lists, List<string> main)
    {
        string[] DataArr = { "BdtBseNo", "BdtFldName", "BdtFldDesc","BdtFldDescEN","BdtFldDescStringCode","BdtFldHelpStringCode", "BdtFldMaxLen","BdtFldType",  "BdtFldWidth", 
                             "BdtFldAlign", "BdtLstDefault", "BdtLstEdit", "BdtLstDisplay", "BdtFldOrder", "BdtFldList", "BdtTabDisplay", "BdtFilter", "BdtTabSelect", "BdtTabWidth", "BdtRelationName", "BdtTabColSpan",
                             "BdtFldBEmpty", "BdtSelNo", "BdtWriteTable", "BdtWriteField", "BdtDecimalPlace", "BdtIsCurrentDate", "BdtIsNegativeAllow", "BdtLstIsHyperLink", "BdtMultiRow" };

        List<List<string>> newLists = new List<List<string>>();
        newLists.Add(GetListForArr(DataArr));
        
        foreach (List<string> list in lists)
        {
            Dictionary<string, string> dic = GetDicForList(list);
            if(dic["BdtFldName"] == "") continue;

            string BseNo = main[0];
            string BdtBseNo = BseNo;
            string BdtFldName = dic["BdtFldName"];
            string BdtFldDesc = dic["BdtFldDesc"];
            string BdtFldDescEN = BdtFldName;
            string BdtFldDescStringCode = BseNo + "_" + BdtFldName;
            string BdtFldHelpStringCode = BdtFldDescStringCode;
            string BdtFldMaxLen = dic["BdtFldMaxLen"];
            string BdtFldType = dic["BdtFldType"];
            string BdtFldWidth = dic["BdtFldWidth"];
            string BdtFldAlign = "left";
            string BdtLstDefault = "1";
            string BdtLstEdit = dic["BdtLstEdit"];
            string BdtLstDisplay = dic["BdtLstDisplay"];
            string BdtFldOrder = dic["BdtFldOrder"];
            string BdtFldList = dic["BdtFldList"];
            string BdtTabDisplay = dic["BdtTabDisplay"];
            string BdtFilter = "0";
            string BdtTabSelect = dic["BdtTabSelect"];
            string BdtTabWidth = "135";
            string BdtRelationName = dic["BdtRelationName"];
            string BdtTabColSpan = "1";
            string BdtFldBEmpty = dic["BdtFldBEmpty"];
            string BdtSelNo = dic["BdtSelNo"];
            string BdtWriteTable = dic["BdtWriteTable"];
            string BdtWriteField = dic["BdtWriteField"];
            string BdtDecimalPlace = dic["BdtDecimalPlace"];
            string BdtIsCurrentDate = dic["BdtIsCurrentDate"];
            string BdtIsNegativeAllow = "N";
            string BdtLstIsHyperLink = dic["BdtLstIsHyperLink"];
            string BdtMultiRow = dic["BdtMultiRow"];

            List<string> newList = new List<string>();
            newList.Add(BdtBseNo);
            newList.Add(BdtFldName);
            newList.Add(BdtFldDesc);
            newList.Add(BdtFldDescEN);
            newList.Add(BdtFldDescStringCode);
            newList.Add(BdtFldHelpStringCode);
            newList.Add(BdtFldMaxLen);
            newList.Add(BdtFldType);
            newList.Add(BdtFldWidth);
            newList.Add(BdtFldAlign);
            newList.Add(BdtLstDefault);
            newList.Add(BdtLstEdit);
            newList.Add(BdtLstDisplay);
            newList.Add(BdtFldOrder);
            newList.Add(BdtFldList);
            newList.Add(BdtTabDisplay);
            newList.Add(BdtFilter);
            newList.Add(BdtTabSelect);
            newList.Add(BdtTabWidth);
            newList.Add(BdtRelationName);
            newList.Add(BdtTabColSpan);
            newList.Add(BdtFldBEmpty);
            newList.Add(BdtSelNo);
            newList.Add(BdtWriteTable);
            newList.Add(BdtWriteField);
            newList.Add(BdtDecimalPlace);
            newList.Add(BdtIsCurrentDate);
            newList.Add(BdtIsNegativeAllow);
            newList.Add(BdtLstIsHyperLink);
            newList.Add(BdtMultiRow);
            newLists.Add(newList);//添加到集合

            //CF_String表
            strLists.Add(SetCFStringData("Field", "Sys_BaseDt", BdtFldDescStringCode, BdtFldDesc));
        }

        return CreateSQLBusiness.GetAllData(newLists, "Sys_BaseDt", "n");
    }

    //取List表需要的字段
    private static List<List<string>> GetListData(List<string> main)
    {
        if(main[0] == "") return null;

        string[] DataArr = { "LstNo", "LstOrder", "LstName", "LstNameStringCode", "LstTitle", "LstTitleStringCode", "LstBseNo", "LstDefault" };

        List<List<string>> newLists = new List<List<string>>();
        newLists.Add(GetListForArr(DataArr));

        string BseNo = main[0];
        string BseName = main[1];
        string LstNo = BseNo;
        string LstOrder = "1";
        string LstName = BseName;
        string LstNameStringCode = "Sys_List_Name_" + LstNo;
        string LstTitle = LstName;
        string LstTitleStringCode = "Sys_List_Title_" + LstNo;
        string LstBseNo = BseNo;
        string LstDefault = "Y";

        List<string> newList = new List<string>();
        newList.Add(LstNo);
        newList.Add(LstOrder);
        newList.Add(LstName);
        newList.Add(LstNameStringCode);
        newList.Add(LstTitle);
        newList.Add(LstTitleStringCode);
        newList.Add(LstBseNo);
        newList.Add(LstDefault);
        newLists.Add(newList);//添加到集合

        newList = new List<string>();
        newList.Add(LstNo);
        newList.Add("-1");
        newList.Add(LstName);
        newList.Add(LstNameStringCode);
        newList.Add(LstTitle);
        newList.Add(LstTitleStringCode);
        newList.Add(LstBseNo);
        newList.Add("N");
        newLists.Add(newList);//添加到集合

        //CF_String表
        strLists.Add(SetCFStringData("Control", "Sys_List", LstNameStringCode, LstName));
        strLists.Add(SetCFStringData("Control", "Sys_List", LstTitleStringCode, LstName));

        return CreateSQLBusiness.GetAllData(newLists, "Sys_List", "n");
    }

    //取ListDt表需要的字段
    private static List<List<string>> GetListDtData(List<List<string>> lists, List<string> main)
    {
        string[] DataArr = { "LdtLstNo", "LdtLstOrder", "LdtFldName", "LdtFldDesc", "LdtFldDescEN", "LdtFldDescStringCode", "LdtFldHelpStringCode", 
                             "LdtFldMaxLen", "LdtFldWidth", "LdtFldAlign", "LdtFldType", "LdtFldEdit", "LdtFldOrder", "LdtFldDisplay" };

        List<List<string>> newLists = new List<List<string>>();
        newLists.Add(GetListForArr(DataArr));

        foreach (List<string> list in lists)
        {
            Dictionary<string, string> dic = GetDicForList(list);
            string ListNeed = dic["ListDt"];
            if (ListNeed == "0") continue;

            string BseNo = main[0];
            string LdtLstNo = BseNo;
            string LdtLstOrder = "1";
            string LdtFldName = dic["BdtFldName"];
            string LdtFldDesc = dic["BdtFldDesc"];
            string LdtFldDescEN = LdtFldName;
            string LdtFldDescStringCode = LdtLstNo + "_" + LdtFldName;
            string LdtFldHelpStringCode = LdtFldDescStringCode;
            string LdtFldMaxLen = dic["BdtFldMaxLen"];
            string LdtFldWidth = dic["BdtFldWidth"];
            string LdtFldAlign = "left";
            string LdtFldType = dic["BdtFldType"];
            string LdtFldEdit = dic["BdtLstEdit"];
            string LdtFldOrder = dic["BdtFldOrder"];
            string LdtFldDisplay = dic["BdtLstDisplay"];

            List<string> newList = new List<string>();
            newList.Add(LdtLstNo);
            newList.Add(LdtLstOrder);
            newList.Add(LdtFldName);
            newList.Add(LdtFldDesc);
            newList.Add(LdtFldDescEN);
            newList.Add(LdtFldDescStringCode);
            newList.Add(LdtFldHelpStringCode);
            newList.Add(LdtFldMaxLen);
            newList.Add(LdtFldWidth);
            newList.Add(LdtFldAlign);
            newList.Add(LdtFldType);
            newList.Add(LdtFldEdit);
            newList.Add(LdtFldOrder);
            newList.Add(LdtFldDisplay);
            newLists.Add(newList);//添加到集合
        }

        return CreateSQLBusiness.GetAllData(newLists, "Sys_ListDt", "n");
    }

    //取Filter表需要的字段
    private static List<List<string>> GetFilterData(List<List<string>> lists, List<string> main)
    {
        string[] DataArr = { "FltBseNo", "FltLstNo", "FltType", "FltDisMode", "FltRange", "FltEIncNullText", "FltOrder", "FltName" };

        List<List<string>> newLists = new List<List<string>>();
        newLists.Add(GetListForArr(DataArr));

        foreach (List<string> list in lists)
        {
            Dictionary<string, string> dic = GetDicForList(list);
            string Filter = dic["Filter"];
            if (Filter == "0") continue;

            string BseNo = main[0];
            string FltBseNo = BseNo;
            string FltLstNo = BseNo;
            string FltType = dic["BdtFldType"];
            string FltDisMode = "0";
            string FltRange = "0";
            string FltEIncNullText = "1";
            string FltOrder = dic["BdtFldOrder"];
            string FltName = dic["BdtFldName"];

            List<string> newList = new List<string>();
            newList.Add(FltBseNo);
            newList.Add(FltLstNo);
            newList.Add(FltType);
            newList.Add(FltDisMode);
            newList.Add(FltRange);
            newList.Add(FltEIncNullText);
            newList.Add(FltOrder);
            newList.Add(FltName);
            newLists.Add(newList);//添加到集合
        }

        return CreateSQLBusiness.GetAllData(newLists, "Sys_Filter", "n");
    }

    //取Tab表需要的字段
    private static List<List<string>> GetTabData(List<string> main)
    {
        if(main[0] == "") return null;

        string[] DataArr = { "TabNo", "TabName", "TabBseNo", "TabNameStringCode" };

        List<List<string>> newLists = new List<List<string>>();
        newLists.Add(GetListForArr(DataArr));

        string BseNo = main[0];
        string BseName = main[1];
        string TabNo = BseNo;
        string TabName = BseName;
        string TabBseNo = BseNo;
        string TabNameStringCode = "Sys_Tab_Name_" + TabNo;

        List<string> newList = new List<string>();
        newList.Add(TabNo);
        newList.Add(TabName);
        newList.Add(TabBseNo);
        newList.Add(TabNameStringCode);
        newLists.Add(newList);//添加到集合

        //CF_String表
        strLists.Add(SetCFStringData("Common", "Sys_Tab", TabNameStringCode, TabName));

        return CreateSQLBusiness.GetAllData(newLists, "Sys_Tab", "n");
    }

    //取TabDt表需要的字段
    private static List<List<string>> GetTabDtData(List<List<string>> lists, List<string> main)
    {
        string[] DataArr = { "TdtBseNo", "TdtTabNo", "TdtTcsNo", "TdtFldName", "TdtFldDesc", "TdtFldDescStringCode", "TdtFldHelpStringCode", "TdtFldEdit", "TdtFldOrder" };

        List<List<string>> newLists = new List<List<string>>();
        newLists.Add(GetListForArr(DataArr));

        foreach (List<string> list in lists)
        {
            Dictionary<string, string> dic = GetDicForList(list);
            string TabNeed = dic["TabDt"];
            if (TabNeed == "0") continue;

            string BseNo = main[0];
            string TdtBseNo = BseNo;
            string TdtTabNo = BseNo;
            string TdtTcsNo = "01";
            string TdtFldName = dic["BdtFldName"];
            string TdtFldDesc = dic["BdtFldDesc"];
            string TdtFldDescStringCode = TdtBseNo + "_" + TdtFldName;
            string TdtFldHelpStringCode = TdtFldDescStringCode;
            string TdtFldEdit = dic["TdtFldEdit"];
            string TdtFldOrder = dic["BdtFldOrder"];

            List<string> newList = new List<string>();
            newList.Add(TdtBseNo);
            newList.Add(TdtTabNo);
            newList.Add(TdtTcsNo);
            newList.Add(TdtFldName);
            newList.Add(TdtFldDesc);
            newList.Add(TdtFldDescStringCode);
            newList.Add(TdtFldHelpStringCode);
            newList.Add(TdtFldEdit);
            newList.Add(TdtFldOrder);
            newLists.Add(newList);//添加到集合
        }

        return CreateSQLBusiness.GetAllData(newLists, "Sys_TabDt", "n");
    }

    //取TabClass表需要的字段
    private static List<List<string>> GetTabClassData(List<string> main)
    {
        if(main[4] == "") return null;

        string[] DataArr = { "TcsTabNo", "TcsNo", "TcsName", "TcsNameEN", "TcsNameStringCode", "TcsListNum" };

        List<List<string>> newLists = new List<List<string>>();
        newLists.Add(GetListForArr(DataArr));

        string BseNo = main[0];
        string BseName = main[1];
        string TcsTabNo = BseNo;
        string TcsNo = "01";
        string TcsName = main[4];
        string TcsNameEN = "Translate Please";
        string TcsNameStringCode = "TabClass_" + TcsTabNo + "_" + TcsNo;
        string TcsListNum = main[5];

        List<string> newList = new List<string>();
        newList.Add(TcsTabNo);
        newList.Add(TcsNo);
        newList.Add(TcsName);
        newList.Add(TcsNameEN);
        newList.Add(TcsNameStringCode);
        newList.Add(TcsListNum);
        newLists.Add(newList);//添加到集合

        //CF_String表
        strLists.Add(SetCFStringData("Field", "Sys_TabClass", TcsNameStringCode, TcsName));

        return CreateSQLBusiness.GetAllData(newLists, "Sys_TabClass", "n");
    }

    //取CFString表需要的字段
    private static void GetCFStringData()
    {
        string[] DataArr = { "StringType", "RefTable", "StringCode", "StringCN", "StringEN", "IsSystem", "RecordStatus", "CreateDate", "CreateUserID", 
                             "ModifyDate", "ModifyUserID", "IsTranslated2EN", "Dummy", "DummyDate" };

        strLists = new List<List<string>>();
        strLists.Add(GetListForArr(DataArr));
    }

    //设置CFString数据
    private static List<string> SetCFStringData(string stringType, string refTable, string stringCode, string stringCN)
    {
        string StringType = stringType;
        string RefTable = refTable;
        string StringCode = stringCode;
        string StringCN = stringCN;
        string StringEN = "Translate Please";
        string IsSystem = "N";
        string RecordStatus = "Active";
        string CreateDate = DateTime.Now.ToString();
        string CreateUserID = "1";
        string ModifyDate = DateTime.Now.ToString();
        string ModifyUserID = "1";
        string IsTranslated2EN = "N";
        string Dummy = "N";
        string DummyDate = DateTime.Now.ToString();

        List<string> strList = new List<string>();
        strList.Add(StringType);
        strList.Add(RefTable);
        strList.Add(StringCode);
        strList.Add(StringCN);
        strList.Add(StringEN);
        strList.Add(IsSystem);
        strList.Add(RecordStatus);
        strList.Add(CreateDate);
        strList.Add(CreateUserID);
        strList.Add(ModifyDate);
        strList.Add(ModifyUserID);
        strList.Add(IsTranslated2EN);
        strList.Add(Dummy);
        strList.Add(DummyDate);

        return strList;
    }

    //转换Dictionary数据
    private static Dictionary<string, string> GetDicForList(List<string> list)
    {
        Dictionary<string, string> dic = new Dictionary<string, string>();
        for (int i = 0; i < DetailArr.Length; i++)
        {
            dic.Add(DetailArr[i], list[i]);
        }

        return dic;
    }

    //转换List数据
    private static List<string> GetListForArr(string[] arr)
    {
        List<string> list = new List<string>();
        for (int i = 0; i < arr.Length; i++)
        {
            list.Add(arr[i]);
        }

        return list;
    }

    //取要生成的SQL
    private static string CreateTable(string tabName, List<List<string>> lists, string[] qryArr)
    {
        if(lists == null) return "";

        return CreateSQLBusiness.CreateSQL(tabName, lists, qryArr);
    }

}