using FA.JustBlog.Core;
using FA.JustBlog.Repository.Implement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FA.JustBlog.Areas.Admin.Controllers
{
	
	public class PostController : Controller
	{
		private readonly UnitOfWork unitOfWork = new UnitOfWork(new JustBlogContext());

		// GET: Admin/Post
		[AllowAnonymous]
		public ViewResult Index()
		{
			return View();
		}
		[AllowAnonymous]
		public PartialViewResult IndexGrid()
		{
			return PartialView("_IndexGrid", unitOfWork.PostRepository.GetAllPosts());
		}

		//public ActionResult Index()
		//{
		//	return View(unitOfWork.PostRepository.GetAllPosts());
		//}
		[Authorize(Roles = "Admin,Contributor")]
		public ActionResult AddPost()
		{
			ViewBag.categories = new SelectList(unitOfWork.CategoryRepository.GetAllCategories(), "CategoryId", "Name");
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		[ValidateInput(false)]
		[Authorize(Roles = "Admin,Contributor")]
		public ActionResult AddPost(Post post)
		{
			if (ModelState.IsValid)
			{
				ViewBag.categories = new SelectList(unitOfWork.CategoryRepository.GetAllCategories(), "CategoryId", "Name");

				if (post != null)
				{
					unitOfWork.PostRepository.AddPost(post);
					return RedirectToAction("Index", "Home");
				}
			}

			return View();
		}
		[AllowAnonymous]
		public ActionResult Details(int id)
		{
			var post = unitOfWork.PostRepository.Find(id);
			if (post == null)
				return HttpNotFound();
			return View(post);
		}

		[Authorize(Roles = "Admin,Contributor")]
		public ActionResult Edit(int id)
		{
			ViewBag.categories = new SelectList(unitOfWork.CategoryRepository.GetAllCategories(), "CategoryId", "Name");
			var post = unitOfWork.PostRepository.Find(id);
			return View(post);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		[ValidateInput(false)]
		[Authorize(Roles = "Admin,Contributor")]
		public ActionResult Edit(Post post)
		{		
			unitOfWork.PostRepository.UpdatePost(post);
			return RedirectToAction("Index");

		}

		[Authorize(Roles = "Admin")]
		public ActionResult Delete(int id)
		{
			Post postExisting = unitOfWork.PostRepository.Find(id);
			return View(postExisting);
		}
		[HttpPost]
		[Authorize(Roles = "Admin")]
		public ActionResult Delete(int id, Post post)
		{
			Post postExisting = unitOfWork.PostRepository.Find(id);
			unitOfWork.PostRepository.DeletePost(postExisting);
			return RedirectToAction("Index");
		}

		public ActionResult LatestPosts()
		{
			var lastPost = unitOfWork.PostRepository.GetLatestPost();
			return View(lastPost);
		}

		public ActionResult MostViewedPosts()
		{
			var mostView = unitOfWork.PostRepository.GetMostViewedPost();
			return View(mostView);
		}

		[Authorize(Roles = "Admin")]
		public ActionResult Published()
		{
			var mostView = unitOfWork.PostRepository.GetPublished();
			return View(mostView);
		}

		[Authorize(Roles = "Admin")]
		public ActionResult UnPublished()
		{
			var mostView = unitOfWork.PostRepository.GetUnPublished();
			return View(mostView);
			//return Json(new { rows = mostView }, JsonRequestBehavior.AllowGet);
		}

	}
}