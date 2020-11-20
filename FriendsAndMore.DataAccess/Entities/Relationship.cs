using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FriendsAndMore.DataAccess.Entities
{
    public class Relationship
    {
        [Key]
        public int RelationshipId { get; set; }
        
        [Required]
        public string Person { get; set; }
        
        [Required]
        public string Type { get; set; }

        public int ContactId { get; set; }
        [JsonIgnore]
        public virtual Contact Contact { get; set; }
    }
}