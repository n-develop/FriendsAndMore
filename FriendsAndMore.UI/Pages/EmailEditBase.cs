using System;
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
        public IEmailService EmailService { get; set; }

        protected EmailAddress Email { get; set; } = new EmailAddress();
        
        [Parameter]
        public string CId { get; set; }

        [Parameter]
        public string EmailAddressId { get; set; }
        
        protected bool Saved;
        protected string Message = string.Empty;
        protected string MessageTitle = string.Empty;
        protected string StatusClass = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            Saved = false;

            var contactId = int.Parse(CId);

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
                Email = await EmailService.GetEmailAddressById(emailId);
            }
        }

        protected void HandleValidSubmit()
        {
            throw new NotImplementedException();
        }

        protected void HandleInvalidSubmit()
        {
            throw new NotImplementedException();
        }
        
        protected void NavigateToContact()
        {
            NavigationManager.NavigateTo("/ContactEdit/" + Email.ContactId);
        }
    }
}