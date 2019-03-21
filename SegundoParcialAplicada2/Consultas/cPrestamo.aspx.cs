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
    public partial class cPrestamos : System.Web.UI.Page
    {
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
                Expression<Func<Prestamo, bool>> filtro = x => true;
                BLL.Repositorio<Prestamo> repositorio = new BLL.Repositorio<Prestamo>();

                int id;
                switch (BuscarPorDropDownList.SelectedIndex)
                {
                    case 0:
                        break;
                    case 1://PrestamoId
                        id = Convert.ToInt32(FiltroTextBox.Text);
                        filtro = c => c.PrestamoId == id;
                        break;
                    case 2://CuentaBancariaId
                        id = Convert.ToInt32(FiltroTextBox.Text);
                        filtro = c => c.CuentaId == id;
                        break;
                }
                
                PrestamoGridView.DataSource = repositorio.GetList(filtro);
                PrestamoGridView.DataBind();
            }
        }

        protected void ImprimirButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Reportes/ReportPrestamos.aspx");
        }

        
    }
}