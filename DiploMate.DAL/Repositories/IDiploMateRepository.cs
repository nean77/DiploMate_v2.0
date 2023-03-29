namespace DiploMate.DAL;

public interface IDiploMateRepository<T> where T : class
{
    Task<T> GetAsync(object id);
    Task<IEnumerable<T>> GetListAsync();
    Task<T> InsertAsync(T entity);
    Task<T> UpdateAsync(object id, T entity);
    Task DeleteAsync(object id);
}