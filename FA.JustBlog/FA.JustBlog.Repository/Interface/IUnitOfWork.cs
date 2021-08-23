using System;

namespace FA.JustBlog.Repository.Interface
{
	public interface IUnitOfWork : IDisposable
	{
		int Commit();
	}
}