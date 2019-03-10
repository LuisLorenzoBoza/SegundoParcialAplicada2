using ENTIDADES;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Contexto : DbContext
    {
        public DbSet<CuentaBancaria> Cuentas { get; set; }

        public DbSet<Deposito> Depositos { get; set; }

        public DbSet<Prestamo> Deposito { get; set; }

        public DbSet<CuotaDetalle> Detalle { get; set; }

        public Contexto() : base("ConStr")
        {

        }
    }
}
