using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace WalkerAdvertisingLead.Server.Models
{
    public class Lead
    {
        public Guid Id { get; set; } // Unique identifier

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"^(\d{10}|\d{3}-\d{3}-\d{4})$", ErrorMessage = "Invalid phone number format. Accepted formats are 1234567890 or 123-456-7890.")]
        public string PhoneNumber { get; set; }

        [Required]
        [MaxLength(10)]
        public string ZipCode { get; set; }

        [Required]
        public bool HasEmailPermission { get; set; }

        [Required]
        public bool HasTextPermission { get; set; }

        [ValidEmail(ErrorMessage = "Invalid email format.")]
        public string? Email { get; set; } // Optional field


    }

    public class ValidEmailAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var email = value as string;
            if (string.IsNullOrWhiteSpace(email))
            {
                return true; // Allow empty email, you can adjust based on requirements
            }

            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailPattern);
        }
    }
}
