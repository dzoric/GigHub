namespace GigHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedSomeGigDetailsViewProperties : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "IsFollowed");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "IsFollowed", c => c.Boolean(nullable: false));
        }
    }
}
