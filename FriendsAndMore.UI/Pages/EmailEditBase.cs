using System.Threading.Tasks;
using FriendsAndMore.UI.Models;
using FriendsAndMore.UI.Services;
using Microsoft.AspNetCore.Components;

namespace FriendsAndMore.UI.Pages
{
    public class EmailEditBase : ComponentBase
    {
        [Inject] 
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IEntityDataService EntityService { get; set; }

        protected EmailAddress Email { get; set; } = new EmailAddress();
        
        [Parameter]
        public string ContactId { get; set; }

        [Parameter]
        public string EmailAddressId { get; set; }
        
        protected bool Saved;
        protected string Message = string.Empty;
        protected string MessageTitle = string.Empty;
        protected string StatusClass = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            Saved = false;

            var contactId = int.Parse(ContactId);

            int.TryParse(EmailAddressId, out var emailId);

            if (emailId == 0)
            {
                Email = new EmailAddress
                {
                    ContactId = contactId
                };
            }
            else
            {
                Email = await EntityService.GetById<EmailAddress>(emailId);
            }
        }

        protected async Task HandleValidSubmit()
        {
            if (Email.Id == 0)
            {
                var addedEmailAddress = EntityService.Add(Email);
                if (addedEmailAddress != null)
                {
                    StatusClass = "is-success";
                    MessageTitle = "Email address added";
                    Message = "New email address added successfully.";
                    Saved = true;
                }
                else
                {
                    StatusClass = "is-danger";
                    MessageTitle = "Oops!";
                    Message = "Something went wrong adding the new email address. Please try again.";
                    Saved = false;
                }
            }
            else
            {
                await EntityService.Update(Email);
                StatusClass = "is-success";
                MessageTitle = "Email address updated";
                Message = "The email address was updated successfully.";
                Saved = true;
            }
        }

        protected void HandleInvalidSubmit()
        {
            StatusClass = "is-danger";
            Message = "There are some validation errors. Please try again.";
        }
        
        protected void NavigateToContact()
        {
            NavigationManager.NavigateTo("/ContactEdit/" + Email.ContactId);
        }
    }
}