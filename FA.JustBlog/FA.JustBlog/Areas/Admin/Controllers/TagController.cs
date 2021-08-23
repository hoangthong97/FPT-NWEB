using FA.JustBlog.Core;
using FA.JustBlog.Core.Model;
using FA.JustBlog.Repository.Implement;
using System.Web.Mvc;

namespace FA.JustBlog.Areas.Admin.Controllers
{
	public class TagController : Controller
    {
		private readonly UnitOfWork unitOfWork = new UnitOfWork(new JustBlogContext());
		// GET: Admin/Category
		[AllowAnonymous]
		public ActionResult Index()
		{
			return View(unitOfWork.TagRepository.GetAllTags());
		}

		[Authorize(Roles = "Admin,Contributor")]
		public ActionResult AddTag()
		{
			return View();
		}

		[HttpPost]
		[Authorize(Roles = "Admin,Contributor")]
		public ActionResult AddTag(Tag tag)
		{
			if (ModelState.IsValid)
			{
				if (tag != null)
				{
					unitOfWork.TagRepository.AddTag(tag);
					return RedirectToAction("Index", "Tag");
				}
			}

			return View();
		}

		[AllowAnonymous]
		public ActionResult Details(int id)
		{
			var tag = unitOfWork.TagRepository.Find(id);
			if (tag == null)
				return HttpNotFound();
			return View(tag);
		}

		[Authorize(Roles = "Admin,Contributor")]
		public ActionResult Edit(int id)
		{
			var tag = unitOfWork.TagRepository.Find(id);
			return View(tag);
		}

		[HttpPost]
		[Authorize(Roles = "Admin,Contributor")]
		public ActionResult Edit(Tag tag)
		{
			unitOfWork.TagRepository.UpdateTag(tag);
			return RedirectToAction("Index");

		}

		[Authorize(Roles ="Admin")]
		public ActionResult Delete(int id)
		{
			Tag tagExisting = unitOfWork.TagRepository.Find(id);
			return View(tagExisting);
		}

		[HttpPost]
		[Authorize(Roles = "Admin")]
		public ActionResult Delete(int id, Tag tag)
		{
			Tag tagExisting = unitOfWork.TagRepository.Find(id);
			unitOfWork.TagRepository.DeleteTag(tagExisting);
			return RedirectToAction("Index");
		}
	}
}