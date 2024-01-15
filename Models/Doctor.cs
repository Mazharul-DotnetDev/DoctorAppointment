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

        [Required(ErrorMessage = "Doctor name is required.")]
        [StringLength(100, ErrorMessage = "Doctor name cannot exceed 100 characters.")]
        [Display(Name = "Doctor Name")]
        public string DoctorName { get; set; }



        [DataType(DataType.MultilineText)]
        [StringLength(250)]
        public string Specialization { get; set; }


        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Contact number should be 10 digits.")]
        [Display(Name = "Contact Number")]
        //[MaxLength(20)]
        public string ContactNumber { get; set; }


        [Range(0, double.MaxValue, ErrorMessage = "Consultation fee must be a non-negative value.")]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = false)]
        [Display(Name = "Consultation Fee")]
        public decimal ConsultationFee { get; set; }


        //[Display(Name = "Is Available")]
        public bool IsAvailable { get; set; }

        public string ImageUrl { get; set; }

        [NotMapped]
        [DataType(DataType.Upload)]
        [ScaffoldColumn(true)]

        public HttpPostedFileBase ImageUpload { get; set; }

        
        [Timestamp]
        public byte[] RowVersion { get; set; }

        [ConcurrencyCheck]
        public DateTime? LastUpdated { get; set; }

        // Consider soft deletion for data retention
        public bool IsDeleted { get; set; }


        public int DepartmentId { get; set; }

        
        public virtual Department Department { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}