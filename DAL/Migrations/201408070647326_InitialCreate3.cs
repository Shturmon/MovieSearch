namespace DAL
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate3 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Careers", new[] { "Title" });
            DropIndex("dbo.Countries", new[] { "Title" });
            DropIndex("dbo.Genres", new[] { "Title" });
            AlterColumn("dbo.Careers", "Title", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Movies", "Title", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Countries", "Title", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Genres", "Title", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.UserComments", "Comment", c => c.String(nullable: false));
            AlterColumn("dbo.People", "FirstName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.People", "LastName", c => c.String(nullable: false, maxLength: 100));
            CreateIndex("dbo.Careers", "Title", unique: true);
            CreateIndex("dbo.Countries", "Title", unique: true);
            CreateIndex("dbo.Genres", "Title", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Genres", new[] { "Title" });
            DropIndex("dbo.Countries", new[] { "Title" });
            DropIndex("dbo.Careers", new[] { "Title" });
            AlterColumn("dbo.People", "LastName", c => c.String(maxLength: 100));
            AlterColumn("dbo.People", "FirstName", c => c.String(maxLength: 100));
            AlterColumn("dbo.UserComments", "Comment", c => c.String());
            AlterColumn("dbo.Genres", "Title", c => c.String(maxLength: 100));
            AlterColumn("dbo.Countries", "Title", c => c.String(maxLength: 100));
            AlterColumn("dbo.Movies", "Title", c => c.String(maxLength: 100));
            AlterColumn("dbo.Careers", "Title", c => c.String(maxLength: 100));
            CreateIndex("dbo.Genres", "Title", unique: true);
            CreateIndex("dbo.Countries", "Title", unique: true);
            CreateIndex("dbo.Careers", "Title", unique: true);
        }
    }
}
