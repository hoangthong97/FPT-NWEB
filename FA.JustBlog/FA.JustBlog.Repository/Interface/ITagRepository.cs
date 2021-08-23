using FA.JustBlog.Core.Model;
using System.Collections.Generic;

namespace FA.JustBlog.Repository.Interface
{
	public interface ITagRepository
	{
		Tag Find(int tagID);

		void AddTag(Tag tag);

		void UpdateTag(Tag tag);

		void DeleteTag(Tag tag);

		List<Tag> GetAllTags();

		List<Tag> PopularTags();
	}
}