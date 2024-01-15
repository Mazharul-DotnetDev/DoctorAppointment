using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoctorAppointment.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }

        [Required]
        [MaxLength(50)]
        //[Display(Name = "Department Name")]
        [RegularExpression(@"^[a-zA-Z0-9\s]+$", ErrorMessage = "Department name can only contain letters, numbers, and spaces.")]
        public string DepartmentName { get; set; }

        // Consider adding timestamps for auditing and tracking changes
        [Timestamp]
        public byte[] RowVersion { get; set; }

        [ConcurrencyCheck]
        public DateTime? LastUpdated { get; set; }

        // Consider soft deletion for data retention
        public bool IsDeleted { get; set; }


    }
}