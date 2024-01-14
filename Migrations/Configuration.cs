namespace DoctorAppointment.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DoctorAppointment.Models.AppointmentDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;


            //AutomaticMigrationDataLossAllowed = true;

            //ContextKey = "DoctorAppointment.Models.AppointmentDB";
        }

        protected override void Seed(DoctorAppointment.Models.AppointmentDB context)
        {
            context.dbsConsumerInfo.AddOrUpdate(new Models.ConsumerInfo() { ConsumerName = "Doctor", Password = "abc123", Role = "Admin" });


            context.dbsConsumerInfo.AddOrUpdate(new Models.ConsumerInfo() { ConsumerName = "Patient", Password = "123456", Role = "User" });
        }
    }
}
