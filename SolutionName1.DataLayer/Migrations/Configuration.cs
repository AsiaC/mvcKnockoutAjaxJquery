namespace SolutionName1.DataLayer.Migrations
{
    using SolutionName1.Model;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SolutionName1.DataLayer.SalesContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(SolutionName1.DataLayer.SalesContext context)
        {
            context.SalesOrders.AddOrUpdate(
                so => so.CustomerName,
                new SalesOrder { SalesOrderId = "1", CustomerName = "Adam", PONumber = "9876" },
                new SalesOrder { SalesOrderId = "2", CustomerName = "Michael" },
                new SalesOrder { SalesOrderId = "3", CustomerName = "Dawid", PONumber = "Acme 9" }
                );
        }
    }
}
