using FA.JustBlog.Core;
using FA.JustBlog.Core.Model;
using FA.JustBlog.Repository.Interface;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace FA.JustBlog.Repository.Implement
{
	public class CategoryRepository : ICategoryRepository
	{
		private readonly JustBlogContext db;
		public CategoryRepository()
		{
			db = new JustBlogContext();
		}
		public void AddCategory(Category category)
		{
			db.Categories.Add(category);
			db.SaveChanges();
		}

		public void DeleteCategory(Category category)
		{
			var cate = db.Categories.Find(category.CategoryId);
			db.Categories.Remove(cate);
			db.SaveChanges();
		}

		public Category Find(int categoryId)
		{
			return db.Categories.Find(categoryId);

		}

		public List<Category> GetAllCategories()
		{
			return db.Categories.ToList();
		}

		public void UpdateCategory(Category category)
		{
			db.Entry(category).State = EntityState.Modified;
			db.SaveChanges();
		}
	}
}
