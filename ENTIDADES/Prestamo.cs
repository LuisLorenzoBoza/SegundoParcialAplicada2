using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDADES
{
    [Serializable]
    public class Prestamo
    {
        [Key]
        public int PrestamoId { get; set; }
        public DateTime Fecha { get; set; }
        public int CuentaId { get; set; }
        public decimal Capital { get; set; }
        public decimal Interes { get; set; }
        public int Tiempo { get; set; }
        public int Total { get; set; }

        public virtual CuentaBancaria Cuenta { get; set; }
        public virtual List<CuotaMensual> Detalle { get; set; }


        public Prestamo()
        {
            this.Detalle = new List<CuotaMensual>();
        }

        public void AgregarDetalle(int Id, DateTime Fecha, int PrestamoId, int NumeroCuota, int CuentaId, double Interes, double Capital, double Balance)
        {
            this.Detalle.Add(new CuotaMensual(Id, Fecha, PrestamoId, NumeroCuota, CuentaId, Interes, Capital, Balance));
        }
    }
}
