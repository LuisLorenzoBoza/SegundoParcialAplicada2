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
                DepositoReportViewer.ProcessingMode = ProcessingMode.Local;
                DepositoReportViewer.Reset();
                DepositoReportViewer.LocalReport.ReportPath = Server.MapPath(@"~\Reportes\ListadoDepositos.rdlc");
                DepositoReportViewer.LocalReport.DataSources.Clear();
                DepositoReportViewer.LocalReport.DataSources.Add(new ReportDataSource("Depositos", BLL.Metodos.FDepositos(filtro)));
                DepositoReportViewer.LocalReport.Refresh();
            }
        }
    }
}