using FA.JustBlog.Core;
using FA.JustBlog.Core.Model;
using FA.JustBlog.Repository.Implement;
using System.Web.Mvc;

namespace FA.JustBlog.Areas.Admin.Controllers
{
	public class CategoryController : Controller
	{
		private readonly UnitOfWork unitOfWork = new UnitOfWork(new JustBlogContext());

		// GET: Admin/Category
		[AllowAnonymous]
		public ActionResult Index()
		{
			return View(unitOfWork.CategoryRepository.GetAllCategories());
		}

		[AllowAnonymous]
		public ActionResult AddCategory()
		{
			return View();
		}

		[HttpPost]
		[Authorize(Roles = "Admin,Contributor")]
		public ActionResult AddCategory(Category category)
		{
			if (ModelState.IsValid)
			{
				if (category != null)
				{
					unitOfWork.CategoryRepository.AddCategory(category);
					return RedirectToAction("Index", "Category");
				}
			}

			return View();
		}

		[AllowAnonymous]
		public ActionResult Details(int id)
		{
			var cate = unitOfWork.CategoryRepository.Find(id);
			if (cate == null)
				return HttpNotFound();
			return View(cate);
		}

		[Authorize(Roles = "Admin,Contributor")]
		public ActionResult Edit(int id)
		{
			var cate = unitOfWork.CategoryRepository.Find(id);
			return View(cate);
		}

		[HttpPost]
		[Authorize(Roles = "Admin,Contributor")]
		public ActionResult Edit(Category category)
		{
			unitOfWork.CategoryRepository.UpdateCategory(category);
			return RedirectToAction("Index");
		}

		[Authorize(Roles = "Admin")]
		public ActionResult Delete(int id)
		{
			Category cateExisting = unitOfWork.CategoryRepository.Find(id);
			return View(cateExisting);
		}

		[HttpPost]
		[Authorize(Roles = "Admin")]
		public ActionResult Delete(int id, Category category)
		{
			Category cateExisting = unitOfWork.CategoryRepository.Find(id);
			unitOfWork.CategoryRepository.DeleteCategory(cateExisting);
			return RedirectToAction("Index");
		}
	}
}