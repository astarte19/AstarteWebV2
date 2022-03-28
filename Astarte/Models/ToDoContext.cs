using System;

using Microsoft.EntityFrameworkCore;
namespace Astarte.Models
{
	public class ToDoContext : DbContext
	{
		public ToDoContext(DbContextOptions<ToDoContext> options) : base(options)
        {

        }

		public DbSet<TodoList> ToDoList { get; set; }
	}
}

