<%@ Page Title="钱包管理" Language="C#" MasterPageFile="UserControl/MasterPage.master" AutoEventWireup="true" CodeFile="UserCardAdmin.aspx.cs" Inherits="UserCardAdmin" %>

<%@ Register Src="UserControl/UserMenu.ascx" TagName="UserMenu" TagPrefix="uc6" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<div id="datechoose"></div>
<div id="content">
    <!--内容开始-->    
    <uc6:UserMenu ID="UserMenu1" runat="server" />
    <div class="maindiv userdiv">
        <asp:GridView ID="CardList" runat="server" AutoGenerateColumns="False" CssClass="tablelist"
            Width="100%" BorderWidth="1px" ShowFooter="true"
            onrowcancelingedit="CardList_RowCancelingEdit" 
            onrowupdating="CardList_RowUpdating" onrowdeleting="CardList_RowDeleting" 
            onrowediting="CardList_RowEditing" DataKeyNames="CardID">
            <Columns>
                <asp:TemplateField HeaderText="编号">
                    <ItemTemplate>
                        <%# CardList.Rows.Count + 1%>
                    </ItemTemplate>
                    <FooterTemplate>
                        <strong>总计</strong>
                    </FooterTemplate>
                    <HeaderStyle Width="25%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="名称">
                    <ItemTemplate>
                        <asp:Label ID="CardNameLab" runat="server" Text='<%# Eval("CardName") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="CardNameBox" runat="server" Text='<%# Bind("CardName") %>' MaxLength="20"></asp:TextBox>
                    </EditItemTemplate>
                    <HeaderStyle Width="25%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="余额">
                    <ItemTemplate>
                        ￥<asp:Label ID="CardMoneyLab" runat="server" Text='<%# Eval("CardMoney", "{0:0.0##}") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="CardMoneyBox" runat="server" Text='<%# Bind("CardMoney", "{0:0.###}") %>' onkeyup="this.value=this.value.replace(/[^0-9\.\-]/g,'');if(this.value.split('.').length>2||this.value.split('-').length>2||this.value.indexOf('-')>0)this.value='';" MaxLength="10"></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <strong>￥<%=totalMoney.ToString("0.0##") %></strong>
                    </FooterTemplate>
                    <HeaderStyle Width="25%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="操作">
                    <ItemTemplate>
                        <asp:LinkButton ID="CatButton1" runat="server" CausesValidation="False" CommandName="Edit" Text="修改"></asp:LinkButton>
                        &nbsp;&nbsp;<asp:LinkButton ID="CatButton2" runat="server" CausesValidation="False" CommandName="Delete" Text="删除" OnClientClick="return confirm('确定要删除吗？');"></asp:LinkButton>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:LinkButton ID="CatButton1" runat="server" CausesValidation="True" CommandName="Update" Text="更新"></asp:LinkButton>
                        &nbsp;&nbsp;<asp:LinkButton ID="CatButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="取消"></asp:LinkButton>
                    </EditItemTemplate>
                    <HeaderStyle Width="25%" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <table cellspacing="0" border="1" style="width:100%;" class="tablelist tableadd">
            <tr>
                <td style="width:25%;"></td>
                <td style="width:25%;"><asp:TextBox ID="CardNameEmpIns" runat="server" MaxLength="20"></asp:TextBox></td>
                <td style="width:25%;"><asp:TextBox ID="CardMoneyEmpIns" runat="server" onkeyup="this.value=this.value.replace(/[^0-9\.\-]/g,'');if(this.value.split('.').length>2||this.value.split('-').length>2||this.value.indexOf('-')>0)this.value='';" MaxLength="10"></asp:TextBox></td>
                <td style="width:25%;"><asp:LinkButton ID="Button1" runat="server" Text="添加" onclick="Button1_Click"></asp:LinkButton></td>
            </tr>
        </table>
    </div>
    <div class="h10"></div>
    <!--内容结束-->
</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="js" Runat="Server">
<script type="text/javascript">
    $(function () {
        $("#content .tabletitle .u7").addClass("on");

        $(".tableadd tr td").eq(0).html(Number($(".tablelist").eq(0).find("tr").eq(-2).find("td").eq(0).html()) + 1);
    });
</script>
</asp:Content>