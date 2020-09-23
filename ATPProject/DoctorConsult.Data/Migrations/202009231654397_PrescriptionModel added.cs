namespace DoctorConsult.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PrescriptionModeladded : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MedicineForPrescriptions", "MedicineId", "dbo.MedicineModels");
            DropForeignKey("dbo.MedicalTestModels", "PrescriptionModel_Id", "dbo.PrescriptionModels");
            DropForeignKey("dbo.MedicineForPrescriptions", "Id", "dbo.PrescriptionModels");
            DropIndex("dbo.MedicalTestModels", new[] { "PrescriptionModel_Id" });
            DropIndex("dbo.MedicineForPrescriptions", new[] { "Id" });
            DropIndex("dbo.MedicineForPrescriptions", new[] { "MedicineId" });
            DropColumn("dbo.MedicalTestModels", "PrescriptionId");
            RenameColumn(table: "dbo.MedicalTestModels", name: "PrescriptionModel_Id", newName: "PrescriptionId");
            DropPrimaryKey("dbo.MedicineForPrescriptions");
            AddColumn("dbo.MedicineForPrescriptions", "PrescriptionModel_Id1", c => c.Int());
            AddColumn("dbo.MedicineForPrescriptions", "PrescriptionModel_Id2", c => c.Int());
            AddColumn("dbo.PrescriptionModels", "Comment", c => c.String(nullable: false));
            AddColumn("dbo.PrescriptionModels", "ReferDoctor", c => c.String());
            AddColumn("dbo.PrescriptionModels", "ReferDiagonstics", c => c.String());
            AddColumn("dbo.PatientsProblemPageForDoctorModels", "Status", c => c.String());
            AddColumn("dbo.PatientsProblemPageForDoctorModels", "DoctorId", c => c.Int(nullable: false));
            AlterColumn("dbo.AdminProfileModels", "CreatedDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.AdminProfileModels", "UpdatedDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.CampaignModels", "CreatedDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.CampaignModels", "UpdatedDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.PatientsConsultModels", "CreatedDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.PatientsConsultModels", "UpdatedDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.DoctorProfileModels", "CreatedDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.DoctorProfileModels", "UpdatedDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.PatientProfileModels", "CreatedDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.PatientProfileModels", "UpdatedDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Location", "CreatedDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Location", "UpdatedDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.MedicalTestModels", "PrescriptionId", c => c.Int(nullable: false));
            AlterColumn("dbo.MedicalTestModels", "CreatedDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.MedicalTestModels", "UpdatedDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.MedicalTestModels", "PrescriptionId", c => c.Int(nullable: false));
            AlterColumn("dbo.MedicineForPrescriptions", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.MedicineForPrescriptions", "CreatedDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.MedicineForPrescriptions", "UpdatedDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.MedicineModels", "CreatedDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.MedicineModels", "UpdatedDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.PrescriptionModels", "Cause", c => c.String(nullable: false));
            AlterColumn("dbo.PrescriptionModels", "CreatedDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.PrescriptionModels", "UpdatedDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.PatientsProblemPageForDoctorModels", "CreatedDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.PatientsProblemPageForDoctorModels", "UpdatedDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Speciality", "CreatedDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Speciality", "UpdatedDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AddPrimaryKey("dbo.MedicineForPrescriptions", "Id");
            CreateIndex("dbo.MedicalTestModels", "PrescriptionId");
            CreateIndex("dbo.MedicineForPrescriptions", "PrescriptionModel_Id1");
            CreateIndex("dbo.MedicineForPrescriptions", "PrescriptionModel_Id2");
            CreateIndex("dbo.PatientsProblemPageForDoctorModels", "DoctorId");
            AddForeignKey("dbo.MedicineForPrescriptions", "PrescriptionModel_Id1", "dbo.PrescriptionModels", "Id");
            AddForeignKey("dbo.PatientsProblemPageForDoctorModels", "DoctorId", "dbo.DoctorProfileModels", "Id", cascadeDelete: true);
            AddForeignKey("dbo.MedicalTestModels", "PrescriptionId", "dbo.PrescriptionModels", "Id", cascadeDelete: true);
            AddForeignKey("dbo.MedicineForPrescriptions", "PrescriptionModel_Id2", "dbo.PrescriptionModels", "Id");
            DropColumn("dbo.MedicineForPrescriptions", "MedicineId");
            DropColumn("dbo.MedicineForPrescriptions", "PrescriptionId");
            DropColumn("dbo.PrescriptionModels", "Advice");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PrescriptionModels", "Advice", c => c.String());
            AddColumn("dbo.MedicineForPrescriptions", "PrescriptionId", c => c.Int());
            AddColumn("dbo.MedicineForPrescriptions", "MedicineId", c => c.Int());
            DropForeignKey("dbo.MedicineForPrescriptions", "PrescriptionModel_Id2", "dbo.PrescriptionModels");
            DropForeignKey("dbo.MedicalTestModels", "PrescriptionId", "dbo.PrescriptionModels");
            DropForeignKey("dbo.PatientsProblemPageForDoctorModels", "DoctorId", "dbo.DoctorProfileModels");
            DropForeignKey("dbo.MedicineForPrescriptions", "PrescriptionModel_Id1", "dbo.PrescriptionModels");
            DropIndex("dbo.PatientsProblemPageForDoctorModels", new[] { "DoctorId" });
            DropIndex("dbo.MedicineForPrescriptions", new[] { "PrescriptionModel_Id2" });
            DropIndex("dbo.MedicineForPrescriptions", new[] { "PrescriptionModel_Id1" });
            DropIndex("dbo.MedicalTestModels", new[] { "PrescriptionId" });
            DropPrimaryKey("dbo.MedicineForPrescriptions");
            AlterColumn("dbo.Speciality", "UpdatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Speciality", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.PatientsProblemPageForDoctorModels", "UpdatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.PatientsProblemPageForDoctorModels", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.PrescriptionModels", "UpdatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.PrescriptionModels", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.PrescriptionModels", "Cause", c => c.String());
            AlterColumn("dbo.MedicineModels", "UpdatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.MedicineModels", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.MedicineForPrescriptions", "UpdatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.MedicineForPrescriptions", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.MedicineForPrescriptions", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.MedicalTestModels", "PrescriptionId", c => c.Int());
            AlterColumn("dbo.MedicalTestModels", "UpdatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.MedicalTestModels", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.MedicalTestModels", "PrescriptionId", c => c.Int());
            AlterColumn("dbo.Location", "UpdatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Location", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.PatientProfileModels", "UpdatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.PatientProfileModels", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.DoctorProfileModels", "UpdatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.DoctorProfileModels", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.PatientsConsultModels", "UpdatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.PatientsConsultModels", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.CampaignModels", "UpdatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.CampaignModels", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.AdminProfileModels", "UpdatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.AdminProfileModels", "CreatedDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.PatientsProblemPageForDoctorModels", "DoctorId");
            DropColumn("dbo.PatientsProblemPageForDoctorModels", "Status");
            DropColumn("dbo.PrescriptionModels", "ReferDiagonstics");
            DropColumn("dbo.PrescriptionModels", "ReferDoctor");
            DropColumn("dbo.PrescriptionModels", "Comment");
            DropColumn("dbo.MedicineForPrescriptions", "PrescriptionModel_Id2");
            DropColumn("dbo.MedicineForPrescriptions", "PrescriptionModel_Id1");
            AddPrimaryKey("dbo.MedicineForPrescriptions", "Id");
            RenameColumn(table: "dbo.MedicalTestModels", name: "PrescriptionId", newName: "PrescriptionModel_Id");
            AddColumn("dbo.MedicalTestModels", "PrescriptionId", c => c.Int());
            CreateIndex("dbo.MedicineForPrescriptions", "MedicineId");
            CreateIndex("dbo.MedicineForPrescriptions", "Id");
            CreateIndex("dbo.MedicalTestModels", "PrescriptionModel_Id");
            AddForeignKey("dbo.MedicineForPrescriptions", "Id", "dbo.PrescriptionModels", "Id");
            AddForeignKey("dbo.MedicalTestModels", "PrescriptionModel_Id", "dbo.PrescriptionModels", "Id");
            AddForeignKey("dbo.MedicineForPrescriptions", "MedicineId", "dbo.MedicineModels", "Id");
        }
    }
}
