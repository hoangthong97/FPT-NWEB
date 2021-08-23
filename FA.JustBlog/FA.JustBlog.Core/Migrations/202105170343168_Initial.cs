namespace FA.JustBlog.Core.Migrations
{
	using System.Data.Entity.Migrations;

	public partial class Initial : DbMigration
	{
		public override void Up()
		{
			CreateTable(
				"dbo.Categories",
				c => new
				{
					CategoryId = c.Int(nullable: false, identity: true),
					Name = c.String(),
					UrlSlug = c.String(),
					Description = c.String(),
				})
				.PrimaryKey(t => t.CategoryId);

			CreateTable(
				"dbo.Posts",
				c => new
				{
					PostId = c.Int(nullable: false, identity: true),
					Title = c.String(),
					ShortDescription = c.String(),
					Description = c.String(),
					Meta = c.String(),
					UrlSlug = c.String(),
					Published = c.Boolean(nullable: false),
					PostedOn = c.DateTime(nullable: false),
					Modified = c.DateTime(nullable: false),
					ViewCount = c.Int(nullable: false),
					CategoryId = c.Int(nullable: false),
				})
				.PrimaryKey(t => t.PostId)
				.ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
				.Index(t => t.CategoryId);

			CreateTable(
				"dbo.Tags",
				c => new
				{
					TagId = c.Int(nullable: false, identity: true),
					Name = c.String(),
					UrlSlug = c.String(),
					Description = c.String(),
				})
				.PrimaryKey(t => t.TagId);

			CreateTable(
				"dbo.TagPosts",
				c => new
				{
					Tag_TagId = c.Int(nullable: false),
					Post_PostId = c.Int(nullable: false),
				})
				.PrimaryKey(t => new { t.Tag_TagId, t.Post_PostId })
				.ForeignKey("dbo.Tags", t => t.Tag_TagId, cascadeDelete: true)
				.ForeignKey("dbo.Posts", t => t.Post_PostId, cascadeDelete: true)
				.Index(t => t.Tag_TagId)
				.Index(t => t.Post_PostId);
		}

		public override void Down()
		{
			DropForeignKey("dbo.TagPosts", "Post_PostId", "dbo.Posts");
			DropForeignKey("dbo.TagPosts", "Tag_TagId", "dbo.Tags");
			DropForeignKey("dbo.Posts", "CategoryId", "dbo.Categories");
			DropIndex("dbo.TagPosts", new[] { "Post_PostId" });
			DropIndex("dbo.TagPosts", new[] { "Tag_TagId" });
			DropIndex("dbo.Posts", new[] { "CategoryId" });
			DropTable("dbo.TagPosts");
			DropTable("dbo.Tags");
			DropTable("dbo.Posts");
			DropTable("dbo.Categories");
		}
	}
}