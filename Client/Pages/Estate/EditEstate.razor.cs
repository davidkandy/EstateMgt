using Microsoft.AspNetCore.Components;

namespace Client.Pages.Estate
{
    public partial class EditEstate : ComponentBase
    {
        [Parameter]
        public Guid EstateId { get; set; }
    }
}
