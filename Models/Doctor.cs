using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoctorAppointment.Models
{
    public class Doctor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DoctorId { get; set; }

        [Required]
        [MaxLength(100)]
        public string DoctorName { get; set; }



        [DataType(DataType.MultilineText)]
        [StringLength(250)]
        public string Specialization { get; set; }

        [MaxLength(20)]
        public string ContactNumber { get; set; }

        public decimal ConsultationFee { get; set; }

        public bool IsAvailable { get; set; }

       
        public int DepartmentId { get; set; }

        
        public virtual Department Department { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}