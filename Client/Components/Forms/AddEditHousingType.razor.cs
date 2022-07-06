using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using Shared.Models.DTOs.Admin;

namespace Client.Components.Forms
{
    public partial class AddEditHousingType : ComponentBase
    {
        [Parameter] public Guid HousingTypeId { get; set; }
        public HousingTypeForUpdate HousingType { get; set; } = new HousingTypeForUpdate();
        [Inject] public HttpClient Client { get; set; }
        [Inject] public ISnackbar Snackbar { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }
        [Parameter] public bool Saved { get; set; }
        [Parameter] public EventCallback<bool> SavedChange { get; set; }
        public string EstateId { get; set; }

        //private async void OnSubmit()
        //{

        //}

        //private async void UploadFiles(InputFileChangeEventArgs e)
        //{

        //}
    }
}
