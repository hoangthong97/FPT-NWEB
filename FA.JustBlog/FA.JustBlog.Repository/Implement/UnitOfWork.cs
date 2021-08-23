using FA.JustBlog.Core;
using FA.JustBlog.Repository.Interface;
using System;

namespace FA.JustBlog.Repository.Implement
{
	public class UnitOfWork : IUnitOfWork
	{
		private JustBlogContext Context;
		public IPostRepository PostRepository { get; set; }
		public ICategoryRepository CategoryRepository { get; set; }
		public ITagRepository TagRepository { get; set; }
		public UnitOfWork(JustBlogContext context)
		{
			this.Context = context;
			PostRepository = new PostRepository();
			CategoryRepository = new CategoryRepository();
			TagRepository = new TagRepository();
		}

		public int Commit()
		{
			return Context.SaveChanges();
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
		private void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (Context != null)
				{
					Context.Dispose();
					Context = null;
				}
			}
		}
	}
}
