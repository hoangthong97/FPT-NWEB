using FA.JustBlog.Core;
using FA.JustBlog.Repository.Implement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FA.JustBlog.Controllers
{
    public class CategoryController : Controller
    {
        private readonly UnitOfWork unitOfWork = new UnitOfWork(new JustBlogContext());

        // GET: Category
        public ActionResult Index()
        {
            var cate = unitOfWork.CategoryRepository.GetAllCategories();
			if (cate==null)
			{
                return HttpNotFound();
			}
            return View(cate);
        }
    }
}