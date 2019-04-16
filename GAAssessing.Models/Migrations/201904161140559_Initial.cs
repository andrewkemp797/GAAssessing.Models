namespace GAAssessing.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MotorAssessorReport",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Insurance = c.String(),
                        Client = c.String(),
                        ClaimNo = c.String(),
                        Vehicle = c.String(),
                        DateInspected = c.DateTimeOffset(nullable: false, precision: 7),
                        EngineNo = c.String(),
                        ChassisNo = c.String(),
                        RegistrationNo = c.String(),
                        IsRetired = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VehicleCondition",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Odometer = c.Int(nullable: false),
                        Steering = c.String(),
                        Footbrake = c.String(),
                        Handbrake = c.String(),
                        Bodywork = c.String(),
                        Windscreen = c.String(),
                        Chassis = c.String(),
                        Interior = c.String(),
                        PaintCondition = c.String(),
                        PaintColour = c.String(),
                        AirConditioner = c.Boolean(nullable: false),
                        MagWheels = c.Boolean(nullable: false),
                        Sunroof = c.Boolean(nullable: false),
                        Spotlights = c.Boolean(nullable: false),
                        Towbar = c.Boolean(nullable: false),
                        RunningBoards = c.Boolean(nullable: false),
                        Radio = c.Boolean(nullable: false),
                        Speakers = c.Boolean(nullable: false),
                        CentralLocking = c.Boolean(nullable: false),
                        Immobiliser = c.Boolean(nullable: false),
                        BullBar = c.Boolean(nullable: false),
                        BootSpoiler = c.Boolean(nullable: false),
                        GeneralCondition = c.String(),
                        MissingItems = c.String(),
                        OldDamage = c.String(),
                        TyreMake = c.String(),
                        TyreThreadLF = c.Int(nullable: false),
                        TyreThreadRF = c.Int(nullable: false),
                        TyreThreadLR = c.Int(nullable: false),
                        TyreThreadRR = c.Int(nullable: false),
                        TyreThreadSpare = c.Int(nullable: false),
                        VehicleInspectedAt = c.String(),
                        QuotesObtainedFrom = c.String(),
                        Remarks = c.String(),
                        IsRetired = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MotorAssessorReport", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VehicleCondition", "Id", "dbo.MotorAssessorReport");
            DropIndex("dbo.VehicleCondition", new[] { "Id" });
            DropTable("dbo.VehicleCondition");
            DropTable("dbo.MotorAssessorReport");
        }
    }
}
