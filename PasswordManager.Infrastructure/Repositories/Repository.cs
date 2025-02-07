using Microsoft.EntityFrameworkCore;
using PasswordManager.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Infrastructure.Repositories
{
	public class Repository<T>(AppDbContext context) : IRepositoryBase<T> where T : class
	{
		private readonly AppDbContext _context = context;
		public async Task AddAsync(T entity)
		{
			_context.Set<T>().Add(entity);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(T entity)
		{
			_context.Set<T>().Remove(entity);
			var deleted = await _context.SaveChangesAsync();
		}

		public async Task<ICollection<T>> GetAllAsync()
		{
			return await _context.Set<T>().ToListAsync();
		}

		public async Task<T> GetByIdAsync(int id)
		{
			return await _context.Set<T>().FindAsync(id);
		}
		public async Task UpdateAsync(T entity)
		{
			_context.Set<T>().Attach(entity); // Entity'i DbContext'e ekle
			_context.Entry(entity).State = EntityState.Modified; // Entity'i güncellenmiş olarak işaretle
			await _context.SaveChangesAsync(); // Değişiklikleri kaydet
		}
	}
}
