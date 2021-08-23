using FA.JustBlog.Core;
using FA.JustBlog.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace FA.JustBlog.Repository.Implement
{
	public class PostRepository : IPostRepository
	{
		private readonly JustBlogContext db;
		public PostRepository()
		{
			db = new JustBlogContext();
		}
		public void AddPost(Post post)
		{
			post.PostedOn = DateTime.Now;
			db.Posts.Add(post);
			db.SaveChanges();
		}

		public void DeletePost(Post post)
		{
			var item = db.Posts.Find(post.PostId);
			db.Posts.Remove(item);
			db.SaveChanges();
		}

		public Post Find(int postId)
		{
			return db.Posts.Find(postId);
		}

		public Post FindPost(int year, int month, string title)
		{
			var posts = db.Posts.Where(m => m.PostedOn.Year == year && m.PostedOn.Month == month && m.UrlSlug == title).FirstOrDefault();
			return posts;
		}

		public List<Post> GetAllPosts()
		{
			return db.Posts.OrderByDescending(m => m.PostedOn).ToList();
		}

		public List<Post> GetLatestPost()
		{
			return db.Posts.OrderByDescending(o => o.PostedOn).Take(5).ToList();
		}

		public List<Post> GetMostViewedPost()
		{
			return db.Posts.OrderByDescending(o => o.ViewCount).Take(5).ToList();
		}

		public List<Post> GetPostByCategory(int categoryId)
		{
			return db.Posts.Where(m => m.CategoryId.Equals(categoryId)).ToList();
		}

		public List<Post> GetPostByTag(int tagId)
		{
			return db.Posts.Where(m => m.PostTags.Any(pt => pt.TagId == tagId)).ToList();
		}

		public List<Post> GetPublished()
		{
			return db.Posts.Where(m => m.Published == true).ToList();
		}

		public string GetRelativeDateTime(DateTime date)
		{
			TimeSpan ts = DateTime.Now - date;
			if (ts.TotalMinutes < 1)//seconds ago
				return "just now";
			if (ts.TotalHours < 1)//min ago
				return (int)ts.TotalMinutes == 1 ? "1 Minute ago" : (int)ts.TotalMinutes + " Minutes ago";
			if (ts.TotalDays < 1)//hours ago
				return (int)ts.TotalHours == 1 ? "1 Hour ago" : (int)ts.TotalHours + " Hours ago";
			if (ts.TotalDays < 7)//days ago
				return (int)ts.TotalDays == 1 ? "1 Day ago" : (int)ts.TotalDays + " Days ago";
			if (ts.TotalDays < 30.4368)//weeks ago
				return (int)(ts.TotalDays / 7) == 1 ? "1 Week ago" : (int)(ts.TotalDays / 7) + " Weeks ago";
			if (ts.TotalDays < 365.242)//months ago
				return (int)(ts.TotalDays / 30.4368) == 1 ? "1 Month ago" : (int)(ts.TotalDays / 30.4368) + " Months ago";
			//years ago
			return (int)(ts.TotalDays / 365.242) == 1 ? "1 Year ago" : (int)(ts.TotalDays / 365.242) + " Years ago";
		}

		public List<Post> GetUnPublished()
		{
			return db.Posts.Where(m => m.Published == false).ToList();
		}

		public List<Post> PagingPost()
		{
			return db.Posts.ToList();
		}

		public void UpdatePost(Post post)
		{
			post.Modified = DateTime.Now;
			db.Entry(post).State = EntityState.Modified;
			db.SaveChanges();
		}
	}
}
