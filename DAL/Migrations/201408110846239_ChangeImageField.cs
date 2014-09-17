namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeImageField : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Movies", "ImagePath");
            AddColumn("dbo.Movies", "ImageId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "ImageId");
        }
    }
}
