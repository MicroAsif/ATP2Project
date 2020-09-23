namespace DoctorConsult.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class doctorandpatientprofilerequiredremoved : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DoctorProfileModels", "FullName", c => c.String());
            AlterColumn("dbo.DoctorProfileModels", "Password", c => c.String());
            AlterColumn("dbo.DoctorProfileModels", "Gender", c => c.String());
            AlterColumn("dbo.DoctorProfileModels", "Specialist", c => c.String());
            AlterColumn("dbo.DoctorProfileModels", "Location", c => c.String());
            AlterColumn("dbo.DoctorProfileModels", "Phone", c => c.String());
            AlterColumn("dbo.PatientProfileModels", "Password", c => c.String());
            AlterColumn("dbo.PatientProfileModels", "BloodGroup", c => c.String());
            AlterColumn("dbo.PatientProfileModels", "Gender", c => c.String());
            AlterColumn("dbo.PatientProfileModels", "District", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PatientProfileModels", "District", c => c.String(nullable: false));
            AlterColumn("dbo.PatientProfileModels", "Gender", c => c.String(nullable: false));
            AlterColumn("dbo.PatientProfileModels", "BloodGroup", c => c.String(nullable: false));
            AlterColumn("dbo.PatientProfileModels", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.DoctorProfileModels", "Phone", c => c.String(nullable: false));
            AlterColumn("dbo.DoctorProfileModels", "Location", c => c.String(nullable: false));
            AlterColumn("dbo.DoctorProfileModels", "Specialist", c => c.String(nullable: false));
            AlterColumn("dbo.DoctorProfileModels", "Gender", c => c.String(nullable: false));
            AlterColumn("dbo.DoctorProfileModels", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.DoctorProfileModels", "FullName", c => c.String(nullable: false));
        }
    }
}
