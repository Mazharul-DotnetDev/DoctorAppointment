using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DoctorAppointment.Models
{

    [Table("ConsumerInfo")]
    public class ConsumerInfo
    {
        [Key]
        [Required]
        [StringLength(50, MinimumLength = 4)]
        public string ConsumerName { get; set; }


        [Required]
        [StringLength(50, MinimumLength = 4)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string Role { get; set; }
    }
}