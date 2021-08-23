using System.Collections.Generic;

namespace FA.JustBlog.Core.Model
{
	public class Tag
	{
		public int TagId { get; set; }

		public string Name { get; set; }

		public string UrlSlug { get; set; }

		public string Description { get; set; }

		public virtual ICollection<PostTag> PostTags { get; set; }
	}
}