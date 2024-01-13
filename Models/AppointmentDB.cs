using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DoctorAppointment.Models
{
    public class AppointmentDB : DbContext
    {
        public DbSet<Department> dbsDepartment { get; set; }
        public DbSet<Doctor> dbsDoctor { get; set; }
        public DbSet<Appointment> dbsAppointment { get; set; }


        public DbSet<ConsumerInfo> dbsConsumerInfo { get; set; }


        public AppointmentDB () : base("Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=AppointmentDb;Integrated Security=True;")
        {


        }


    }
}