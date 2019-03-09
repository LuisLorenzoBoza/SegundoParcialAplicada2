﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDADES
{
    [Serializable]
    public class CuentaBancaria
    {
        [Key]
        public int CuentaId { get; set; }
        public DateTime Fecha { get; set; }
        public string Nombre { get; set; }
        public decimal Balance { get; set; }

        public CuentaBancaria()
        {
            CuentaId = 0;
            Fecha = DateTime.Now;
            Nombre = string.Empty;
            Balance = 0;
        }

        public CuentaBancaria(int id, DateTime fecha, string nombre, decimal balance)
        {
            CuentaId = id;
            Fecha = fecha;
            Nombre = nombre;
            Balance = balance;
        }
    }
}
