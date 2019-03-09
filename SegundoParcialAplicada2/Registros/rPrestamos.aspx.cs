using BLL;
using ENTIDADES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SegundoParcialAplicada2.Registros
{
    public partial class rPrestamos : System.Web.UI.Page
    {
        RepositorioBase<CuentaBancaria> repositorioBase = new RepositorioBase<CuentaBancaria>();
        RepositorioPrestamo repositorioPrestamo = new RepositorioPrestamo();
        List<CuotaDetalle> Detalle = new List<CuotaDetalle>();

        protected void Page_Load(object sender, EventArgs e)
        {

        }


        private Prestamo LlenaClase()
        {
            var Entidad = new Prestamo();

            Entidad.CuentaId = int.Parse(cuentaIdTextbox.Text);
            Entidad.Capital = decimal.Parse(capitalTextbox.Text);
            Entidad.Interes = decimal.Parse(interesTextbox.Text);
            Entidad.Tiempo = int.Parse(tiempoTextbox.Text);
            Entidad.Detalle = Detalle;

            return Entidad;
        }

        private void LlenaCampos(Prestamo Entidad)
        {
            CuentaBancaria cuenta = repositorioBase.Buscar(Entidad.CuentaId);
            prestamoIdTextbox.Text = Entidad.PrestamoId.ToString();
            fechaTextbox.Text = Entidad.Fecha.ToString("yyyy-MM-dd");
            cuentaIdTextbox.Text = cuenta.CuentaId.ToString();
            capitalTextbox.Text = Entidad.Capital.ToString();
            interesTextbox.Text = Entidad.Interes.ToString();
            tiempoTextbox.Text = Entidad.Tiempo.ToString();

            DatosGridView.DataSource = Entidad.Detalle.ToList();
            DatosGridView.DataBind();
        }

        void Limpiar()
        {
            prestamoIdTextbox.Text = "0";
            fechaTextbox.Text = DateTime.Today.ToString();
            cuentaIdTextbox.Text = "1";
            capitalTextbox.Text = "0";
            interesTextbox.Text = "0";
            tiempoTextbox.Text = "1";
            DatosGridView.Visible = true;
            DatosGridView.DataBind();
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            if (prestamoIdTextbox.Text == "0")
            {
                repositorioPrestamo.Guardar(LlenaClase());
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "Popup", "alert('Guardado con exito.')", true);
            }
            else
            {
                Prestamo prestamo = repositorioPrestamo.Buscar(int.Parse(prestamoIdTextbox.Text));

                prestamo = LlenaClase();

                repositorioPrestamo.Modificar(prestamo);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "Popup", "alert('Modificado con Exito.')", true);
            }
            Limpiar();
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(prestamoIdTextbox.Text);
            if (id != 0)
            {
                if (repositorioPrestamo.Buscar(id) != null)
                {
                    repositorioPrestamo.Eliminar(int.Parse(prestamoIdTextbox.Text));
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "Popup", "alert('Eliminado con exito')", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "Popup", "alert('No existe')", true);
                }
            }
            else
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "Popup", "alert('Seleccione un ID')", true);
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(prestamoIdTextbox.Text);
            if (id != 0)
            {
                if (repositorioPrestamo.Buscar(id) != null)
                {
                    LlenaCampos(repositorioPrestamo.Buscar(id));
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "Popup", "alert('No existe')", true);
                }
            }
            else
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "Popup", "alert('Seleccione un ID')", true);
        }

        protected void CalcularButton_Click(object sender, EventArgs e)
        {
            int acu = 1;
            double Capital = double.Parse(capitalTextbox.Text);
            double Interes = double.Parse(interesTextbox.Text) / 1200;
            double Tiempo = double.Parse(tiempoTextbox.Text);

            double Cuota = Capital * (Interes / (double)(1 - Math.Pow(1 + (double)Interes, -Tiempo)));
            double InteresMensual = 0, AmTotal = 0, Am = 0;
            Expression<Func<Prestamo, bool>> filtro = x => true;

            for (int i = 0; i < Tiempo; ++i)
            {
                CuotaDetalle Detalle1 = new CuotaDetalle();
                InteresMensual = Math.Round((Interes * Capital), 2);
                Capital = Math.Round(Capital - Cuota + InteresMensual, 2);

                AmTotal += Math.Round(Cuota - InteresMensual, 2);
                Am = Cuota - InteresMensual;
                Detalle1.PrestamoId = RepositorioPrestamo.GetList(filtro).Count + 1;
                Detalle1.ValorPrestamo = Math.Round((decimal)Cuota, 2);
                Detalle1.Capital = Math.Round((decimal)Am, 2);
                Detalle1.Interes = Math.Round((decimal)InteresMensual, 2);
                if (i == Tiempo - 1)
                {
                    decimal Aux = Math.Round((decimal)Capital, MidpointRounding.AwayFromZero);
                    if (Aux == 0)
                        Detalle1.Balance = (decimal)0.00;
                }
                else
                    Detalle1.Balance = Math.Round((decimal)Capital, 2);
                Detalle.Add(Detalle1);
                //repositorioPrestamo.Guardar(prestamo);
                ++acu;
            }
            DatosGridView.DataSource = Detalle;
            DatosGridView.DataBind();
        }
    }
}