using System;
using System.Collections.Generic;
using System.Text;
using Junior.AppConstant;
using Microsoft.EntityFrameworkCore;
using Repository.Entity;

namespace Repository.ApplicationDbContext
{
	public class AppDbContext: DbContext
	{
		public AppDbContext(DbContextOptions options)	 : base(options)
		{
		}
		public AppDbContext()
		{
		}

		public DbSet<UserEntity> UserEntities{ get; set; }
		public DbSet<Book> Books{ get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				var connectionString = AppConfiguration.ConnectionStrings.DefaultConnection;
				optionsBuilder.UseSqlServer(connectionString);
			}
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<UserEntity>(entity =>
			{
				entity.Property(e => e.Name).IsRequired();
			});
			
		}
	}
}
