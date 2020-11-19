using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FriendsAndMore.DataAccess.Entities
{
    public class EmailAddress
    {
        [Key]
        public int EmailAddressId { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        public string Type { get; set; }

        public int ContactId { get; set; }
        [JsonIgnore]
        public virtual Contact Contact { get; set; }
    }
}