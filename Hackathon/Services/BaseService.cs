using Hackathon.Data;

namespace Hackathon.Services
{
    public interface IBaseService<T>
        where T: class
    {
        Task<T> Insert(T entity);
        Task<bool> Delete(int id);
        Task<T> Update(T entity);
        Task<List<T>> GetAll();
        Task<T> GetById(int id);
    }
    public abstract class BaseService<T> : IBaseService<T>
        where T: class
    {
        protected DataContext _context;
        protected BaseService(DataContext context) 
        { 
            _context = context;
        }

        public abstract Task<bool> Delete(int id);
        public abstract Task<List<T>> GetAll();
        public abstract Task<T> GetById(int id);
        
        public async Task<T> Insert(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Update(T entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
