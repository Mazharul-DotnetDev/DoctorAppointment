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
        [Required(ErrorMessage = "Consumer name is required.")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Consumer name must be between 4 and 50 characters.")]    
        [Display(Name = "Consumer Name")]
        public string ConsumerName { get; set; }



        [Required]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters long.")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", ErrorMessage = "Password must contain at least one lowercase letter, one uppercase letter, one digit, and one special character.")]
        public string Password { get; set; }



        [EnumDataType(typeof(ConsumerRoles))]
        public string Role { get; set; }



        // Consider adding timestamps for auditing and tracking changes
        [Timestamp]
        public byte[] RowVersion { get; set; }

        [ConcurrencyCheck]
        public DateTime? LastUpdated { get; set; }

        // Consider soft deletion for data retention
        public bool IsDeleted { get; set; }

    }


    public enum ConsumerRoles
    {
        Patient,
        Doctor,
        Administrator
    }
}