using System.Threading.Tasks;
using FriendsAndMore.UI.Models;
using FriendsAndMore.UI.Services;
using Microsoft.AspNetCore.Components;

namespace FriendsAndMore.UI.Pages
{
    public class StatusUpdateEditBase : ComponentBase
    {
        [Inject] 
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IEntityDataService EntityService { get; set; }
        
        protected StatusUpdate StatusUpdate { get; set; } = new StatusUpdate();
        
        [Parameter]
        public string ContactId { get; set; }

        [Parameter]
        public string StatusUpdateId { get; set; }
        
        protected bool Saved;
        protected string Message = string.Empty;
        protected string MessageTitle = string.Empty;
        protected string StatusClass = string.Empty;
        
        protected override async Task OnInitializedAsync()
        {
            Saved = false;

            var contactId = int.Parse(ContactId);

            int.TryParse(StatusUpdateId, out var statusUpdateId);

            if (statusUpdateId == 0)
            {
                StatusUpdate = new StatusUpdate()
                {
                    ContactId = contactId
                };
            }
            else
            {
                StatusUpdate = await EntityService.GetById<StatusUpdate>(statusUpdateId);
            }
        }
        
        protected async Task HandleValidSubmit()
        {
            if (StatusUpdate.StatusUpdateId == 0)
            {
                var addedStatusUpdate = EntityService.Add(StatusUpdate);
                if (addedStatusUpdate != null)
                {
                    StatusClass = "is-success";
                    MessageTitle = "StatusUpdate added";
                    Message = "New status update added successfully.";
                    Saved = true;
                }
                else
                {
                    StatusClass = "is-danger";
                    MessageTitle = "Oops!";
                    Message = "Something went wrong adding the new status update. Please try again.";
                    Saved = false;
                }
            }
            else
            {
                await EntityService.Update(StatusUpdate);
                StatusClass = "is-success";
                MessageTitle = "Relationship updated";
                Message = "The relationship was updated successfully.";
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
            NavigationManager.NavigateTo("/ContactEdit/" + StatusUpdate.ContactId);
        }
    }
}