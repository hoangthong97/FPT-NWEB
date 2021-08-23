using FA.JustBlog.Core;
using System;
using System.Collections.Generic;

namespace FA.JustBlog.Repository.Interface
{
	public interface IPostRepository
	{
		void AddPost(Post post);

		void DeletePost(Post post);

		void UpdatePost(Post post);

		Post Find(int postId);

		Post FindPost(int year, int month, string title);

		List<Post> GetAllPosts();

		string GetRelativeDateTime(DateTime date);

		List<Post> GetLatestPost();

		List<Post> PagingPost();

		List<Post> GetMostViewedPost();

		List<Post> GetPublished();

		List<Post> GetUnPublished();

		List<Post> GetPostByCategory(int categoryId);

		List<Post> GetPostByTag(int tagId);
	}
}