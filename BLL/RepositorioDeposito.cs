using DAL;
using ENTIDADES;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RepositorioDeposito : RepositorioBase<Deposito>
    {
        public override bool Guardar(Deposito entity)
        {
            Contexto contexto = new Contexto();
            var cuenta = contexto.Cuentas.Find(entity.CuentaId);
            cuenta.Balance += entity.Monto;
            contexto.Entry(cuenta).State = EntityState.Modified;
            contexto.SaveChanges();

            return base.Guardar(entity);
        }

        public override bool Modificar(Deposito entity)
        {
            Contexto contexto = new Contexto();
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
            Contexto contexto = new Contexto();
            var deposito = Buscar(id);
            CuentaBancaria cuenta = deposito.Cuenta;

            cuenta.Balance -= deposito.Monto;
            contexto.Entry(cuenta).State = EntityState.Modified;
            contexto.SaveChanges();

            return base.Eliminar(id);
        }


        public static int ToInt(string valor)
        {
            int retorno = 0;
            int.TryParse(valor, out retorno);

            return retorno;
        }

        public static List<Deposito> NDepositos(Expression<Func<Deposito, bool>> filtro)
        {
            filtro = p => true;
            RepositorioBase<Deposito> repositorio = new RepositorioBase<Deposito>();
            List<Deposito> list = new List<Deposito>();

            list = repositorio.GetList(filtro);

            return list;
        }
    }
}
