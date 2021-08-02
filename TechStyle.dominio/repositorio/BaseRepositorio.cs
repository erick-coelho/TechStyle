using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStyle.dominio.Modelo;

namespace TechStyle.dominio.repositorio
{
    public class BaseRepositorio<T> where T : class, IEntity
    {
        public readonly Contexto Contexto;

        public BaseRepositorio()
        {
            Contexto = new Contexto();
        }

        public virtual bool Incluir(T entity)
        {
            try
            {
                Contexto.Set<T>().Add(entity);
                Contexto.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public virtual bool Alterar(T entity)
        {
            try
            {
                Contexto.Set<T>().Update(entity);
                Contexto.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public virtual T BuscarPorId(int id) => Contexto.Set<T>().FirstOrDefault(x => x.Id == id);


        public virtual IQueryable<T> BuscarTudo() => Contexto.Set<T>();

        public virtual bool Existe(T entity) => Contexto.Set<T>().Any(x => x == entity);
    }
}
