namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TrashCollector.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TrashCollector.Models.ApplicationDbContext context)
        {
            //This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            //context.PickUpDays.AddOrUpdate(
            //   new Models.PickUpDay { DayOfWeek = "Sunday" },
            //   new Models.PickUpDay { DayOfWeek = "Monday" },
            //   new Models.PickUpDay { DayOfWeek = "Tuesday" },
            //   new Models.PickUpDay { DayOfWeek = "Wednesday" },
            //   new Models.PickUpDay { DayOfWeek = "Thursday" },
            //   new Models.PickUpDay { DayOfWeek = "Friday" },
            //   new Models.PickUpDay { DayOfWeek = "Saturday" }
            //);
        }
    }
}
