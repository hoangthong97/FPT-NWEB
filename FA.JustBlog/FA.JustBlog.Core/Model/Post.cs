using FA.JustBlog.Core.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FA.JustBlog.Core
{
	public class Post
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int PostId { get; set; }

		public string Title { get; set; }
		public string ShortDescription { get; set; }
		public string Description { get; set; }
		public string Meta { get; set; }
		public string UrlSlug { get; set; }
		public bool Published { get; set; }
		public DateTime PostedOn { get; set; }
		public DateTime Modified { get; set; }
		public int ViewCount { get; set; }
		public int CategoryId { get; set; }

		[ForeignKey("CategoryId")]
		public virtual Category Category { get; set; }

		public virtual ICollection<PostTag> PostTags { get; set; }
	}
}