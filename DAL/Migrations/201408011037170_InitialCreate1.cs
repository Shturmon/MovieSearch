namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Genres", new[] { "Title" });
            AlterColumn("dbo.Genres", "Title", c => c.String(maxLength: 100));
            CreateIndex("dbo.Genres", "Title", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Genres", new[] { "Title" });
            AlterColumn("dbo.Genres", "Title", c => c.String(maxLength: 50));
            CreateIndex("dbo.Genres", "Title", unique: true);
        }
    }
}
