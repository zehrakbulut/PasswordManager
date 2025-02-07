using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Domain.Interfaces
{
	public interface IRepositoryBase<T> where T : class
	{
		Task<ICollection<T>> GetAllAsync();
		Task<T> GetByIdAsync(int id);
		Task AddAsync(T entity);
		Task UpdateAsync(T entity);
		Task DeleteAsync(T entity);
	}
}
