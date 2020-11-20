using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FriendsAndMore.DataAccess.Entities
{
    public class StatusUpdate
    {
        [Key]
        public int StatusUpdateId { get; set; }
        [Required]
        public string StatusText { get; set; }
        [Required]
        public DateTime Created { get; set; }
        
        public int ContactId { get; set; }
        [JsonIgnore]
        public virtual Contact Contact { get; set; }
    }
}