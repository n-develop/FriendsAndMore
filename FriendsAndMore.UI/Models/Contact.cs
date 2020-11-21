using System.Collections.Generic;

namespace FriendsAndMore.UI.Models
{
    public class Contact
    {
        public Contact()
        {
            EmailAddresses = new List<EmailAddress>();
            Relationships = new List<Relationship>();
            StatusUpdates = new List<StatusUpdate>();
        }
        
        public int ContactId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        
        public string MiddleName { get; set; }
        
        public string Address { get; set; }
        
        public string Employer { get; set; }

        public string BusinessTitle { get; set; }
        
        public string Tags { get; set; }

        public List<EmailAddress> EmailAddresses { get; set; }
        
        public List<Relationship> Relationships { get; set; }

        public List<StatusUpdate> StatusUpdates { get; set; }
        
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