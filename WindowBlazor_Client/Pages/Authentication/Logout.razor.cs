using Microsoft.AspNetCore.Components;
using WindowBlazor_Client.Service.IService;

namespace WindowBlazor_Client.Pages.Authentication
{
    public partial class Logout
    {
        [Inject]
        public IAuthenticationService _authSerivce { get; set; }
        [Inject]
        public NavigationManager _navigationManager { get; set; }

        protected async override Task OnInitializedAsync()
        {
            await _authSerivce.Logout();
            _navigationManager.NavigateTo("/");
        }
    }
}
