<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportPrestamos.aspx.cs" Inherits="SegundoParcialAplicada2.Reportes.ReportPrestamos" %>

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
            <rsweb:ReportViewer ID="ListPrestamosReportViewer" runat="server" ProcessingMode="Remote" Height="100%" Width="100%" >
               
            </rsweb:ReportViewer>

        </div>
    </form>
</body>
</html>