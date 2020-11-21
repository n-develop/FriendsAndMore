using System;
using System.ComponentModel.DataAnnotations;

namespace FriendsAndMore.UI.Models
{
    public class StatusUpdate
    {
        public int StatusUpdateId { get; set; }
        
        [Required]
        public string StatusText { get; set; }
        
        [Required]
        public DateTime Created { get; set; }
        
        public int ContactId { get; set; }
    }
}