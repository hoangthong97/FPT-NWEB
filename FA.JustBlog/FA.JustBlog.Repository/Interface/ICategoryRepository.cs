using FA.JustBlog.Core.Model;
using System.Collections.Generic;

namespace FA.JustBlog.Repository.Interface
{
	public interface ICategoryRepository
	{
		void AddCategory(Category category);
		void DeleteCategory(Category category);
		void UpdateCategory(Category category);
		Category Find(int categoryId);
		List<Category> GetAllCategories();
	}
}
