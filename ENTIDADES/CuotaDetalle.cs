using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDADES
{
    [Serializable]
    public class CuotaDetalle
    {
        [Key]
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int PrestamoId { get; set; }
        public int NumeroCuota { get; set; }
        public int CuentaId { get; set; }
        public decimal Interes { get; set; }
        public decimal Capital { get; set; }
        public decimal Valor { get; set; }
        public decimal Balance { get; set; }

        [ForeignKey("CuentaId")]
        public virtual CuentaBancaria CuentaBancaria { get; set; }


        public CuotaDetalle()
        {
            Id = 0;
            Fecha = DateTime.Now;
            PrestamoId = 0;
            NumeroCuota = 0;
            CuentaId = 0;
            Interes = 0;
            Capital = 0;
            Valor = 0;
            Balance = 0;
        }

        public CuotaDetalle(int id, DateTime fecha, int prestamoId, int numeroCuota, int cuentaId, decimal interes, decimal capitalMensual, decimal valor, decimal balance)
        {
            Id = id;
            Fecha = fecha;
            PrestamoId = prestamoId;
            NumeroCuota = numeroCuota;
            CuentaId = cuentaId;
            Interes = interes;
            Capital = capitalMensual;
            Valor = valor;
            Balance = balance;
        }
    }
}



