using FA.JustBlog.Core;
using FA.JustBlog.Repository.Implement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FA.JustBlog.Controllers
{
    public class TagController : Controller
    {
        private readonly UnitOfWork unitOfWork = new UnitOfWork(new JustBlogContext());

        // GET: Tag
        public ActionResult Index()
        {
            var a = 1;
            return View();
        }

        
        public ActionResult PopularTags()
        {
            var popularTag = unitOfWork.TagRepository.PopularTags();
            return PartialView("_PopularTags",popularTag);
        }
        public ActionResult Details(int id)
		{
            var tag = unitOfWork.TagRepository.Find(id);
            return View(tag);
		}
    }
}