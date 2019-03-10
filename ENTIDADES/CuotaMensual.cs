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
    public class CuotaMensual
    {
        [Key]
        public int Id { get; set; }
        public int PrestamoId { get; set; }
        public decimal Interes { get; set; }
        public decimal Capital { get; set; }
        public decimal ValorPrestamo { get; set; }
        public decimal Balance { get; set; }


        [ForeignKey("CuentaId")]
        public virtual CuentaBancaria CuentaBancaria { get; set; }
        

        public CuotaMensual()
        {
            Id = 0;
            PrestamoId = 0;
            Interes = 0;
            Capital = 0;
            ValorPrestamo = 0;
            Balance = 0;
           
        }

        public CuotaMensual(int id, int prestamoId, decimal interes, decimal capital, decimal valor, decimal balance)
        {
            Id = id;
            PrestamoId = prestamoId;
            Interes = interes;
            Capital = capital;
            ValorPrestamo = valor;
            Balance = balance;
            
        }
    }
}
