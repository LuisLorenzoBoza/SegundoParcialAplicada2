﻿using ENTIDADES;
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
                        filtro = c => c.CuentaId == id;
                        break;
                    case 2://Nombre
                        filtro = c => c.Nombre.Contains(FiltroTextBox.Text);
                        break;
                }

                DatosGridView.DataSource = repositorio.GetList(filtro);
                DatosGridView.DataBind();
            }
        }

        protected void ImprimirButton_Click(object sender, EventArgs e)
        {
            Response.Write("<script>window.open('../../Reportes/ReportCuentaBancaria.aspx','_blanck');</script");
        }
    }
}