using EFPRM.Models;

namespace EFPRM.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EFPRM.Models.Northwind>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "EFPRM.Models.Northwind";
        }

        protected override void Seed(EFPRM.Models.Northwind context)
        {
            context.Regions.AddOrUpdate(region => region.RegionsID,
                 new Regions
                 {
                     RegionsID = 1,
                     RegionDescription = "Des 1"

                 },
                 new Regions
                 {
                     RegionsID = 2,
                     RegionDescription = "Des 2"
                 },
                 new Regions
                 {
                     RegionsID = 3,
                     RegionDescription = "Des 3"
                 },
                 new Regions
                 {
                     RegionsID = 4,
                     RegionDescription = "Des 4"
                 }
             );

            context.Territories.AddOrUpdate(territory => territory.TerritoryID,
                new Territory
                {
                    TerritoryID = "01333",
                    TerritoryDescription = "Ter 1",
                    RegionID = 1
                },
                new Territory
                {
                    TerritoryID = "01421",
                    TerritoryDescription = "Des 2",
                    RegionID = 2
                },
                new Territory
                {
                    TerritoryID = "01841",
                    TerritoryDescription = "Des 3",
                    RegionID = 3
                },
                new Territory
                {
                    TerritoryID = "01234",
                    TerritoryDescription = "Des 4",
                    RegionID = 4
                }
            );

            context.Categories.AddOrUpdate(category => category.CategoryID,
                new Category
                {
                    CategoryID = 1,
                    CategoryName = "Cat 1",
                    Description = "Des 1"
                },
                new Category
                {
                    CategoryID = 2,
                    CategoryName = "Cat 2",
                    Description = "Des 2"
                },
                new Category
                {
                    CategoryID = 3,
                    CategoryName = "Cat 3",
                    Description = "Des 3"
                },
                new Category
                {
                    CategoryID = 4,
                    CategoryName = "Cat 4",
                    Description = "Des 4"
                }
            );
        }
    }
}
