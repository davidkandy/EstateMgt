using Microsoft.AspNetCore.Components;

namespace Client.Pages.Jobs
{
    public partial class EditJob : ComponentBase
    {
        [Parameter]
        public int JobId { get; set; }
    }
}
