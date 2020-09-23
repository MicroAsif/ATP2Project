namespace DoctorConsult.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsActivehasbeensettonullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "IsActive", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "IsActive", c => c.Boolean(nullable: false));
        }
    }
}
