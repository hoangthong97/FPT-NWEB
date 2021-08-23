using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FA.JustBlog.Core.Model
{
	public class Category
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int CategoryId { get; set; }

		public string Name { get; set; }

		public string UrlSlug { get; set; }

		public string Description { get; set; }

		public virtual ICollection<Post> Posts { get; set; }
	}
}