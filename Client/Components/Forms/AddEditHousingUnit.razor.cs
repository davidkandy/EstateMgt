using Microsoft.AspNetCore.Components;
using MudBlazor;
using Shared.Models.DTOs.Admin;

namespace Client.Components.Forms
{
    public partial class AddEditHousingUnit : ComponentBase
    {
        [Parameter] public Guid Id { get; set; }
        public HousingUnitForUpdate HousingUnit { get; set; } = new HousingUnitForUpdate();
        [Inject] public HttpClient Client { get; set; }
        [Inject] public ISnackbar Snackbar { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }
        [Parameter] public bool Saved { get; set; }
        [Parameter] public EventCallback<bool> SavedChange { get; set; }
        public string HousingBlockId { get; set; }
        public string HousingTypeId { get; set; }

        //private async Task OnSubmit()
        //{

        //}
    }
}
