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
    public partial class ReportPrestamos : System.Web.UI.Page
    {
        Expression<Func<Prestamo, bool>> filtro = p => true;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ElPrestamosReportViewer.ProcessingMode = ProcessingMode.Local;
                ElPrestamosReportViewer.Reset();
                ElPrestamosReportViewer.LocalReport.ReportPath = Server.MapPath(@"~\Reportes\ListDepositos.rdlc");
                ElPrestamosReportViewer.LocalReport.DataSources.Clear();
                ElPrestamosReportViewer.LocalReport.DataSources.Add(new ReportDataSource("CuentasDS", BLL.RepositorioDeposito.NDepositos(filtro)));
                ElPrestamosReportViewer.LocalReport.Refresh();
            }
        }
    }
}