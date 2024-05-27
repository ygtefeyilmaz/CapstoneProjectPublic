

using DataAccessLayer.Models;
using DataAccessLayer.Abstract;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Concrete;

namespace DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        public void Insert(T t)
        {
            using var c = new Context();
            c.Add(t);
            c.SaveChanges();
        }
        public void Update(T t)
        {
            using var c = new Context();
            c.Update(t);
            c.SaveChanges();
        }
        public void Delete(T t)
        {
            using var c = new Context();
            c.Remove(t);
            c.SaveChanges();
        }
        public List<T> GetListAll()
        {
            using var c = new Context();
            return c.Set<T>().ToList();

        }
        public T GetByID(int id)
        {
            using var c = new Context();
            return c.Set<T>().Find(id)!;
        }
        public async Task<T> GetByIdAsync(int id)
        {
            using var c = new Context();
            return await c.Set<T>().FindAsync(id);
        }
        public async Task<int> AddAsync(T t)
        {
            using var c = new Context();
            c.Set<T>().AddAsync(t);
            return await c.SaveChangesAsync();
        }
        public async Task<int> UpdateAsync(T t)
        {
            using var c = new Context();
            c.Set<T>().Update(t);
            return await c.SaveChangesAsync();
        }
        public async Task<int> DeleteAsync(T t)
        {
            using var c = new Context();
            c.Set<T>().Remove(t);
            return await c.SaveChangesAsync();
        }

        public async Task<List<T>> GetListAllAsync()
        {
            using var c = new Context();
            return await c.Set<T>().ToListAsync();
        }
    }
}
