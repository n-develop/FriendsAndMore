using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FriendsAndMore.DataAccess.Entities
{
    public class TelephoneNumber
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Telephone { get; set; } 
        
        [Required]
        public string Type { get; set; }

        public int ContactId { get; set; }

        [JsonIgnore]
        public virtual Contact Contact { get; set; }
    }
}