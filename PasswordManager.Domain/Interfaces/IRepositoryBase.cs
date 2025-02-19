using System.Linq.Expressions;

namespace PasswordManager.Domain.Interfaces
{
	public interface IRepositoryBase<T> where T : class
	{
		Task<ICollection<T>> GetAllAsync();
		Task<ICollection<T>> GetAllAsync(Expression<Func<T, bool>> predicate); 
		Task<T> GetByIdAsync(int id);
		Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate);
		Task AddAsync(T entity);
		Task UpdateAsync(T entity);
		Task DeleteAsync(T entity);
		Task SaveChangesAsync();
	}
}
