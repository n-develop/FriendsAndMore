using System.ComponentModel.DataAnnotations;

namespace FriendsAndMore.UI.Models
{
    public class Relationship
    {
        public int Id { get; set; }
        
        [Required]
        public string Person { get; set; }
        
        [Required]
        public string Type { get; set; }

        public int ContactId { get; set; }
    }
}