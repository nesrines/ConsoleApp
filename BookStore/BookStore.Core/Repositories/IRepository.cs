using BookStore.Core.Models.Base;
namespace BookStore.Core.Repositories
{
    public interface IRepository<T> where T: BaseModel
    {
        public Task AddAsync(T model);
        public Task RemoveAsync(T model);
        public Task<T> GetAsync(Func<T, bool> expression);
        public Task<List<T>> GetAllAsync();
    }
}