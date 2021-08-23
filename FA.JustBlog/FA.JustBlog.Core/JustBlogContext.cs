using FA.JustBlog.Core.Migrations;
using FA.JustBlog.Core.Model;
using System;
using System.Data.Entity;

namespace FA.JustBlog.Core
{
	public class JustBlogContext : DbContext
	{
		public JustBlogContext() : base("name=DefaultConnection")
		{
			//Database.SetInitializer(new JustBlogInitializer());
			Database.SetInitializer(new MigrateDatabaseToLatestVersion<JustBlogContext, Configuration>());
		}

		public virtual DbSet<Post> Posts { get; set; }
		public virtual DbSet<Category> Categories { get; set; }
		public virtual DbSet<Tag> Tags { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			//Write Fluent API configurations here
			modelBuilder.Properties<DateTime>().Configure(c => c.HasColumnType("datetime2"));
		}
	}
}