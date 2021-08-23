using FA.JustBlog.Core;
using FA.JustBlog.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace FA.JustBlog.Extensions
{
	public static class ActionLinkExtensions
	{
		public static MvcHtmlString PostLink(this HtmlHelper helper, Post post)
		{
			return helper.ActionLink(post.Title, "Details", "Post", new { year = post.PostedOn.Year, month = post.PostedOn.Month, title = post.UrlSlug }, new { @class = "h4 text-danger" });
		}
		public static MvcHtmlString CategoryLink(this HtmlHelper helper, Category category)
		{
			return helper.ActionLink(category.Name, "Details", "Category", new { category = category.UrlSlug }, new { title = String.Format("See all posts in {0}", category.Name) });
		}
		public static MvcHtmlString TagLink(this HtmlHelper helper, Tag tag)
		{
			return helper.ActionLink(tag.Name, "Details", "Tag", new { id = tag.TagId}, new { title = String.Format("See all posts in {0}", tag.Name) });
		}

        public static MvcHtmlString PostedOn(this HtmlHelper helper, DateTime createdDate)
        {
            TagBuilder tag = new TagBuilder("span");
            double postedOn = DateTime.Now.Subtract(createdDate).TotalHours;
            if (postedOn < 1)
                tag.InnerHtml = Math.Round((DateTime.Now - createdDate).TotalMinutes, 0).ToString() + " minutes";
            else if (postedOn > 1 && postedOn < 24)
                tag.InnerHtml = Math.Round((DateTime.Now - createdDate).TotalHours, 0).ToString() + " hours";
            else if (postedOn < 8760)
            {
                string day;
                if (postedOn <= 1)
                    day = "Yesterday" + " at " + createdDate.Hour + " " + createdDate.Minute;
                else
                    day = Math.Round((DateTime.Now - createdDate).TotalDays, 0).ToString() + " days at " + createdDate.Hour.ToString("00") + ":" + createdDate.Minute.ToString("00");
                tag.InnerHtml = day;
            }
            else
                tag.InnerHtml = (DateTime.Now.Year - createdDate.Year).ToString() + " years";
            string html = tag.ToString(TagRenderMode.Normal);

            return MvcHtmlString.Create(html);
        }
    }
}