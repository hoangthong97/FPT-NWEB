namespace FA.JustBlog.Core.Migrations
{
	using System.Data.Entity.Migrations;

	public partial class updatemodel : DbMigration
	{
		public override void Up()
		{
			DropForeignKey("dbo.TagPosts", "Tag_TagId", "dbo.Tags");
			DropForeignKey("dbo.TagPosts", "Post_PostId", "dbo.Posts");
			DropIndex("dbo.TagPosts", new[] { "Tag_TagId" });
			DropIndex("dbo.TagPosts", new[] { "Post_PostId" });
			CreateTable(
				"dbo.PostTags",
				c => new
				{
					PostId = c.Int(nullable: false),
					TagId = c.Int(nullable: false),
				})
				.PrimaryKey(t => new { t.PostId, t.TagId })
				.ForeignKey("dbo.Posts", t => t.PostId, cascadeDelete: true)
				.ForeignKey("dbo.Tags", t => t.TagId, cascadeDelete: true)
				.Index(t => t.PostId)
				.Index(t => t.TagId);

			DropTable("dbo.TagPosts");
		}

		public override void Down()
		{
			CreateTable(
				"dbo.TagPosts",
				c => new
				{
					Tag_TagId = c.Int(nullable: false),
					Post_PostId = c.Int(nullable: false),
				})
				.PrimaryKey(t => new { t.Tag_TagId, t.Post_PostId });

			DropForeignKey("dbo.PostTags", "TagId", "dbo.Tags");
			DropForeignKey("dbo.PostTags", "PostId", "dbo.Posts");
			DropIndex("dbo.PostTags", new[] { "TagId" });
			DropIndex("dbo.PostTags", new[] { "PostId" });
			DropTable("dbo.PostTags");
			CreateIndex("dbo.TagPosts", "Post_PostId");
			CreateIndex("dbo.TagPosts", "Tag_TagId");
			AddForeignKey("dbo.TagPosts", "Post_PostId", "dbo.Posts", "PostId", cascadeDelete: true);
			AddForeignKey("dbo.TagPosts", "Tag_TagId", "dbo.Tags", "TagId", cascadeDelete: true);
		}
	}
}