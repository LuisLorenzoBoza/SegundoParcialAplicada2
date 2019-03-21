using BLL;
using ENTIDADES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SegundoParcialAplicada2.Utilitarios;

namespace SegundoParcialAplicada2.Registros
{
    public partial class rPrestamos : System.Web.UI.Page
    {
        List<CuotaMensual> listDetalle = new List<CuotaMensual>();

        protected void Page_Load(object sender, EventArgs e)
        {
            fechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");

            if (!Page.IsPostBack)
            {
                Repositorio<CuentaBancaria> repositorio = new Repositorio<CuentaBancaria>();

                cuentaDropDownList.DataSource = repositorio.GetList(t => true);
                cuentaDropDownList.DataValueField = "CuentaBancariaId";
                cuentaDropDownList.DataTextField = "Nombre";
                cuentaDropDownList.DataBind();

                ViewState["Prestamo"] = new Prestamo();
            }
        }

        private int ToInt(object valor)
        {
            int retorno = 0;
            int.TryParse(valor.ToString(), out retorno);

            return retorno;
        }
        private double ToDouble(object valor)
        {
            double retorno = 0;
            double.TryParse(valor.ToString(), out retorno);

            return Convert.ToDouble(retorno);
        }

        public Prestamo LlenarClase()
        {
            Prestamo prestamo = new Prestamo();

            prestamo = (Prestamo)ViewState["Prestamo"];
            listDetalle = (List<CuotaMensual>)prestamoGridView.DataSource;

            prestamo.PrestamoId = Utils.ToInt(prestamoIdTextBox.Text);
            prestamo.Fecha = Convert.ToDateTime(fechaTextBox.Text).Date;
            prestamo.CuentaId = ToInt(cuentaDropDownList.SelectedValue);
            prestamo.Capital = ToInt(capitalTextBox.Text);
            prestamo.PctInteres = ToInt(pctIntTextBox.Text);
            prestamo.TiempoMeses = ToInt(tieMesTextBox.Text);
            prestamo.Total = ToInt(totalTextBox.Text);
            prestamo.Detalle = listDetalle;

            return prestamo;
        }

        protected void BindGrid()
        {
            prestamoGridView.DataSource = ((Prestamo)ViewState["Prestamo"]).Detalle;
            prestamoGridView.DataBind();
        }

        public void LlenarCampos(Prestamo prestamo)
        {
            Limpiar();
            prestamoIdTextBox.Text = prestamo.PrestamoId.ToString();
            fechaTextBox.Text = prestamo.Fecha.ToString("yyyy-MM-dd");
            cuentaDropDownList.SelectedValue = prestamo.CuentaId.ToString();
            capitalTextBox.Text = prestamo.Capital.ToString();
            pctIntTextBox.Text = prestamo.PctInteres.ToString();
            tieMesTextBox.Text = prestamo.TiempoMeses.ToString();
            prestamoGridView.DataSource = prestamo.Detalle.ToList();
            this.BindGrid();
            totalTextBox.Text = prestamo.Total.ToString();
        }
        protected void Limpiar()
        {
            prestamoIdTextBox.Text = "0";
            fechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            cuentaDropDownList.SelectedIndex = 0;
            capitalTextBox.Text = "";
            pctIntTextBox.Text = "";
            tieMesTextBox.Text = "";
            totalTextBox.Text = "";
            ViewState["Prestamo"] = new Prestamo();
            this.BindGrid();
        }

        private bool HayErrores()
        {
            bool HayErrores = false;

            if (prestamoGridView.Rows.Count == 0)
            {
                Utils.ShowToastr(this, "Debe calcular su Préstamo.", "Error", "error");
                HayErrores = true;
            }
            if (ToInt(cuentaDropDownList.SelectedValue) < 1)
            {
                Utils.ShowToastr(this, "Debe Seleccionar una Cuenta que haya guardada.", "Error", "error");
                HayErrores = true;
            }
            return HayErrores;
        }
    }
}