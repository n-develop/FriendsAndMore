using System.ComponentModel.DataAnnotations;

namespace FriendsAndMore.UI.Models
{
    public class TelephoneNumber
    {
        public int Id { get; set; }
        
        [Required]
        public string Telephone { get; set; } 
        
        [Required]
        public string Type { get; set; }

        public int ContactId { get; set; }
    }
}