using System.Data.Entity.Migrations;

namespace EFORM.Migrations
{
    public class Norhtwind1_3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("Northwind.Territories", "RegionID", "Northwind.Region");
            DropIndex("Northwind.Territories", new[] { "RegionID" });
            CreateTable(
                "Northwind.Regions",
                c => new
                {
                    RegionsID = c.Int(nullable: false),
                    RegionDescription = c.String(nullable: false, maxLength: 50),
                })
                .PrimaryKey(t => t.RegionsID);

            AddColumn("Northwind.Customers", "FoundationDate", c => c.DateTime(nullable: false));
            AddColumn("Northwind.Territories", "Region_RegionsID", c => c.Int());
            CreateIndex("Northwind.Territories", "Region_RegionsID");
            AddForeignKey("Northwind.Territories", "Region_RegionsID", "Northwind.Regions", "RegionsID");
        }
        public override void Down()
        {
            CreateTable(
                "Northwind.Region",
                c => new
                {
                    RegionID = c.Int(nullable: false),
                    RegionDescription = c.String(nullable: false, maxLength: 50),
                })
                .PrimaryKey(t => t.RegionID);

            DropForeignKey("Northwind.Territories", "Region_RegionsID", "Northwind.Regions");
            DropIndex("Northwind.Territories", new[] { "Region_RegionsID" });
            DropColumn("Northwind.Territories", "Region_RegionsID");
            DropColumn("Northwind.Customers", "FoundationDate");
            DropTable("Northwind.Regions");
            CreateIndex("Northwind.Territories", "RegionID");
            AddForeignKey("Northwind.Territories", "RegionID", "Northwind.Region", "RegionID", cascadeDelete: true);
        }
    }
}