using FA.JustBlog.Core;
using FA.JustBlog.Core.Model;
using FA.JustBlog.Repository.Interface;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace FA.JustBlog.Repository.Implement
{
	public class TagRepository:ITagRepository
	{
		private readonly JustBlogContext db;
		public TagRepository()
		{
			db = new JustBlogContext();
		}

        public void AddTag(Tag tag)
        {
            this.db.Tags.Add(tag);
            this.db.SaveChanges();
        }

        /// <summary>
        /// Delete tag by tag.
        /// </summary>
        /// <param name="tag">Tag.</param>
        public void DeleteTag(Tag tag)
        {
            var item = db.Tags.Find(tag.TagId);
            this.db.Tags.Remove(item);
            this.db.SaveChanges();

        }

        /// <summary>
        /// Find tag by id.
        /// </summary>
        /// <param name="tagID">Tag id.</param>
        /// <returns>Single tag or null if not found.</returns>
        public Tag Find(int tagId)
        {
            return this.db.Tags.Find(tagId);
        }

        /// <summary>
        /// Get All tags.
        /// </summary>
        /// <returns>List of tags in DBContext.</returns>
        public List<Tag> GetAllTags()
        {
            return this.db.Tags.ToList();
        }

		public List<Tag> PopularTags()
		{
            return this.db.Tags.Take(10).ToList();
        }

		/// <summary>
		/// Update tag.
		/// </summary>
		/// <param name="tag">Tag.</param>
		public void UpdateTag(Tag tag)
        {
            db.Entry(tag).State = EntityState.Modified;
            db.SaveChanges();
        }

    
    }
}
