namespace FA.JustBlog.Core.Migrations
{
	using System.Data.Entity.Migrations;

	public partial class updatedatetime : DbMigration
	{
		public override void Up()
		{
			AlterColumn("dbo.Posts", "PostedOn", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
			AlterColumn("dbo.Posts", "Modified", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
		}

		public override void Down()
		{
			AlterColumn("dbo.Posts", "Modified", c => c.DateTime(nullable: false));
			AlterColumn("dbo.Posts", "PostedOn", c => c.DateTime(nullable: false));
		}
	}
}