<%@ Page Language="C#" AutoEventWireup="true" CodeFile="One.aspx.cs" Inherits="_one" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>IFCA.NET - One</title>
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
<script type="text/javascript" src="common/jquery-2.1.1.min.js"></script>
<link href="common/style.css" rel="stylesheet" />
<style type="text/css">
#tab .th { background-color: #EDFCFF; }
#menu .th { background-color: #FFF5ED; }
</style>
<script type="text/javascript">
    var bdtfldtype = new Array("I", "S", "D", "FM", "FQ", "L", "LC", "L3", "T");
    var bdtfldmaxlen = new Array("8", "12", "30", "100", "200", "500");
    var bdtfldwidth = new Array("80", "100", "135", "200", "350");

    $(function () {
        $("body").on("keyup", "input[type=text]", function () {
            //取当前索引i
            var i = 0;
            var h = $(this).parent().html();
            $(this).parent().parent().find("td").each(function () {
                if ($(this).html() == h) {
                    i = $(this).index();
                }
            });

            //根据索引取标题th文字的宽度
            var t = $(this).parent().parent().parent().find("td pre").eq(i);
            var w = t.width();

            //取input输入文字的宽度并和标题th文字的宽度比较
            var cw = textwidth($(this).val());
            if (cw >= w) {
                $(this).width(cw);
            } else {
                $(this).width(w);
            }
        });

        //增加按钮
        $(".txtdata").append(btntext());

        //填充下拉
        f_fillselect("#BdtFldType", bdtfldtype);
        f_fillselect("#BdtFldMaxLen", bdtfldmaxlen);
        f_fillselect("#BdtFldWidth", bdtfldwidth);

        //所有下拉
        $("body").on("change", "select", function () {
            var val = $(this).val();
            $(this).find("option[value!='" + val + "']").removeAttr("selected");
            $(this).find("option[value='" + val + "']").attr("selected", "selected");
        });

        //所有选择框
        $("body").on("click", "input[type=checkbox]", function () {
            $(this).val() == 1 ? $(this).val(0) : $(this).val(1);
        });

        //下拉连动没搞定，先注释掉。
        //类别下拉
        /*$("body").on("change", "select[name=BdtFldType]", function () {
            var idx = $(this).parent().parent().index();
            var fld = idx == 1 ? "#BdtFldMaxLen" : "#BdtFldMaxLen_" + idx;
            var fld2 = idx == 1 ? "#BdtFldWidth" : "#BdtFldWidth_" + idx;
            
            var sel = $(this).parent().parent().find(fld);
            var sel2 = $(this).parent().parent().find(fld2);
            sel.find("option").removeAttr("selected");
            sel2.find("option").removeAttr("selected");

            var type = $(this).val();
            if (type == "D" || type == "FM" || type == "FQ") {
                f_changeval("20", sel);
                f_changewidth("20", sel2);
            } else if (type == "LC" || type == "L3") {
                f_changeval("30", sel);
                f_changewidth("30", sel2);
            } else if (type == "S") {
                f_changeval("100", sel);
                f_changewidth("100", sel2);
            } else {
                f_changeval("", sel);
                f_changewidth("", sel2);
            }
        });*/

        //长度下拉
        /*$("body").on("change", "select[name=BdtFldMaxLen]", function () {
            var idx = $(this).parent().parent().index();
            var fld = idx == 1 ? "#BdtFldWidth" : "#BdtFldWidth_" + idx;

            var len = $(this).val();
            var sel = $(this).parent().parent().find(fld);
            sel.find("option").removeAttr("selected");

            f_changewidth(len, sel);
        });*/
                
    });

    //改变宽度下拉
    /*function f_changewidth(len, sel) {
        if (len == "4" || len == "20" || len == "30") {
            f_changeval("80", sel);
        } else if (len == "100") {
            f_changeval("135", sel);
        } else if (len == "200") {
            f_changeval("350", sel);
        } else {
            f_changeval("", sel);
        }
    }*/

    //更改下拉值
    /*function f_changeval(val, sel) {
        var cur = sel.val();
        if(cur != val)
            sel.find("option[value='" + val + "']").attr("selected", "selected");
    }*/
    
    //获取文本宽度
    var textwidth = function (text) {
        var sensor = $('<pre>' + text + '</pre>').css({ display: 'none' });
        $('body').append(sensor);
        var width = sensor.width();
        sensor.remove();
        return width;
    };

    //填充下拉
    function f_fillselect(sel, arr) {
        $(sel).append("<option value=''></option>");
        for(var i=0; i<arr.length; i++) {
            $(sel).append("<option value='"+arr[i]+"'>"+arr[i]+"</option>");
        }
    }

    //取列按钮
    var btntext = function () {
        var txt = "<table class='btntab'>";
        txt += "<tr><td>&nbsp;</td><td>&nbsp;</td></tr>";
        txt += "<tr>";
        txt += "<td><input id='addcol' type='button' value='+' class='btncol' onclick='f_addcol()' /></td>";
        txt += "<td><input id='delcol' type='button' value='-' class='btncol' onclick='f_delcol()' /></td>";
        txt += "</tr>";
        txt += "</table>";

        return txt;
    }

    //增加行
    function f_add(id) {
        var idx = $(id).find(".tabadd").find("tr").length;

        var arr = new Array();
        $(id).find(".tabadd").find("tr:last").find("td").each(function () {
            arr.push($(this).find("input").val());
        });

        var data = $(id).find(".datarow").html();
        var str = "<tr>" + data + "</tr>";
        $(id).find(".tabadd").find("tr:last").after(str);

        $(id).find(".tabadd").find("tr:last").find("td").each(function () {
            var id = $(this).children(0).attr("id") + "_" + idx;
            $(this).children(0).attr("id", id);

            $(this).children(0).prop("value", "");
            $(this).children(0).css("width", "100%");
            $(this).find("input[type=checkbox]").val(0);
            $(this).find("option").removeAttr("selected");
        });

        if ($(id).find(".tabadd").height() > 235) {
            $(id).find(".txtmain").css({ "height": "235px", "overflow-y": "auto", "padding-bottom": "0" });
        }
    }

    //删除行
    function f_del(id) {
        if ($(id).find(".tabadd").find("tr").length > 2) {
            $(id).find(".tabadd").find("tr:last").remove();
        }
        if ($(id).find(".tabadd").height() < 235) {
            $(id).find(".txtmain").css({ "height": "100%", "overflow-y": "hidden" });
        }
    }

    //复制
    function f_copy(id) {
        var sql = $(id).find(".txtsql").html();
        if (sql != "") {
            sql = sql.replace(/<br>/ig, "\n");
            window.clipboardData.setData("Text", sql);
            alert("复制成功。");
        } else {
            alert("没有可复制的内容。");
        }
    }

    //生成Sql
    function f_sqlgo(id) {
		$(id).find(".imgcss").show();

        var main = new Array();
        var maintd = $(id).find("#bse tr").eq(1).find("td");
        maintd.each(function () {
            var k = $(this).index();
            main.push($(this).children(0).val());
        });

        maintd = $(id).find("#tab tr").eq(1).find("td");
        maintd.each(function () {
            main.push($(this).children(0).val());
        });

        //alert(main);

        var menu = new Array();
        var menutd = $(id).find("#menu tr").eq(1).find("td");
        menutd.each(function () {
            var k = $(this).index();
            menu[k] = $(this).children(0).val();

            if (k <= 1 && menu[k] == "") return false;
            if (k > 2 && menu[k].indexOf("|") == -1) {
                alert("ContextMnuNo必须是英文|中文的形式。");
            }
        });

        //alert(menu);

        var arr = new Array();
        var tr = $(id).find(".tabadd tr:gt(0)");
        tr.each(function () {
            var i = $(this).index() - 1;
            var td = tr.eq(i).find("td");
            arr[i] = new Array();

            td.each(function () {
                var j = $(this).index();
                arr[i][j] = $(this).children(0).is("pre") ? $(this).children(0).text() : $(this).children(0).val();
            });
        });

        //alert(arr);

        PageMethods.CreateSQL(main, menu, arr, function (data) {
            $(id).find(".imgcss").hide();
            $(id).find(".txtsql").html(data);

            if ($(id).find(".txtsql").height() >= 428) {
                $(id).find(".txtsql").css({ "height": "428px", "overflow-y": "auto" });
            } else {
                $(id).find(".txtsql").css({ "height": "100%", "overflow-y": "hidden" });
            }
        });
    }
    
    //删除sql
    function f_sqlclear(id) {
        var name = $(id).find("#bse tr").eq(1).find("td").eq(0).children(0).val();
        if (name.length == 0) {
            name = $(id).find("#menu tr").eq(1).find("td").eq(0).children(0).val();
        }

        PageMethods.ClearSQL(name, function (data) {
            $(id).find(".txtsql").html(data);
        });
    }

    //增加列
    function f_addcol() {
        //此版是添加在最后
        //$("#bsemenu").find("tr").eq(0).find("td:last").before("<td class='th'><pre>ContextMnuNo</pre></td>");
        //$("#bsemenu").find("tr").eq(1).find("td:last").before("<td><input id='ConTextMnuNo' type='text' autocomplete='off' value='' /></td>");

        var tr = $("#menu").find("tr");
        tr.eq(0).append("<td class='th'><pre>ContextMnuNo</pre></td>");
        tr.eq(1).append("<td><input id='ConTextMnuNo' type='text' autocomplete='off' value='' /></td>");
    }

    //删除列
    function f_delcol() {
        var tr = $("#menu").find("tr");
        var len = tr.eq(0).find("td").length;
        if(len > 3) {
            tr.eq(0).find("td:last").remove();
            tr.eq(1).find("td:last").remove();
        }
    }

</script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager EnablePageMethods="true" EnablePartialRendering="true" ID="ScriptManager1" runat="server">
    </asp:ScriptManager>   
    <%=result %>
    </form>
</body>
</html>
