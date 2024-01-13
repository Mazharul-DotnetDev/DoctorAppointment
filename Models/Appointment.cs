using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace DoctorAppointment.Models
{
    public class Appointment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AppointmentId { get; set; }

        [MaxLength(100)]
        public string PatientName { get; set; }

        public string PatientContactNumber { get; set; }


        [Column(TypeName = "datetime2")]
        [DataType(DataType.Date)]
        [DisplayName("Appointment Schedule Time")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        public DateTime AppointmentScheduleTime { get; set; }

        [Column(TypeName = "datetime2")]
        [DataType(DataType.Date)]
        [DisplayName("Appointment Applied Time")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime AppointmentAppliedTime { get; set; }

       
        public int DoctorId { get; set; }

        
    }
}