using Dominio.Entity;
using Dominio.Interfaces;
using Infra.Conexao;

namespace Infra.Repositorio
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly ApplicationContext _SqlContext;

        public Repository(ApplicationContext SqlContext)
        {
            _SqlContext = SqlContext;
        }

        public void Insert(TEntity obj)
        {
            _SqlContext.Set<TEntity>().Add(obj);
            _SqlContext.SaveChanges();
        }

        public void Update(TEntity obj)
        {
            _SqlContext.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _SqlContext.SaveChanges();
        }

        public void Delete(int id)
        {
            _SqlContext.Set<TEntity>().Remove(Select(id));
            _SqlContext.SaveChanges();
        }

        public IList<TEntity> Select() =>
            _SqlContext.Set<TEntity>().ToList();

        public TEntity Select(int id) =>
            _SqlContext.Set<TEntity>().Find(id);

    }
}
