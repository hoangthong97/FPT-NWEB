//using FA.JustBlog.Core.Model;
//using System;
//using System.Collections.Generic;
//using System.Data.Entity;
//using System.Globalization;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace FA.JustBlog.Core
//{
//	public class JustBlogInitializer : CreateDatabaseIfNotExists<JustBlogContext>
//	{
//		protected override void Seed(JustBlogContext context)
//		{
//			List<Category> categories = new List<Category>()
//			{
//				new Category{ CategoryId=1, Name="Khoa Học", Description="Description 1", UrlSlug ="UrlSlug 1"},
//				new Category{ CategoryId=2, Name="Công Nghệ", Description="Description 1", UrlSlug ="UrlSlug 1"},
//				new Category{ CategoryId=3, Name="Xã Hội", Description="Description 1", UrlSlug ="UrlSlug 1"},
//				new Category{ CategoryId=4, Name="Pháp Luật", Description="Description 1", UrlSlug ="UrlSlug 1"},
//			};
//			context.Categories.AddRange(categories);
//			context.SaveChanges();

//			List<Tag> tags = new List<Tag>()
//			{
//				new Tag{ TagId=1, Name="TagName 1", UrlSlug="UrlSlug 1", Description="Description 1"},
//				new Tag{ TagId=2, Name="TagName 2", UrlSlug="UrlSlug 2", Description="Description 2"},
//				new Tag{ TagId=3, Name="TagName 3", UrlSlug="UrlSlug 3", Description="Description 3"},
//				new Tag{ TagId=4, Name="TagName 4", UrlSlug="UrlSlug 4", Description="Description 4"},
//			};
//			context.Tags.AddRange(tags);
//			context.SaveChanges();

//			List<Post> posts = new List<Post>()
//			{
//				new Post{
//					PostId=1,
//					CategoryId=2,
//					Title="Title 1",
//					ShortDescription="ShortDescription 1",
//					Description="Description 1",
//					Meta="Meta 1",
//					UrlSlug="UrlSlug 1",
//					Published=true,
//					PostedOn=DateTime.Now,
//					Modified=DateTime.ParseExact("11/06/2021", "MM/dd/yyyy", CultureInfo.InvariantCulture)
//				},
//				new Post{
//					PostId=2,
//					CategoryId=1,
//					Title="Title 2",
//					ShortDescription="ShortDescription 2",
//					Description="Description 2",
//					Meta="Meta 2",
//					UrlSlug="UrlSlug 2",
//					Published=true,
//					PostedOn=DateTime.Now,
//					Modified=DateTime.ParseExact("11/06/2021", "MM/dd/yyyy", CultureInfo.InvariantCulture)
//				},
//				new Post{
//					PostId=3,
//					CategoryId=4,
//					Title="Title 3",
//					ShortDescription="ShortDescription 3",
//					Description="Description 3",
//					Meta="Meta 3",
//					UrlSlug="UrlSlug 3",
//					Published=true,
//					PostedOn=DateTime.Now,
//					Modified=DateTime.ParseExact("11/06/2021", "MM/dd/yyyy", CultureInfo.InvariantCulture)
//				},
//				new Post{
//					PostId=4,
//					CategoryId=3,
//					Title="Title 4",
//					ShortDescription="ShortDescription 4",
//					Description="Description 4",
//					Meta="Meta 4",
//					UrlSlug="UrlSlug 4",
//					Published=true,
//					PostedOn=DateTime.Now,
//					Modified=DateTime.ParseExact("11/06/2021", "MM/dd/yyyy", CultureInfo.InvariantCulture)
//				},
//			};
//			context.Posts.AddRange(posts);
//			context.SaveChanges();
//		}
//	}
//}