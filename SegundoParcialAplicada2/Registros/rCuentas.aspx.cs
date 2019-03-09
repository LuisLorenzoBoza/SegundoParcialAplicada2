using BLL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SegundoParcialAplicada2.Registros
{
    public partial class rCuentas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        void Limpiar()
        {
            cuentaIdTextbox.Text = "0";
            fechaTextbox.Text = string.Empty;
            nombreTextbox.Text = string.Empty;
            balanceTextbox.Text = "0";
        }

        private void LlenaCampos(CuentaBancaria cuenta)
        {
            cuentaIdTextbox.Text = cuenta.CuentaId.ToString();
            fechaTextbox.Text = cuenta.Fecha.ToString("yyyy-MM-dd");
            nombreTextbox.Text = cuenta.Nombre;
            balanceTextbox.Text = cuenta.Balance.ToString();
        }

        private CuentaBancaria LlenaClase()
        {
            var cuenta = new CuentaBancaria();
            cuenta.Fecha = Convert.ToDateTime(fechaTextbox.Text);
            cuenta.Nombre = nombreTextbox.Text;
            cuenta.Balance = 0;

            return cuenta;
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(cuentaIdTextbox.Text);
            if (!(String.IsNullOrEmpty(nombreTextbox.Text) || String.IsNullOrEmpty(fechaTextbox.Text)))
            {
                RepositorioBase<CuentaBancaria> repositorio = new RepositorioBase<CuentaBancaria>();
                if (id == 0)
                {
                    repositorio.Guardar(LlenaClase());
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "Popup", "alert('Guardado con Exito')", true);
                }
                else
                {
                    if (repositorio.Buscar(id) != null)
                    {
                        CuentaBancaria cuenta = repositorio.Buscar(int.Parse(cuentaIdTextbox.Text));

                        cuenta.CuentaId = int.Parse(cuentaIdTextbox.Text);
                        cuenta.Fecha = DateTime.Parse(fechaTextbox.Text);
                        cuenta.Nombre = nombreTextbox.Text;
                        cuenta.Balance = Decimal.Parse(balanceTextbox.Text);

                        repositorio.Modificar(cuenta);
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
            int id = Convert.ToInt32(cuentaIdTextbox.Text);
            if (id != 0)
            {
                RepositorioBase<CuentaBancaria> repositorio = new RepositorioBase<CuentaBancaria>();
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
            if (!String.IsNullOrEmpty(cuentaIdTextbox.Text))
            {
                int id = Convert.ToInt32(cuentaIdTextbox.Text);
                if (id != 0)
                {
                    RepositorioBase<CuentaBancaria> repositorio = new RepositorioBase<CuentaBancaria>();
                    CuentaBancaria CuentaBancaria = repositorio.Buscar(id);

                    if (CuentaBancaria != null)
                    {
                        LlenaCampos(CuentaBancaria);
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