using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FriendsAndMore.UI.Models;
using FriendsAndMore.UI.Services;
using Microsoft.AspNetCore.Components;

namespace FriendsAndMore.UI.Pages
{
    public class IndexBase : ComponentBase
    {
        protected IEnumerable<Contact> Contacts;

        [Inject]
        public IContactService ContactService { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await Task.Run(() => LoadContacts(true));
                StateHasChanged();
            }
        }

        private async Task LoadContacts(bool firstTry)
        {
            try
            {
                Contacts = await ContactService.GetAllContacts();
            }
            catch (Exception e)
            {
                if (firstTry)
                {
                    Thread.Sleep(2000);
                    await LoadContacts(false);
                }
                else
                {
                    Console.WriteLine(e);
                    throw;    
                }
            }
        }
    }
}