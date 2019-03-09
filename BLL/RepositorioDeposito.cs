using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RepositorioDeposito : RepositorioBase<Deposito>
    {
        public RepositorioDeposito() : base()
        {

        }

        public override bool Guardar(Deposito entity)
        {
            var cuenta = contexto.Cuentas.Find(entity.CuentaId);
            cuenta.Balance += entity.Monto;
            contexto.Entry(cuenta).State = EntityState.Modified;
            contexto.SaveChanges();

            return base.Guardar(entity);
        }

        public override bool Modificar(Deposito entity)
        {
            var depositoAnterior = contexto.Depositos.Include(x => x.Cuenta).Where(z => z.DepositoId == entity.DepositoId).AsNoTracking().FirstOrDefault();

            CuentaBancaria cuenta = depositoAnterior.Cuenta;
            cuenta.Balance -= depositoAnterior.Monto;
            cuenta.Balance += entity.Monto;
            contexto.Entry(cuenta).State = EntityState.Modified;
            contexto.SaveChanges();

            return base.Modificar(entity);
        }

        public override bool Eliminar(int id)
        {
            var deposito = Buscar(id);
            CuentaBancaria cuenta = deposito.Cuenta;

            cuenta.Balance -= deposito.Monto;
            contexto.Entry(cuenta).State = EntityState.Modified;
            contexto.SaveChanges();

            return base.Eliminar(id);
        }
    }
}
