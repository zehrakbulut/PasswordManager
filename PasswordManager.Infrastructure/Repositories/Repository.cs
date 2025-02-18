using Microsoft.EntityFrameworkCore;
using PasswordManager.Domain.Interfaces;
using System.Linq.Expressions;

namespace PasswordManager.Infrastructure.Repositories
{
	public class Repository<T> : IRepositoryBase<T> where T : class
	{
		private readonly AppDbContext _context;

		public Repository(AppDbContext context)
		{
			_context = context;
		}

		public async Task AddAsync(T entity)
		{
			_context.Set<T>().Add(entity);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(T entity)
		{
			_context.Set<T>().Remove(entity);
			await _context.SaveChangesAsync();
		}

		public async Task<ICollection<T>> GetAllAsync()
		{
			return await _context.Set<T>().ToListAsync();
		}
		public async Task<ICollection<T>> GetAllAsync(Expression<Func<T, bool>> predicate)
		{
			return await _context.Set<T>().Where(predicate).ToListAsync();
		}

		public async Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate)
		{
			return await _context.Set<T>().FirstOrDefaultAsync(predicate);
		}

		public async Task<T> GetByIdAsync(int id)
		{
			return await _context.Set<T>().FindAsync(id);
		}

		public async Task UpdateAsync(T entity)
		{
			_context.Set<T>().Update(entity);
			await _context.SaveChangesAsync();
		}
		public async Task SaveChangesAsync()
		{
			await _context.SaveChangesAsync();
		}
	}
}
