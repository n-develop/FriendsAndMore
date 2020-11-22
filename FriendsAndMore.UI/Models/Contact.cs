using System;
using System.Collections.Generic;
using System.Linq;

namespace FriendsAndMore.UI.Models
{
    public class Contact
    {
        public Contact()
        {
            EmailAddresses = new List<EmailAddress>();
            Relationships = new List<Relationship>();
            StatusUpdates = new List<StatusUpdate>();
            TelephoneNumbers = new List<TelephoneNumber>();
        }
        
        public int Id { get; set; }

        public bool IsFavorite { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        
        public string MiddleName { get; set; }
        
        public string Address { get; set; }

        public DateTime Birthday { get; set; }
        
        public string Employer { get; set; }

        public string BusinessTitle { get; set; }
        
        public string Tags { get; set; }

        public List<EmailAddress> EmailAddresses { get; set; }
        
        public List<Relationship> Relationships { get; set; }

        public List<StatusUpdate> StatusUpdates { get; set; }
        
        public List<TelephoneNumber> TelephoneNumbers { get; set; }

        public List<StatusUpdate> Timeline
        {
            get
            {
                if (StatusUpdates != null && StatusUpdates.Any())
                {
                    return StatusUpdates.OrderByDescending(c => c.Created).ToList();
                }

                return new List<StatusUpdate>();
            }
        }
        
        public string FullName
        {
            get
            {
                var fullname = string.Empty;
                if (!string.IsNullOrWhiteSpace(FirstName))
                {
                    fullname = FirstName;
                }

                if (!string.IsNullOrWhiteSpace(MiddleName))
                {
                    fullname = string.Join(" ", fullname, MiddleName);
                }

                if (!string.IsNullOrWhiteSpace(LastName))
                {
                    fullname = string.Join(" ", fullname, LastName);
                }

                return fullname.Trim();
            }
        }
    }
}