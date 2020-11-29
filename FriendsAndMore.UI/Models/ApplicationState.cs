using System;
using System.Collections.Generic;

namespace FriendsAndMore.UI.Models
{
    public class ApplicationState
    {
        public ApplicationState()
        {
            Contacts = new List<Contact>();
        }
        
        public List<Contact> Contacts { get; private set; }
        
        public event Action OnChange;
        
        private void NotifyStateChanged() => OnChange?.Invoke();

        public void SetContacts(List<Contact> contacts)
        {
            Contacts = contacts;
            NotifyStateChanged();
        }
    }
}