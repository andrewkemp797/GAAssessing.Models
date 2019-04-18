namespace GAAssessing.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VehicleConditionModelChange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.VehicleCondition", "AirConditioner", c => c.String());
            AlterColumn("dbo.VehicleCondition", "MagWheels", c => c.String());
            AlterColumn("dbo.VehicleCondition", "Sunroof", c => c.String());
            AlterColumn("dbo.VehicleCondition", "Spotlights", c => c.String());
            AlterColumn("dbo.VehicleCondition", "Towbar", c => c.String());
            AlterColumn("dbo.VehicleCondition", "RunningBoards", c => c.String());
            AlterColumn("dbo.VehicleCondition", "Radio", c => c.String());
            AlterColumn("dbo.VehicleCondition", "Speakers", c => c.String());
            AlterColumn("dbo.VehicleCondition", "CentralLocking", c => c.String());
            AlterColumn("dbo.VehicleCondition", "Immobiliser", c => c.String());
            AlterColumn("dbo.VehicleCondition", "BullBar", c => c.String());
            AlterColumn("dbo.VehicleCondition", "BootSpoiler", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.VehicleCondition", "BootSpoiler", c => c.Boolean(nullable: false));
            AlterColumn("dbo.VehicleCondition", "BullBar", c => c.Boolean(nullable: false));
            AlterColumn("dbo.VehicleCondition", "Immobiliser", c => c.Boolean(nullable: false));
            AlterColumn("dbo.VehicleCondition", "CentralLocking", c => c.Boolean(nullable: false));
            AlterColumn("dbo.VehicleCondition", "Speakers", c => c.Boolean(nullable: false));
            AlterColumn("dbo.VehicleCondition", "Radio", c => c.Boolean(nullable: false));
            AlterColumn("dbo.VehicleCondition", "RunningBoards", c => c.Boolean(nullable: false));
            AlterColumn("dbo.VehicleCondition", "Towbar", c => c.Boolean(nullable: false));
            AlterColumn("dbo.VehicleCondition", "Spotlights", c => c.Boolean(nullable: false));
            AlterColumn("dbo.VehicleCondition", "Sunroof", c => c.Boolean(nullable: false));
            AlterColumn("dbo.VehicleCondition", "MagWheels", c => c.Boolean(nullable: false));
            AlterColumn("dbo.VehicleCondition", "AirConditioner", c => c.Boolean(nullable: false));
        }
    }
}
