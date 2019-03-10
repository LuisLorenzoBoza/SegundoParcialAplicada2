<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportCuentaBancaria.aspx.cs" Inherits="SegundoParcialAplicada2.Reportes.ReportCuentaBancaria" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             <%--ScriptManager--%>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>


           <%--Viewer--%>
            <rsweb:ReportViewer ID="CuentaBancariaReportViewer" runat="server" ProcessingMode="Remote" Height="100%" Width="100%" >
               
            </rsweb:ReportViewer>

        </div>
    </form>
</body>
</html>

