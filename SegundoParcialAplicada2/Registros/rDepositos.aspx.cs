using BLL;
using ENTIDADES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SegundoParcialAplicada2.Registros
{
    public partial class rDepositos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        void Limpiar()
        {
            depositoIdTextbox.Text = "0";
            fechaTextbox.Text = string.Empty;
            cuentaIdTextbox.Text = "0";
            conceptoTextbox.Text = string.Empty;
            montoTextbox.Text = string.Empty;
        }

        private void LlenaCampos(Deposito deposito)
        {
            depositoIdTextbox.Text = deposito.CuentaId.ToString();
            fechaTextbox.Text = deposito.Fecha.ToString("yyyy-MM-dd");
            cuentaIdTextbox.Text = deposito.CuentaId.ToString();
            conceptoTextbox.Text = deposito.Concepto;
            montoTextbox.Text = deposito.Monto.ToString();
        }

        private Deposito LlenaClase()
        {
            var deposito = new Deposito();
            deposito.Fecha = Convert.ToDateTime(fechaTextbox.Text);
            deposito.CuentaId = Convert.ToInt32(cuentaIdTextbox.Text);
            deposito.Concepto = conceptoTextbox.Text;
            deposito.Monto = Convert.ToDecimal(montoTextbox.Text);

            return deposito;
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(depositoIdTextbox.Text);
            if (!(String.IsNullOrEmpty(conceptoTextbox.Text) || String.IsNullOrEmpty(fechaTextbox.Text) || String.IsNullOrEmpty(montoTextbox.Text)))
            {
                RepositorioDeposito repositorio = new RepositorioDeposito();
                if (id == 0)
                {
                    repositorio.Guardar(LlenaClase());
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "Popup", "alert('Guardado con Exito')", true);
                }
                else
                {
                    if (repositorio.Buscar(id) != null)
                    {
                        Deposito deposito = repositorio.Buscar(int.Parse(depositoIdTextbox.Text));

                        deposito.CuentaId = int.Parse(depositoIdTextbox.Text);
                        deposito.Fecha = DateTime.Parse(fechaTextbox.Text);
                        deposito.Concepto = conceptoTextbox.Text;
                        deposito.Monto = Decimal.Parse(montoTextbox.Text);

                        repositorio.Modificar(deposito);
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "Popup", "alert('Modificado con Exito')", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "Popup", "alert('No existe una categoria con ese ID, no puede modificarse')", true);
                    }
                }
            }
            else if (id == 0)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "Popup", "alert('Rellene todos los campos')", true);
            }
            Limpiar();
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(depositoIdTextbox.Text);
            if (id != 0)
            {
                RepositorioDeposito repositorio = new RepositorioDeposito();
                if (repositorio.Buscar(id) != null)
                {
                    if (repositorio.Eliminar(id))
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "Popup", "alert('Eliminado con Exito')", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "Popup", "alert('No se pudo eliminar')", true);
                    }
                    Limpiar();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "Popup", "alert('No existe')", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "Popup", "alert('Seleccione un ID')", true);
            }
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(depositoIdTextbox.Text))
            {
                int id = Convert.ToInt32(depositoIdTextbox.Text);
                if (id != 0)
                {
                    RepositorioDeposito repositorio = new RepositorioDeposito();
                    Deposito Deposito = repositorio.Buscar(id);

                    if (Deposito != null)
                    {
                        LlenaCampos(Deposito);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "Popup", "alert('No existe')", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "Popup", "alert('Seleccione un ID')", true);
                }
            }
        }
    }
}