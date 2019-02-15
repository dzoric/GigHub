namespace GigHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSomeGigDetailsViewProperties : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "IsFollowed", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "IsFollowed");
        }
    }
}
