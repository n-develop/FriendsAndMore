using System;
using System.ComponentModel.DataAnnotations;

namespace FriendsAndMore.UI.Models
{
    public class StatusUpdate
    {
        public StatusUpdate()
        {
            Created = DateTime.Now.Date;
        }
        
        public int Id { get; set; }
        
        [Required]
        public string StatusText { get; set; }
        
        [Required]
        public DateTime Created { get; set; }
        
        public int ContactId { get; set; }
    }
}