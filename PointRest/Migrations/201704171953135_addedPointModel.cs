namespace PointRest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedPointModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Points",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApplicationUserId = c.String(maxLength: 128),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .Index(t => t.ApplicationUserId);
            
            AddColumn("dbo.AspNetUsers", "PointsQuantity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Points", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Points", new[] { "ApplicationUserId" });
            DropColumn("dbo.AspNetUsers", "PointsQuantity");
            DropTable("dbo.Points");
        }
    }
}
