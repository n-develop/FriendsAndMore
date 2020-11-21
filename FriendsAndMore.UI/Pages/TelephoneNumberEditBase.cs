using System.Threading.Tasks;
using FriendsAndMore.UI.Models;
using FriendsAndMore.UI.Services;
using Microsoft.AspNetCore.Components;

namespace FriendsAndMore.UI.Pages
{
    public class TelephoneNumberEditBase : ComponentBase
    {
        [Inject] 
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IEntityDataService EntityService { get; set; }
        
        protected TelephoneNumber TelephoneNumber { get; set; } = new TelephoneNumber();
        
        [Parameter]
        public string ContactId { get; set; }

        [Parameter]
        public string TelephoneNumberId { get; set; }
        
        protected bool Saved;
        protected string Message = string.Empty;
        protected string MessageTitle = string.Empty;
        protected string StatusClass = string.Empty;
        
        protected override async Task OnInitializedAsync()
        {
            Saved = false;

            var contactId = int.Parse(ContactId);

            int.TryParse(TelephoneNumberId, out var telephoneNumberId);

            if (telephoneNumberId == 0)
            {
                TelephoneNumber = new TelephoneNumber
                {
                    ContactId = contactId
                };
            }
            else
            {
                TelephoneNumber = await EntityService.GetById<TelephoneNumber>(telephoneNumberId);
            }
        }
        
        protected async Task HandleValidSubmit()
        {
            if (TelephoneNumber.Id == 0)
            {
                var addedEntity = EntityService.Add(TelephoneNumber);
                if (addedEntity != null)
                {
                    StatusClass = "is-success";
                    MessageTitle = "Telephone Number added";
                    Message = "New telephone number added successfully.";
                    Saved = true;
                }
                else
                {
                    StatusClass = "is-danger";
                    MessageTitle = "Oops!";
                    Message = "Something went wrong adding the new telephone number. Please try again.";
                    Saved = false;
                }
            }
            else
            {
                await EntityService.Update(TelephoneNumber);
                StatusClass = "is-success";
                MessageTitle = "Telephone Number updated";
                Message = "The telephone number was updated successfully.";
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
            NavigationManager.NavigateTo("/ContactEdit/" + TelephoneNumber.ContactId);
        }
    }
}