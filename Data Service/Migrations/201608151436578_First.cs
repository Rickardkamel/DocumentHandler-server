namespace Data_Service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WasteId = c.Int(nullable: false),
                        VesselId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Exchange = c.Int(nullable: false),
                        Info = c.String(),
                        Report_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Reports", t => t.Report_Id)
                .ForeignKey("dbo.Vessels", t => t.VesselId, cascadeDelete: false)
                .Index(t => t.VesselId)
                .Index(t => t.Report_Id);
            
            CreateTable(
                "dbo.Reports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedById = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        RegionId = c.Int(nullable: false),
                        TransporterId = c.Int(nullable: false),
                        RecieverId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        RemovedDate = c.DateTime(),
                        EditedDate = c.DateTime(nullable: false),
                        Approved = c.Boolean(nullable: false),
                        LastEditBy = c.Int(nullable: false),
                        Info = c.String(),
                        OrderedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreatedById, cascadeDelete: false)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: false)
                .ForeignKey("dbo.Recievers", t => t.RecieverId, cascadeDelete: false)
                .ForeignKey("dbo.Regions", t => t.RegionId, cascadeDelete: false)
                .ForeignKey("dbo.Transporters", t => t.TransporterId, cascadeDelete: false)
                .Index(t => t.CreatedById)
                .Index(t => t.CustomerId)
                .Index(t => t.RegionId)
                .Index(t => t.TransporterId)
                .Index(t => t.RecieverId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 50),
                        Salt = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Permission = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Adress = c.String(),
                        City = c.String(),
                        CorporateIdentity = c.String(),
                        CustNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Recievers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Adress = c.String(),
                        City = c.String(),
                        CorporateIdentity = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Regions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Transporters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Adress = c.String(),
                        City = c.String(),
                        CorporateIdentity = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Vessels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(nullable: false, maxLength: 150),
                        PalletSpace = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Articles", "VesselId", "dbo.Vessels");
            DropForeignKey("dbo.Reports", "TransporterId", "dbo.Transporters");
            DropForeignKey("dbo.Reports", "RegionId", "dbo.Regions");
            DropForeignKey("dbo.Reports", "RecieverId", "dbo.Recievers");
            DropForeignKey("dbo.Reports", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Reports", "CreatedById", "dbo.Users");
            DropForeignKey("dbo.Articles", "Report_Id", "dbo.Reports");
            DropIndex("dbo.Reports", new[] { "RecieverId" });
            DropIndex("dbo.Reports", new[] { "TransporterId" });
            DropIndex("dbo.Reports", new[] { "RegionId" });
            DropIndex("dbo.Reports", new[] { "CustomerId" });
            DropIndex("dbo.Reports", new[] { "CreatedById" });
            DropIndex("dbo.Articles", new[] { "Report_Id" });
            DropIndex("dbo.Articles", new[] { "VesselId" });
            DropTable("dbo.Vessels");
            DropTable("dbo.Transporters");
            DropTable("dbo.Regions");
            DropTable("dbo.Recievers");
            DropTable("dbo.Customers");
            DropTable("dbo.Users");
            DropTable("dbo.Reports");
            DropTable("dbo.Articles");
        }
    }
}
