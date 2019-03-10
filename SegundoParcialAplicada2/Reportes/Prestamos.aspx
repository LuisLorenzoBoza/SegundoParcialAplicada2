<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Prestamos.aspx.cs" Inherits="SegundoParcialAplicada2.Reportes.Prestamos" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             <%--ScriptManager--%>
            <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>


           <%--Viewer--%>
            <rsweb:ReportViewer ID="ElDepositosReportViewer" runat="server" ProcessingMode="Remote" Height="100%" Width="100%" >
               
            </rsweb:ReportViewer>
        </div>
    </form>
</body>
</html>
