using Microsoft.EntityFrameworkCore;
using PasswordManager.Domain.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Infrastructure
{
	public class AppDbContext:DbContext
	{
		public DbSet<User> Users { get; set; }
		public DbSet<Password> Passwords { get; set; }

		public AppDbContext(DbContextOptions<AppDbContext> options) :base(options) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			// Password ile User arasındaki foreign key ilişkisini belirt
			modelBuilder.Entity<Password>()
				.HasOne(p => p.User)               // Her Password bir User'a ait olacak
				.WithMany(u => u.Password)         // Bir User birden fazla Password'a sahip olacak
				.HasForeignKey(p => p.UserId)      // Password'un UserId'si, User'un Id'sine karşılık gelecek
				.OnDelete(DeleteBehavior.Cascade); // User silindiğinde ona ait Password'lar da silinsin (isteğe bağlı)
		}
	}
}
