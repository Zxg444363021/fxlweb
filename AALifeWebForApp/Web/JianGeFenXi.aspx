﻿<%@ Page Title="消费间隔分析" Language="C#" MasterPageFile="UserControl/MasterPage.master" AutoEventWireup="true" CodeFile="JianGeFenXi.aspx.cs" Inherits="JianGeFenXi" %>

<%@ Register Src="UserControl/FenXiMenu.ascx" TagName="FenXiMenu" TagPrefix="uc4" %>
<%@ Register Src="UserControl/ViewTitle.ascx" TagName="ViewTitle" TagPrefix="uc8" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script type="text/javascript">
    var arrChart = null;

    $(function () {
        $("#datechoose").datepicker({
            showOtherMonths: true,
            selectOtherMonths: true,
            defaultDate: "<%=Session["TodayDate"].ToString() %>",
            onSelect: function (date, format) {
                location.href = "JianGeFenXi.aspx?date=" + date;
            },
            onChangeMonthYear: function(year, month, format) {
                location.href = "JianGeFenXi.aspx?date=" + year + "-" + fullmonth(month) + "-" + "<%=DateTime.Parse(Session["TodayDate"].ToString()).ToString("dd") %>";
            }
        });
        
        $("#datepicker").live("click", function () { datechoose($(this)); });

        $(".tabledate input[type=radio]").click(function(){
            if($(this).val() == "图表") {
                $.cookie("view", "1");
                getview();
            } else {
                $.cookie("view", "0");
                getview();
            }
        });
        
        getview();

        arrChart = $("#<%=hidChartData.ClientID %>").val().split(",");

        bindscroll();
        var load = false;
        var page = 1;
        function longdata(){
            if(($(this).scrollTop() + $(this).height()) == $(this).get(0).scrollHeight) {
                $(".maindiv").unbind("scroll");
                page++;
                
                $.ajax({
                    type: "post",
                    url: "/AutoJianGeFXJson.aspx?page=" + page,
                    dataType: "json",
                    cache: false,
                    beforeSend: function () {
                        if(!load) loading();
                    }, success: function (response) {
                        log(response);
                    }, complete: function () {
                        bindscroll();
                    }
                });
            }
        }        
        function log(data) {
            load = false;
            $(".maindiv table tr:last").remove();
            for (var i = 0; i < data.length; i++) {
                $(".maindiv table").append("<tr><td>" + data[i].ItemType + "</td><td>" + data[i].ItemName + "</td><td><a href='ItemList.aspx?date=" + data[i].ItemBuyDate + "'>" + data[i].ItemBuyDate + "</a></td><td><a href='ItemList.aspx?date=" + data[i].ItemBuyDateMax + "'>" + data[i].ItemBuyDateMax + "</a></td><td>" + data[i].NotBuy + " 天</td></tr>");
            }
        }        
        function loading() {
            load = true;
            $(".maindiv table").append("<tr><td colspan='5'><img src='/Images/Others/ui-anim_basic_16x16.gif' alt='' title='' /> 努力加载中...</td></tr>");
        }
		function bindscroll() {
		    if(($(".maindiv table tr").length - 2) != <%=howManyItems %>) {
                $(".maindiv").bind("scroll", longdata);
            }
		}
    });

    function chart_click(index) {
        location.href = "ItemList.aspx?date=" + arrChart[index];
    }
</script>    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<div id="datechoose"></div>
<div id="content">
    <!--内容开始-->
    <uc4:FenXiMenu ID="FenXiMenu1" runat="server" />
    <uc8:ViewTitle ID="ViewTitle1" runat="server" />
    <div class="maindiv">
        <div class="chartdiv">
            <script type="text/javascript" src="/ofcgwt/swfobject.js"></script>
            <script type="text/javascript">
                swfobject.embedSWF(
                "/ofcgwt/open-flash-chart-SimplifiedChinese.swf", "my_chart", "100%", "431",
                "9.0.0", "/ofcgwt/expressInstall.swf",
                { "data-file": "/JianGeFXChartJson.aspx" }, { "wmode": "transparent" }
                );
            </script>
            <div id="my_chart"></div>
            <input type="hidden" id="hidChartData" runat="server" />
        </div>
        <table cellspacing="0" border="1" style="width:100%;" class="tablelist">
            <tr>
                <th style="width:20%;">分类</th>
                <th style="width:20%;">商品名称</th>
                <th style="width:20%;">上次消费 <img src="/Images/Others/zim.gif" border="0" alt="此列可点击" title="此列可点击" /></th>
                <th style="width:20%;">最后消费 <img src="/Images/Others/zim.gif" border="0" alt="此列可点击" title="此列可点击" /></th>
                <th style="width:20%;">间隔</th>
            </tr>
            <asp:Repeater ID="List" runat="server">
            <ItemTemplate>
            <tr>
                <td><%# Eval("ItemType")%></td>
                <td><%# Eval("ItemName") %></td>
                <td><a href="ItemList.aspx?date=<%# Eval("ItemBuyDate", "{0:yyyy-MM-dd}") %>"><%# Eval("ItemBuyDate", "{0:yyyy-MM-dd}") %></a></td>
                <td><a href="ItemList.aspx?date=<%# Eval("ItemBuyDateMax", "{0:yyyy-MM-dd}") %>"><%# Eval("ItemBuyDateMax", "{0:yyyy-MM-dd}") %></a></td>
                <td><%# Eval("NotBuy") %> 天</td>
            </tr>
            </ItemTemplate>
            <FooterTemplate>
            <tr>
                <td colspan="5" class="noitemcell"><asp:Label ID="Label1" runat="server" Text="没有消费记录。" Visible="<%# List.Items.Count == 0 %>"></asp:Label></td>
            </tr>
            </FooterTemplate>
            </asp:Repeater>
        </table>
    </div>
    <div class="h10"></div>
    <!--内容结束-->
</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="js" Runat="Server">
<script type="text/javascript">
    $(function () {
        $("#menu table tr td").eq(3).addClass("on");

        $("#content .tabletitle .f2").addClass("on");
    });
</script>
</asp:Content>