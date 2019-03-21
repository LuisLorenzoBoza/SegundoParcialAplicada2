using BLL;
using ENTIDADES;
using SegundoParcialAplicada2.Utilitarios;
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
            fechaTextbox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            balanceTextbox.Text = "0";
        }


        void Limpiar()
        {
            cuentaBancariaIdTextBox.Text = "0";
            fechaTextbox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            nombreTextbox.Text = " ";
            balanceTextbox.Text = "0";
        }

        private CuentaBancaria LlenaClase()
        {
            CuentaBancaria cuenta = new CuentaBancaria();

            cuenta.CuentaBancariaId = Utils.ToInt(cuentaBancariaIdTextBox.Text);
            cuenta.Fecha = Convert.ToDateTime(fechaTextbox.Text).Date;
            cuenta.Nombre = nombreTextbox.Text;
            cuenta.Balance = Utils.ToInt(balanceTextbox.Text);

            return cuenta;

        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            BLL.Repositorio<CuentaBancaria> repositorio = new BLL.Repositorio<CuentaBancaria>();
            CuentaBancaria cuenta = new CuentaBancaria();
            bool paso = false;

            //todo: validaciones adicionales
            cuenta = LlenaClase();

            if (cuenta.CuentaBancariaId == 0)
            {
                paso = repositorio.Guardar(cuenta);
                Utils.ShowToastr(this, "Guardado", "Exito", "success");
                Limpiar();
            }
            else
            {
                int id = Utils.ToInt(cuentaBancariaIdTextBox.Text);
                BLL.Repositorio<CuentaBancaria> repository = new BLL.Repositorio<CuentaBancaria>();
                cuenta = repository.Buscar(id);

                if (cuenta != null)
                {
                    paso = repositorio.Modificar(LlenaClase());
                    Utils.ShowToastr(this, "Modificado", "Exito", "success");
                }
                else
                    Utils.ShowToastr(this, "Id no existe", "Error", "error");
            }

            if (paso)
            {
                Limpiar();
            }
            else
                Utils.ShowToastr(this, "No se pudo guardar", "Error", "error");
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            BLL.Repositorio<CuentaBancaria> repositorio = new BLL.Repositorio<CuentaBancaria>();
            int id = Utils.ToInt(cuentaBancariaIdTextBox.Text);

            var cuenta = repositorio.Buscar(id);

            if (cuenta != null)
            {
                if (repositorio.Eliminar(id))
                {
                    Utils.ShowToastr(this, "Eliminado", "Exito", "success");
                    Limpiar();
                }
                else
                    Utils.ShowToastr(this, "No se pudo eliminar", "Error", "error");
            }
            else
                Utils.ShowToastr(this, "No existe", "Error", "error");
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            Repositorio<CuentaBancaria> repositorio = new Repositorio<CuentaBancaria>();
            CuentaBancaria cuenta = repositorio.Buscar(Utils.ToInt(cuentaBancariaIdTextBox.Text));
            if (cuenta != null)
            {
                fechaTextbox.Text = cuenta.Fecha.ToString();
                nombreTextbox.Text = cuenta.Nombre;
                balanceTextbox.Text = cuenta.Balance.ToString();
                Utils.ShowToastr(this, "Busqueda exitosa", "Exito", "success");
            }
            else
            {
                Utils.ShowToastr(this, "No Hay Resultado", "Error", "error");
            }
        }
    }
}