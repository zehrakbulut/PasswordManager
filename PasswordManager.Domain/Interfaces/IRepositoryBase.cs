using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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
