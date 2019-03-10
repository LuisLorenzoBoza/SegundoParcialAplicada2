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
    public partial class ReportDepositos : System.Web.UI.Page
    {
        Expression<Func<Deposito, bool>> filtro = p => true;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DepositosReportViewer.ProcessingMode = ProcessingMode.Local;
                DepositosReportViewer.Reset();
                DepositosReportViewer.LocalReport.ReportPath = Server.MapPath(@"~\Reportes\ListDepositos.rdlc");
                DepositosReportViewer.LocalReport.DataSources.Clear();
                DepositosReportViewer.LocalReport.DataSources.Add(new ReportDataSource("CuentasDS", BLL.RepositorioDeposito.NDepositos(filtro)));
                DepositosReportViewer.LocalReport.Refresh();
            }
        }
    }
}