using FriendsAndMore.UI.Models;
using Microsoft.AspNetCore.Components;

namespace FriendsAndMore.UI.Pages
{
    public class ContactTeaserBase : ComponentBase
    {
        [Parameter]
        public Contact Contact { get; set; }
    }
}