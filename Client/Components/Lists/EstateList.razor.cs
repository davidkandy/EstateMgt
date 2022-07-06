using Microsoft.AspNetCore.Components;
using Shared.Models.DTOs.Admin;

namespace Client.Components.Lists
{
    public partial class EstateList : ComponentBase
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public IEnumerable<EstateDto> Estates { get; set; } = new List<EstateDto>();

        //protected override async Task OnInitializedAsync()
        //{
        //    return base.OnInitializedAsync();
        //}
    }
}
