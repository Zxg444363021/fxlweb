<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>IFCA.NET - SQLgo</title>
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
<script type="text/javascript" src="common/jquery-2.1.1.min.js"></script>
<link href="common/style.css" rel="stylesheet" />
<script type="text/javascript">

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

        $(".searchtxt").keyup(function () {
            var w = 100;

            var cw = textwidth($(this).val());
            if (cw >= w) {
                $(this).width(cw);
            } else {
                $(this).width(w);
            }
        });
    });

    //获取文本宽度
    var textwidth = function (text) {
        var sensor = $('<pre>' + text + '</pre>').css({ display: 'none' });
        $('body').append(sensor);
        var width = sensor.width();
        sensor.remove();
        return width;
    };

    //增加行
    function f_add(id) {
        var arr = new Array();
        $(id).find(".tabadd").find("tr:last").find("td").each(function () {
            arr.push($(this).find("input").val());
        });

        var data = $(id).find(".datarow").html();
        var str = "<tr>" + data + "</tr>";
        $(id).find(".tabadd").find("tr:last").after(str);

        $(id).find(".tabadd").find("tr:last").find("td").each(function () {
            $(this).children(0).prop("value", arr[$(this).index()]);
            $(this).children(0).css("width", "100%");
        });

        if ($(id).find(".tabadd").height() > 110) {
            $(id).find(".txtmain").css({ "height": "110px", "overflow-y": "auto", "padding-bottom": "0" });
        }
    }

    //删除行
    function f_del(id) {
        if ($(id).find(".tabadd").find("tr").length > 2) {
            $(id).find(".tabadd").find("tr:last").remove();
        }
        if ($(id).find(".tabadd").height() < 110) {
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

    //展开
    function f_expand(id, obj) {
        $(id).toggle();
        var t = $(obj).text();
        if (t.indexOf("+") != -1) {
            $(obj).text(t.replace("+", "－"));
        }
        if (t.indexOf("－") != -1) {
            $(obj).text(t.replace("－", "+"));
        }
    }

    //生成Sql
    function f_sqlgo(id, tabname, strs) {
        var arr = new Array();
        var tr = $(id).find(".tabadd tr"); 
        var td_arr = new Array();
        tr.each(function () {
            var i = $(this).index();
            var td = tr.eq(i).find("td");
            arr[i] = new Array();

            td.each(function () {
                var j = $(this).index();
                //列头数组
                if(i == 0) {
                    td_arr[j] = $(this).text();
                }
                arr[i][j] = $(this).children(0).html().length == 0 ? f_filtervalue($(this).children(0).val(), td_arr[j]) : f_filtername(td_arr[j]);
            });
        });

        //alert(arr);
        //alert(td_arr);

        var strArr = strs.split(',');
        //alert(strArr);

        PageMethods.CreateSQL(tabname, arr, strArr, function (data) {
            $(id).find(".txtsql").html(data);

            if ($(id).find(".txtsql").height() >= 192) {
                $(id).find(".txtsql").css({ "height": "192px", "overflow-y": "auto" });
            } else {
                $(id).find(".txtsql").css({ "height": "100%", "overflow-y": "hidden" });
            }
        });
    }

    //处理系统关键字
    function f_filtername(str) {
        var result = "";
        switch (str.toLowerCase()) {
            case "order":
            case "rank":
                result = "[" + str + "]";
                break;
            default:
                result = str;
                break;
        }

        return result;
    }

    //处理值
    function f_filtervalue(str, name) {
        var result = str.replace("'", "''");
        name = name.toLowerCase();
        
        //处理日期
        if (str.length > 10) {
            var d = Date.parse(result);
            if (!isNaN(d)) {
                result = new Date().format("yyyy/MM/dd HH:mm:ss");
            }  
        }

        //处理UserID
        if(name == "createuserid" || name == "modifyuserid") {
            return 1;
        }

        return result;
    }

    //查找
    function f_search(id, tabname, str1, isfirst) {
        var hidcount = $(id).find("input[type=hidden]");
        hidcount.val("0");

        var islike = $(id).find(".like").prop("checked");
        $(id).find(".tabdata").remove();
        var key = $(id).find(".searchtxt").val();

        PageMethods.GetTable(id, tabname, str1, key, isfirst, islike, function (data) {
            $(id).find(".txtdata").append(data);

            if ($(id).find(".txtdata").height() >= 141) {
                $(id).find(".txtdata").css({ "height": "141px", "overflow-y": "auto" });
            } else {
                $(id).find(".txtdata").css({ "height": "100%", "overflow-y": "hidden" });
            }
        });
    }

    //checkbox选中
    function f_check(obj, id) {
        var hidcount = $(id).find("input[type=hidden]");
        var count = hidcount.val();
        var arr = new Array();
        $(obj).parent().parent().find("td:not(:first)").each(function () {
            arr.push($(this).text());
        });        
        if (obj.checked) {
            count++;
            if (count >= 2) {
                f_add(id);
            }
            $(id).find(".tabadd").find("tr:last").find("td").each(function () {
                $(this).children(0).prop("value", arr[$(this).index()]);
                //$(this).children(0).attr("ref", arr[$(this).index()]);
                f_setwidth($(this));
            });
        } else {
            $(id).find(".tabadd").find("tr:last").find("td").children(0).prop("value", "");
            $(id).find(".tabadd").find("tr:last").find("td").children(0).removeAttr("style");
            f_del(id);
            count--
        }
        hidcount.val(count);
        //alert(count);
        f_cbonoff(id);
    }

    //全选
    var all = false;
    function f_checkall(obj, id) {
        f_getall(id);

        $(id).find(".txtdata").find(".imgcss").show();
        setTimeout(function () {
            f_checkall2(obj, id);
        }, 500);        
    }

    function f_checkall2(obj, id) {
        all = !all ? true : false;
        $(id).find(".tabdata").find("tr:not(:first)").find("input[type=checkbox]").each(function (i, c) {
            c.checked = all;
            f_check(c, id);
        });
        $(id).find(".txtdata").find(".imgcss").hide();
    }

    function f_cbonoff(id) {
        var count = $(id).find("input[type=hidden]").val();
        if (count == 0) {
            $(id).find(".tabdata").find("tr:first").find("input[type=checkbox]").attr("checked", false);
            all = false;
        }
        var len = $(id).find(".tabdata").find("tr:not(:first)").length;
        if (len == count) {
            $(id).find(".tabdata").find("tr:first").find("input[type=checkbox]").attr("checked", true);
            all = true;
        }
    }

    function f_getall(id) {
        var count = $(id).find("input[type=hidden]").val();
        var len = $(id).find(".tabdata").find("tr:not(:first)").length;
        if (len == count) {
            all = true;
        } else {
            all = false;
        }
    }

    //设置单元格宽度
    function f_setwidth(obj) {
        var i = obj.index();
        var w = obj.parent().parent().find("td pre").eq(i).width();
        
        var t = obj.children(0).val();
        if (t != "") {
            var cw = textwidth(obj.children(0).val())
            if (cw >= w) {
                obj.children(0).width(cw);
            } else {
                obj.children(0).css("width", "100%");
            }
        }
    }

    //设置单元格宽度1
    function f_setwidth1(obj) {
        var i = obj.index();
        var pw = obj.parent().parent().find("td").eq(i).width();

        var t = obj.children(0).val();
        if (t != "") {
            var r = document.body.createTextRange();
            r.findText(t);
            var cw = r.boundingWidth;
            if (cw > pw) {
                obj.children(0).width(cw);
            }
        }
    }

</script>
</head>
<body>
    <form id="form1" runat="server"> 
    <asp:ScriptManager EnablePageMethods="true" EnablePartialRendering="true" ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <center><a href="One.aspx" target="_blank">** The One **</a></center>
    <%=result %>
    </form>
</body>
</html>
