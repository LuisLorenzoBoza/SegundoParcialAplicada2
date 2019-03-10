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
    public class RepositorioPrestamo : RepositorioBase<Prestamo>
    {
        

        public override Prestamo Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Prestamo prestamo = contexto.Deposito.Include(x => x.Detalle).Where(z => z.PrestamoId == id).FirstOrDefault();

            return prestamo;
        }

        public override bool Guardar(Prestamo entity)
        {
            Contexto contexto = new Contexto();
            var cuenta = contexto.Cuentas.Find(entity.CuentaId);
            cuenta.Balance += entity.Capital;
            contexto.Entry(cuenta).State = EntityState.Modified;
            contexto.SaveChanges();

            return base.Guardar(entity);
        }

        public override bool Modificar(Prestamo entity)
        {
            Contexto contexto = new Contexto();
            var prestamoAnterior = contexto.Deposito.Include(x => x.Detalle).Where(z => z.PrestamoId == entity.PrestamoId).AsNoTracking().FirstOrDefault();

            var prestamo = prestamoAnterior;
            var cuenta = contexto.Cuentas.Find(entity.CuentaId);
            cuenta.Balance -= prestamoAnterior.Capital;
            contexto.Entry(cuenta).State = EntityState.Modified;

            foreach (var item in prestamoAnterior.Detalle)
                contexto.Entry(item).State = EntityState.Deleted;

            foreach (var item in entity.Detalle)
                contexto.Entry(item).State = (item.Id == 0) ? EntityState.Added : EntityState.Modified;


            cuenta.Balance += entity.Capital;
            contexto.Entry(cuenta).State = EntityState.Modified;

            return base.Modificar(entity);
        }

        public static object NPrestamos(Expression<Func<CuentaBancaria, bool>> filtro)
        {
            throw new NotImplementedException();
        }

        public override bool Eliminar(int id)
        {
            Contexto contexto = new Contexto();
            var prestamo = Buscar(id);
            CuentaBancaria cuenta = prestamo.Cuenta;
            cuenta.Balance -= prestamo.Capital;
            contexto.Entry(cuenta).State = EntityState.Modified;

            return base.Eliminar(id);
        }


        public static int ToInt(string valor)
        {
            int retorno = 0;
            int.TryParse(valor, out retorno);

            return retorno;
        }

       

        public static List<CuentaBancaria> NCuentas(Expression<Func<CuentaBancaria, bool>> filtro)
        {
            filtro = p => true;
            RepositorioBase<CuentaBancaria> repositorio = new RepositorioBase<CuentaBancaria>();
            List<CuentaBancaria> list = new List<CuentaBancaria>();

            list = repositorio.GetList(filtro);

            return list;
        }

        

        public static List<Prestamo> NPrestamos(Expression<Func<Prestamo, bool>> filtro)
        {
            filtro = p => true;
            RepositorioBase<Prestamo> repositorio = new RepositorioBase<Prestamo>();
            List<Prestamo> list = new List<Prestamo>();

            list = repositorio.GetList(filtro);

            return list;


        }
}