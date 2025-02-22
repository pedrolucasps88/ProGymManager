using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProGymManager.Dados
{
    public class DAL<T> where T : class
    {
        private readonly ProGymManagerContext context;

        public DAL(ProGymManagerContext context)
        {
            this.context = context;
        }

        public IEnumerable<T> listar()
        {
            return context.Set<T>().ToList();
        }

        public void Adicionar(T objeto)
        {
            context.Set<T>().Add(objeto);
            context.SaveChanges();
        }

        public void Atualizar(T objeto)
        {
            context.Set<T>().Update(objeto);
            context.SaveChanges();
        }

        public void Deletar(T objeto)
        {
            context.Set<T>().Remove(objeto);
            context.SaveChanges();
        }

        public T? RecuperarPor(Func<T, bool> condicao)
        {
            return context.Set<T>().FirstOrDefault(condicao);
        }
    }
}
