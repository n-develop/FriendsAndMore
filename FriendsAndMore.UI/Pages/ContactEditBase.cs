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

        [Parameter]
        public string ContactId { get; set; }
        
        public Contact Contact { get; set; } = new Contact();

        //used to store state of screen
        protected bool Saved;
        protected string Message = string.Empty;
        protected string StatusClass = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            Saved = false;

            int.TryParse(ContactId, out var contactId);

            if (contactId == 0)
            {
                Contact = new Contact { FirstName = "Firstname", LastName = "Lastname" };
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
                    StatusClass = "alert-success";
                    Message = "New contact added successfully.";
                    Saved = true;
                }
                else
                {
                    StatusClass = "alert-danger";
                    Message = "Something went wrong adding the new contact. Please try again.";
                    Saved = false;
                }
            }
            else
            {
                await ContactService.UpdateContact(Contact);
                StatusClass = "alert-success";
                Message = "Contact updated successfully.";
                Saved = true;
            }
        }

        protected void HandleInvalidSubmit()
        {
            StatusClass = "alert-danger";
            Message = "There are some validation errors. Please try again.";
        }
        
        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/");
        }
    }
}