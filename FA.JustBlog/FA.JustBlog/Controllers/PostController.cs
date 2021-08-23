using FA.JustBlog.Core;
using FA.JustBlog.Repository.Implement;
using PagedList;
using System.Web.Mvc;

namespace FA.JustBlog.Controllers
{
	public class PostController : Controller
	{
		private readonly UnitOfWork unitOfWork = new UnitOfWork(new JustBlogContext());
		// GET: Post

		public ActionResult Index(int? page)
		{
			if (page == null) page = 1;
			int pageSize = 3;
			int pageNumber = (page ?? 1);
			return View(unitOfWork.PostRepository.GetAllPosts().ToPagedList(pageNumber, pageSize));
		}

		public ActionResult GetAll()
		{
			return View(unitOfWork.PostRepository.GetAllPosts());
		}

		public ActionResult Details(int year, int month, string title)
		{
			var post = unitOfWork.PostRepository.FindPost(year, month, title);
			if (post == null)
				return HttpNotFound();
			return View(post);
		}

		[ChildActionOnly]
		public ActionResult MostViewedPosts()
		{
			var mostView = unitOfWork.PostRepository.GetMostViewedPost();

			return PartialView("_ListPosts", mostView);
		}

		[ChildActionOnly]
		public ActionResult LatestPosts()
		{
			var lastPost = unitOfWork.PostRepository.GetLatestPost();
			return PartialView("_ListPosts", lastPost);
		}

		public ActionResult GetAllByCategory(int id)
		{
			var listposts = unitOfWork.PostRepository.GetPostByCategory(id);
			return View(listposts);
		}

		public ActionResult GetAllByTag(int tagId)
		{
			var listposts = unitOfWork.PostRepository.GetPostByTag(tagId);
			return View(listposts);
		}
	}
}