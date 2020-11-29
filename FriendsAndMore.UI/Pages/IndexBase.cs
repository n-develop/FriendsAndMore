using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FriendsAndMore.UI.Models;
using FriendsAndMore.UI.Services;
using Microsoft.AspNetCore.Components;

namespace FriendsAndMore.UI.Pages
{
    public class IndexBase : ComponentBase, IDisposable
    {
        [Inject]
        private IContactService ContactService { get; set; }

        [Inject] 
        protected ApplicationState AppState { get; set; }

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
                var allContacts = await ContactService.GetAllContacts();
                InvokeAsync(() =>
                {
                    AppState.SetContacts(allContacts.ToList());
                });
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

        protected override void OnInitialized()
        {
            AppState.OnChange += StateHasChanged;
        }

        public void Dispose()
        {
            AppState.OnChange -= StateHasChanged;
        }
    }
}