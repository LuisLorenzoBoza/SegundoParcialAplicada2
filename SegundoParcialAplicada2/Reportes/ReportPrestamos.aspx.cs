using ENTIDADES;
using Entities;
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
                PrestamosReportViewer.ProcessingMode = ProcessingMode.Local;
                PrestamosReportViewer.Reset();
                PrestamosReportViewer.LocalReport.ReportPath = Server.MapPath(@"~\Reportes\ListPrestamos.rdlc");
                PrestamosReportViewer.LocalReport.DataSources.Clear();
                PrestamosReportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSetPrestamos", BLL.RepositorioPrestamo.GetList(filtro)));
                PrestamosReportViewer.LocalReport.Refresh();
            }
        }
    }
}