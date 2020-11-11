using System.ComponentModel.DataAnnotations;

namespace FriendsAndMore.DataAccess.Entities
{
    public class Contact
    {
        [Key]
        public int ContactId { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "First name is too long.")]
        public string Firstname { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Last name is too long.")]
        public string Lastname { get; set; }
    }
}