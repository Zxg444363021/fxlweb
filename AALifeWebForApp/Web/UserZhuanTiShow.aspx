﻿<%@ Page Title="查看用户专题" Language="C#" MasterPageFile="UserControl/MasterPage.master" AutoEventWireup="true" CodeFile="UserZhuanTiShow.aspx.cs" Inherits="UserZhuanTiShow" %>

<%@ Register Src="UserControl/UserMenu.ascx" TagName="UserMenu" TagPrefix="uc6" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script type="text/javascript">
    $(function () {
        $("#<%=ItemNameEmpIns.ClientID %>").autocomplete({
            source: "/AutoItemNameJson.aspx",
            minLength: 1,
            select: function (event, ui) {
                if (ui.item.id != 0) {
                    $("#<%=ItemNameEmpIns.ClientID %>").val(ui.item.id);
                }
            }
        });

        $("#<%=ItemBuyDateEmpIns.ClientID %>").datepicker({
            showOtherMonths: true,
            selectOtherMonths: true
        });

        $(".itemdatebox").datepicker({
            showOtherMonths: true,
            selectOtherMonths: true
        });
    });
</script> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<div id="content">
    <!--内容开始-->    
    <uc6:UserMenu ID="UserMenu1" runat="server" />
    <table cellspacing="0" border="1" style="width:100%;" class="tableadd tabzhuanti">
        <tr>
            <td style="width:2%;"></td>
            <td colspan="2" align="center"><strong>专题区间：<asp:Label ID="ZhuanTiDate" runat="server" /></strong></td>
            <td align="center"><strong>总收入：￥<asp:Label ID="ZhuanTiShouRu" runat="server" /></strong></td>
            <td align="center"><strong>总支出：￥<asp:Label ID="ZhuanTiZhiChu" runat="server" /></strong></td>
            <td colspan="2" align="center"><strong><a href="UserZhuanTi.aspx">&lt;&lt; 返回列表</a></strong></td>
            <td style="width:2%;"></td>
        </tr>
        <tr>
            <td></td>
            <td><strong>日期：</strong><asp:TextBox ID="ItemBuyDateEmpIns" runat="server" MaxLength="20" Width="85px"></asp:TextBox></td>
            <td><strong>分类：</strong><asp:DropDownList ID="ItemTypeEmpIns" runat="server"></asp:DropDownList></td>
            <td><strong>名称：</strong><asp:TextBox ID="ItemNameEmpIns" runat="server" MaxLength="20"></asp:TextBox></td>
            <td><strong>类别：</strong><asp:DropDownList ID="CatTypeEmpIns" runat="server" Width="100px"></asp:DropDownList></td>
            <td><strong>价格：</strong><asp:TextBox ID="ItemPriceEmpIns" runat="server" Width="85px" onkeyup="this.value=this.value.replace(/[^0-9\.\-]/g,'');if(this.value.split('.').length>2||this.value.split('-').length>2||this.value.indexOf('-')>0)this.value='';" MaxLength="10"></asp:TextBox></td>
            <td><asp:LinkButton ID="Button1" runat="server" Text="添加" OnClick="LinkButton1_Click"></asp:LinkButton></td>
            <td></td>
        </tr>
    </table>
    <div class="maindiv zhuantidiv">        
        <asp:GridView ID="List" runat="server" AutoGenerateColumns="False" CssClass="tablelist tabzhuanti"
            BorderWidth="1px" Width="100%" onrowcancelingedit="List_RowCancelingEdit" 
            onrowdeleting="List_RowDeleting" onrowediting="List_RowEditing" 
            onrowupdating="List_RowUpdating" DataKeyNames="ItemID">
            <Columns>
                <asp:TemplateField HeaderText="日期" SortExpression="ItemBuyDate">
                    <EditItemTemplate>
                        <asp:TextBox ID="ItemBuyDateBox" runat="server" CssClass="itemdatebox" Text='<%# Bind("ItemBuyDate", "{0:yyyy-MM-dd}") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="ItemBuyDateLab" runat="server" Text='<%# Bind("ItemBuyDate", "{0:yyyy-MM-dd}") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle Width="22%" CssClass="cellprice" />
                    <ItemStyle CssClass="cellprice" />
                </asp:TemplateField>
                <asp:BoundField ReadOnly="true">
                    <HeaderStyle Width="4%" />
                    <ItemStyle CssClass="zhuantidot" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="商品名称" SortExpression="ItemName">
                    <EditItemTemplate>
                        <asp:TextBox ID="ItemNameBox" runat="server" Text='<%# Bind("ItemName") %>' MaxLength="20"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="ItemNameLab" runat="server" Text='<%# Bind("ItemName") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle Width="22%" CssClass="cellleft" />
                    <ItemStyle CssClass="cellleft" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="分类" SortExpression="ItemType">
                    <EditItemTemplate>
                        <asp:DropDownList ID="ItemTypeDropDown" runat="server"></asp:DropDownList>
                        <asp:HiddenField ID="ItemTypeIDHid" runat="server" Value='<%# Bind("ItemTypeValue") %>' />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="ItemTypeLab" runat="server" Text='<%# Bind("ItemType") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle Width="7%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="价格" SortExpression="ItemPrice">
                    <EditItemTemplate>
                        <asp:TextBox ID="ItemPriceBox" runat="server" Text='<%# Bind("ItemPrice", "{0:0.###}") %>' onkeyup="this.value=this.value.replace(/[^0-9\.\-]/g,'');if(this.value.split('.').length>2||this.value.split('-').length>2||this.value.indexOf('-')>0)this.value='';" MaxLength="10"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        ￥<asp:Label ID="ItemPriceLab" runat="server" Text='<%# Bind("ItemPrice", "{0:0.0##}") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle Width="22%" CssClass="cellleft" />
                    <ItemStyle CssClass="cellleft" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="操作">
                    <ItemTemplate>
                        <asp:ImageButton ID="LinkButton1" ImageUrl="/Images/Others/ga.gif" Width="12" Height="13" CssClass="imginput" runat="server" CausesValidation="False" 
                            CommandName="Edit" Text="修改" ToolTip="修改"></asp:ImageButton>
                        &nbsp;<asp:ImageButton ID="LinkButton2" ImageUrl="/Images/Others/ic_dead[1].gif" Width="12" Height="13" CssClass="imginput" runat="server" CausesValidation="False" 
                            CommandName="Delete" Text="删除" ToolTip="删除" OnClientClick="return confirm('确定要删除吗？');"></asp:ImageButton>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:ImageButton ID="LinkButton1" ImageUrl="/Images/Others/ic_download.gif" Width="14" Height="17" CssClass="imginput" runat="server" CausesValidation="True" 
                            CommandName="Update" Text="更新" ToolTip="更新"></asp:ImageButton>
                        &nbsp;<asp:ImageButton ID="LinkButton2" ImageUrl="/Images/Others/i_6.gif" Width="14" Height="15" CssClass="imginput" runat="server" CausesValidation="False" 
                            CommandName="Cancel" Text="取消" ToolTip="取消"></asp:ImageButton>
                    </EditItemTemplate>
                    <HeaderStyle Width="20%" />
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
                <table cellspacing="0" border="1" style="width:100%;" class="tablelist">
                    <tr>
                        <td colspan="5">没有消费记录。</td>
                    </tr>
                </table>
            </EmptyDataTemplate>
        </asp:GridView>
    </div>
    <div class="h10"></div>
    <!--内容结束-->
</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="js" Runat="Server">
<script type="text/javascript">
    $(function () {
        $("#content .tabletitle .u6").addClass("on");
    });
</script>
</asp:Content>