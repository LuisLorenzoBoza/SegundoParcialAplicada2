using ENTIDADES;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SegundoParcialAplicada2.Reportes
{
    public partial class ReportCuentaBancaria : System.Web.UI.Page
    {
        Expression<Func<CuentaBancaria, bool>> filtro = p => true;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CuentaBancariaReportViewer.ProcessingMode = ProcessingMode.Local;
                CuentaBancariaReportViewer.Reset();
                CuentaBancariaReportViewer.LocalReport.ReportPath = Server.MapPath(@"~\Reportes\ListadoCuentasBancarias.rdlc");
                CuentaBancariaReportViewer.LocalReport.DataSources.Clear();
                CuentaBancariaReportViewer.LocalReport.DataSources.Add(new ReportDataSource("CuentasBancarias", BLL.Funciones.FCuentas(filtro)));
                CuentaBancariaReportViewer.LocalReport.Refresh();
            }
        }
    }
}