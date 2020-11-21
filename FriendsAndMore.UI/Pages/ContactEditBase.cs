using System.Threading.Tasks;
using FriendsAndMore.UI.Models;
using FriendsAndMore.UI.Services;
using Microsoft.AspNetCore.Components;

namespace FriendsAndMore.UI.Pages
{
    public class ContactEditBase : ComponentBase
    {
        [Inject] 
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IContactService ContactService { get; set; }

        [Inject]
        public IEntityDataService EntityService { get; set; }

        [Parameter]
        public string ContactId { get; set; }
        
        public Contact Contact { get; set; } = new Contact();

        protected bool Saved;
        protected string Message = string.Empty;
        protected string MessageTitle = string.Empty;
        protected string StatusClass = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            Saved = false;

            int.TryParse(ContactId, out var contactId);

            if (contactId == 0)
            {
                Contact = new Contact();
            }
            else
            {
                Contact = await ContactService.GetContactById(contactId);
            }
        }
        
        protected async Task HandleValidSubmit()
        {
            if (Contact.ContactId == 0) //new contact
            {
                var addedContact = await ContactService.AddContact(Contact);
                if (addedContact != null)
                {
                    StatusClass = "is-success";
                    MessageTitle = "Contact added";
                    Message = "New contact added successfully.";
                    Saved = true;
                }
                else
                {
                    StatusClass = "is-danger";
                    MessageTitle = "Oops!";
                    Message = "Something went wrong adding the new contact. Please try again.";
                    Saved = false;
                }
            }
            else
            {
                await ContactService.UpdateContact(Contact);
                StatusClass = "is-success";
                MessageTitle = "Contact updated";
                Message = "The contact was updated successfully.";
                Saved = true;
            }
        }

        protected void HandleInvalidSubmit()
        {
            StatusClass = "is-danger";
            Message = "There are some validation errors. Please try again.";
        }
        
        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/");
        }

        protected void DeleteContact()
        {
            if (Contact.ContactId == 0)
            {
                StatusClass = "is-danger";
                MessageTitle = "Oops!";
                Message = "Something went wrong adding the new contact. Please try again.";
                Saved = false;
            }

            ContactService.DeleteContact(Contact.ContactId);

            StatusClass = "is-success";
            MessageTitle = "Deleted";
            Message = "The contact is deleted successfully.";
            Saved = true;
        }

        protected void CreateEmailAddress()
        {
            NavigationManager.NavigateTo("/EmailEdit/" + Contact.ContactId);
        }
        
        protected void UpdateEmailAddress(int emailId)
        {
            NavigationManager.NavigateTo("/EmailEdit/" + Contact.ContactId + "/" + emailId);
        }
        
        protected void DeleteEmailAddress(int emailId)
        {
            if (emailId == 0)
            {
                StatusClass = "is-danger";
                MessageTitle = "Oops!";
                Message = "Something went wrong deleting an email address. Please try again.";
                Saved = false;
            }

            EntityService.Delete<EmailAddress>(emailId);

            StatusClass = "is-success";
            MessageTitle = "Deleted";
            Message = "The email address is deleted successfully.";
            Saved = true;
        }
        
        protected void CreateRelationship()
        {
            NavigationManager.NavigateTo("/RelationshipEdit/" + Contact.ContactId);
        }
        
        protected void UpdateRelationship(int relationshipId)
        {
            NavigationManager.NavigateTo("/RelationshipEdit/" + Contact.ContactId + "/" + relationshipId);
        }
        
        protected void DeleteRelationship(int relationshipId)
        {
            if (relationshipId == 0)
            {
                StatusClass = "is-danger";
                MessageTitle = "Oops!";
                Message = "Something went wrong deleting an relationship. Please try again.";
                Saved = false;
            }

            EntityService.Delete<Relationship>(relationshipId);

            StatusClass = "is-success";
            MessageTitle = "Deleted";
            Message = "The relationship is deleted successfully.";
            Saved = true;
        }
        
        protected void CreateStatusUpdate()
        {
            NavigationManager.NavigateTo("/StatusUpdateEdit/" + Contact.ContactId);
        }
        
        protected void UpdateStatusUpdate(int statusUpdateId)
        {
            NavigationManager.NavigateTo("/StatusUpdateEdit/" + Contact.ContactId + "/" + statusUpdateId);
        }
        
        protected void DeleteStatusUpdate(int statusUpdateId)
        {
            if (statusUpdateId == 0)
            {
                StatusClass = "is-danger";
                MessageTitle = "Oops!";
                Message = "Something went wrong deleting an status update. Please try again.";
                Saved = false;
            }

            EntityService.Delete<StatusUpdate>(statusUpdateId);

            StatusClass = "is-success";
            MessageTitle = "Deleted";
            Message = "The status update is deleted successfully.";
            Saved = true;
        }
    }
}