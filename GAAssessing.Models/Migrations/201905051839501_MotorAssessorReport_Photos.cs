namespace GAAssessing.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MotorAssessorReport_Photos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Photo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PhotoBase64 = c.String(),
                        MotorAssessorReportId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MotorAssessorReport", t => t.MotorAssessorReportId, cascadeDelete: true)
                .Index(t => t.MotorAssessorReportId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Photo", "MotorAssessorReportId", "dbo.MotorAssessorReport");
            DropIndex("dbo.Photo", new[] { "MotorAssessorReportId" });
            DropTable("dbo.Photo");
        }
    }
}
