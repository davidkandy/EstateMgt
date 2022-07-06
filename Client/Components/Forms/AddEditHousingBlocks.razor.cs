using Microsoft.AspNetCore.Components;
using MudBlazor;
using Shared.Models.DTOs;
using Shared.Models.DTOs.Admin;


namespace Client.Components.Forms
{
    public partial class AddEditHousingBlocks : ComponentBase
    {
        [Parameter]
        public Guid HousingBlockId { get; set; }
        public HousingBlockForUpdate HousingBlock { get; set; } = new HousingBlockForUpdate();
        [Inject] public HttpClient Client { get; set; }
        [Inject] public ISnackbar Snackbar { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }

        //private async void OnSubmit()
        //{

        //}
    }
}
