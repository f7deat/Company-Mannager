namespace CompanyManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BrandProduct",
                c => new
                    {
                        BrandProductID = c.Int(nullable: false, identity: true),
                        BrandID = c.Int(nullable: false),
                        BrandName = c.String(),
                        ProductID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BrandProductID)
                .ForeignKey("dbo.Brand", t => t.BrandID, cascadeDelete: true)
                .ForeignKey("dbo.Product", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.BrandID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.Brand",
                c => new
                    {
                        BrandID = c.Int(nullable: false, identity: true),
                        BrandName = c.String(),
                        Product_ProductID = c.Int(),
                    })
                .PrimaryKey(t => t.BrandID)
                .ForeignKey("dbo.Product", t => t.Product_ProductID)
                .Index(t => t.Product_ProductID);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        ProductContent = c.String(),
                        UnitStock = c.Int(nullable: false),
                        Image = c.String(),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.ProductID);
            
            CreateTable(
                "dbo.Modem",
                c => new
                    {
                        ModemID = c.String(nullable: false, maxLength: 128),
                        ProductID = c.Int(nullable: false),
                        UnitPrice = c.String(),
                    })
                .PrimaryKey(t => t.ModemID)
                .ForeignKey("dbo.Product", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        CustomerID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        ShipperID = c.Int(),
                        ProductID = c.Int(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                        ShippedDate = c.Int(),
                        ShipCod = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                        Discount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderID)
                .ForeignKey("dbo.Customer", t => t.CustomerID, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserID, cascadeDelete: true)
                .ForeignKey("dbo.Product", t => t.ProductID, cascadeDelete: true)
                .ForeignKey("dbo.Shipper", t => t.ShipperID)
                .Index(t => t.CustomerID)
                .Index(t => t.UserID)
                .Index(t => t.ShipperID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(),
                        ContactName = c.String(),
                        Address = c.String(),
                        Phone = c.String(),
                        Fax = c.String(),
                    })
                .PrimaryKey(t => t.CustomerID);
            
            CreateTable(
                "dbo.Volume",
                c => new
                    {
                        VolumeID = c.Int(nullable: false, identity: true),
                        VolumeName = c.String(),
                        DateCreate = c.DateTime(nullable: false),
                        ShipAddress = c.String(),
                        UserID = c.Int(nullable: false),
                        CustomerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VolumeID)
                .ForeignKey("dbo.Customer", t => t.CustomerID, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.CustomerID);
            
            CreateTable(
                "dbo.Sale",
                c => new
                    {
                        SaleID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        VolumeID = c.Int(nullable: false),
                        ModemID = c.String(maxLength: 128),
                        BrandName = c.String(),
                        Quantity = c.Int(nullable: false),
                        Unit = c.String(),
                        Note = c.String(),
                    })
                .PrimaryKey(t => t.SaleID)
                .ForeignKey("dbo.Modem", t => t.ModemID)
                .ForeignKey("dbo.Product", t => t.ProductID, cascadeDelete: true)
                .ForeignKey("dbo.Volume", t => t.VolumeID, cascadeDelete: true)
                .Index(t => t.ProductID)
                .Index(t => t.VolumeID)
                .Index(t => t.ModemID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        FullName = c.String(),
                        Gender = c.Boolean(nullable: false),
                        Birthday = c.DateTime(),
                        Address = c.String(),
                        PhoneNumber = c.Int(nullable: false),
                        Email = c.String(),
                        HireDate = c.DateTime(),
                        Avatar = c.String(),
                        Status = c.Int(nullable: false),
                        RoleID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserID)
                .ForeignKey("dbo.Role", t => t.RoleID, cascadeDelete: true)
                .Index(t => t.RoleID);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        RoleID = c.Int(nullable: false),
                        RoleName = c.String(),
                    })
                .PrimaryKey(t => t.RoleID);
            
            CreateTable(
                "dbo.SupplierDetail",
                c => new
                    {
                        SupplierDetailID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(),
                        SupplierID = c.Int(),
                        UserID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SupplierDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.SupplierDetailID)
                .ForeignKey("dbo.Product", t => t.ProductID)
                .ForeignKey("dbo.Supplier", t => t.SupplierID)
                .ForeignKey("dbo.User", t => t.UserID, cascadeDelete: true)
                .Index(t => t.ProductID)
                .Index(t => t.SupplierID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Supplier",
                c => new
                    {
                        SupplierID = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(),
                        ContactName = c.String(),
                        Address = c.String(),
                        Phone = c.String(),
                        Fax = c.String(),
                    })
                .PrimaryKey(t => t.SupplierID);
            
            CreateTable(
                "dbo.Shipper",
                c => new
                    {
                        ShipperID = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.ShipperID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BrandProduct", "ProductID", "dbo.Product");
            DropForeignKey("dbo.Order", "ShipperID", "dbo.Shipper");
            DropForeignKey("dbo.Order", "ProductID", "dbo.Product");
            DropForeignKey("dbo.Volume", "UserID", "dbo.User");
            DropForeignKey("dbo.SupplierDetail", "UserID", "dbo.User");
            DropForeignKey("dbo.SupplierDetail", "SupplierID", "dbo.Supplier");
            DropForeignKey("dbo.SupplierDetail", "ProductID", "dbo.Product");
            DropForeignKey("dbo.User", "RoleID", "dbo.Role");
            DropForeignKey("dbo.Order", "UserID", "dbo.User");
            DropForeignKey("dbo.Sale", "VolumeID", "dbo.Volume");
            DropForeignKey("dbo.Sale", "ProductID", "dbo.Product");
            DropForeignKey("dbo.Sale", "ModemID", "dbo.Modem");
            DropForeignKey("dbo.Volume", "CustomerID", "dbo.Customer");
            DropForeignKey("dbo.Order", "CustomerID", "dbo.Customer");
            DropForeignKey("dbo.Modem", "ProductID", "dbo.Product");
            DropForeignKey("dbo.Brand", "Product_ProductID", "dbo.Product");
            DropForeignKey("dbo.BrandProduct", "BrandID", "dbo.Brand");
            DropIndex("dbo.SupplierDetail", new[] { "UserID" });
            DropIndex("dbo.SupplierDetail", new[] { "SupplierID" });
            DropIndex("dbo.SupplierDetail", new[] { "ProductID" });
            DropIndex("dbo.User", new[] { "RoleID" });
            DropIndex("dbo.Sale", new[] { "ModemID" });
            DropIndex("dbo.Sale", new[] { "VolumeID" });
            DropIndex("dbo.Sale", new[] { "ProductID" });
            DropIndex("dbo.Volume", new[] { "CustomerID" });
            DropIndex("dbo.Volume", new[] { "UserID" });
            DropIndex("dbo.Order", new[] { "ProductID" });
            DropIndex("dbo.Order", new[] { "ShipperID" });
            DropIndex("dbo.Order", new[] { "UserID" });
            DropIndex("dbo.Order", new[] { "CustomerID" });
            DropIndex("dbo.Modem", new[] { "ProductID" });
            DropIndex("dbo.Brand", new[] { "Product_ProductID" });
            DropIndex("dbo.BrandProduct", new[] { "ProductID" });
            DropIndex("dbo.BrandProduct", new[] { "BrandID" });
            DropTable("dbo.Shipper");
            DropTable("dbo.Supplier");
            DropTable("dbo.SupplierDetail");
            DropTable("dbo.Role");
            DropTable("dbo.User");
            DropTable("dbo.Sale");
            DropTable("dbo.Volume");
            DropTable("dbo.Customer");
            DropTable("dbo.Order");
            DropTable("dbo.Modem");
            DropTable("dbo.Product");
            DropTable("dbo.Brand");
            DropTable("dbo.BrandProduct");
        }
    }
}
