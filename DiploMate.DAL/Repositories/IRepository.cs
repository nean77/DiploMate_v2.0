using Microsoft.AspNetCore.Mvc;

namespace DiploMate.DAL.Repositories;

public interface IRepository<T> where T : class
{
    Task<T> GetAsync(Guid id);
    Task<IEnumerable<T>> GetListAsync();
    Task<Guid> InsertAsync(T entity);
    Task<T> UpdateAsync(Guid id, T entity);
    Task DeleteAsync(Guid id);

}