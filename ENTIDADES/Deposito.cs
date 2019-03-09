using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDADES
{
    public class Deposito
    {
        [Key]
        public int DepositoId { get; set; }
        public int CuentaId { get; set; }
        public DateTime Fecha { get; set; }
        public string Concepto { get; set; }
        public decimal Monto { get; set; }
        public virtual CuentaBancaria Cuenta { get; set; }

        public Deposito()
        {
            DepositoId = 0;
            CuentaId = 0;
            Fecha = DateTime.Now;
            Concepto = string.Empty;
            Monto = 0;
        }

        public Deposito(int id, int cuentaId, DateTime fecha, string concepto, decimal monto)
        {
            DepositoId = id;
            CuentaId = cuentaId;
            Fecha = fecha;
            Concepto = concepto;
            Monto = monto;
        }
    }
}
