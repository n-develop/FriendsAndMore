using System.Threading.Tasks;
using FriendsAndMore.UI.Models;
using FriendsAndMore.UI.Services;
using Microsoft.AspNetCore.Components;

namespace FriendsAndMore.UI.Pages
{
    public class RelationshipEditBase : ComponentBase
    {
        [Inject] 
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IRelationshipService RelationshipService { get; set; }
        
        protected Relationship Relationship { get; set; } = new Relationship();
        
        [Parameter]
        public string ContactId { get; set; }

        [Parameter]
        public string RelationshipId { get; set; }
        
        protected bool Saved;
        protected string Message = string.Empty;
        protected string MessageTitle = string.Empty;
        protected string StatusClass = string.Empty;
        
        protected override async Task OnInitializedAsync()
        {
            Saved = false;

            var contactId = int.Parse(ContactId);

            int.TryParse(RelationshipId, out var relationshipId);

            if (relationshipId == 0)
            {
                Relationship = new Relationship
                {
                    ContactId = contactId
                };
            }
            else
            {
                Relationship = await RelationshipService.GetRelationshipById(relationshipId);
            }
        }
        
        protected async Task HandleValidSubmit()
        {
            if (Relationship.RelationshipId == 0)
            {
                var addedRelationship = RelationshipService.AddRelationship(Relationship);
                if (addedRelationship != null)
                {
                    StatusClass = "is-success";
                    MessageTitle = "Relationship added";
                    Message = "New relationship added successfully.";
                    Saved = true;
                }
                else
                {
                    StatusClass = "is-danger";
                    MessageTitle = "Oops!";
                    Message = "Something went wrong adding the new relationship. Please try again.";
                    Saved = false;
                }
            }
            else
            {
                await RelationshipService.UpdateRelationship(Relationship);
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
            NavigationManager.NavigateTo("/ContactEdit/" + Relationship.ContactId);
        }
    }
}