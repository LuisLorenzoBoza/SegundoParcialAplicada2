using ENTIDADES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SegundoParcialAplicada2.Consultas
{
    public partial class cCuentas : System.Web.UI.Page
    {
        public static List<CuentaBancaria> list { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        


        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(FiltroTextBox.Text) && BuscarPorDropDownList.SelectedIndex != 0)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "Popup", "alert('Debe escribir el criterio')", true);
            }
            else
            {
                Expression<Func<CuentaBancaria, bool>> filtro = x => true;
                BLL.RepositorioBase<CuentaBancaria> repositorio = new BLL.RepositorioBase<CuentaBancaria>();

                int id;
                switch (BuscarPorDropDownList.SelectedIndex)
                {
                    case 0:
                        filtro = c => true;
                        break;
                    case 1://ID
                        id = Convert.ToInt32(FiltroTextBox.Text);
                        filtro = c => c.CuentaBancariaId == id;
                        break;
                    case 2://Nombre
                        filtro = c => c.Nombre.Contains(FiltroTextBox.Text);
                        break;
                }

                CuentaBancariaGridView.DataSource = null;
                CuentaBancariaGridView.DataSource = repositorio.GetList(filtro);
                CuentaBancariaGridView.DataBind();
                
                

            }

        }

        protected void ImprimirButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Reportes/CuentaBancariaReportViewer.aspx");
        }
    }
}