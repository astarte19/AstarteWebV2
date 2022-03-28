using System;
using Microsoft.EntityFrameworkCore;
namespace Astarte.Models
{
	public class FinanceContext : DbContext
	{
		public FinanceContext(DbContextOptions<FinanceContext> options) : base(options)
        {
			
        }

		public DbSet<Finance> Finances { get; set; }
	}
}

