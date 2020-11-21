using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FriendsAndMore.DataAccess.Entities
{
    public class Contact
    {
        [Key]
        public int ContactId { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "First name is too long.")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Last name is too long.")]
        public string LastName { get; set; }
        
        public string MiddleName { get; set; }
        
        public string Address { get; set; }
        
        public string Employer { get; set; }

        public string BusinessTitle { get; set; }
        
        public string Tags { get; set; }
        
        public virtual List<EmailAddress> EmailAddresses { get; set; }

        public virtual List<Relationship> Relationships { get; set; }

        public virtual List<StatusUpdate> StatusUpdates { get; set; }

        public virtual List<TelephoneNumber> TelephoneNumbers { get; set; }
    }
}