using System.ComponentModel.DataAnnotations;

namespace FriendsAndMore.UI.Models
{
    public class EmailAddress
    {
        public int EmailAddressId { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        public string Type { get; set; }

        public int ContactId { get; set; }
    }
}