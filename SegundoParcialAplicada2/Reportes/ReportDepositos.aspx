<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportDepositos.aspx.cs" Inherits="SegundoParcialAplicada2.Reportes.ReportDepositos" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             <%--ScriptManager--%>
            <asp:ScriptManager  runat="server"></asp:ScriptManager>


           <%--Viewer--%>
            <rsweb:ReportViewer ID="DepositosReportViewer" runat="server" ProcessingMode="Remote" Height="100%" Width="100%" >
               
            </rsweb:ReportViewer>

        </div>
    </form>
</body>
</html>