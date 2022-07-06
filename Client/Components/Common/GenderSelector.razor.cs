using Microsoft.AspNetCore.Components;
using Client.Models;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Client.Components.Common
{
    public partial class GenderSelector : ComponentBase
    {
        [Parameter]
        public string Label { get; set; }

        [Parameter]
        public string Gender { get; set; }

        [Parameter]
        public EventCallback<string> GenderChanged { get; set; }
        [Parameter]
        public Expression<Func<string>> For { get; set; }
        [Parameter]
        public EventCallback<bool> ErrorChanged { get; set; }
        [Parameter]
        public EventCallback<string> ErrorTextChanged { get; set; }
        [Parameter]
        public bool Required { get; set; } = false;
        [Parameter]
        public string RequiredError { get; set; }
        [Parameter]
        public bool Error { get; set; } = false;
        [Parameter]
        public string ErrorText { get; set; }

        private void OnChanged(IEnumerable<string> selectedItems)
        {
            if (Error)
            {
                ErrorChanged.InvokeAsync(Error);
                ErrorTextChanged.InvokeAsync(ErrorText);
            }
            GenderChanged.InvokeAsync(selectedItems.FirstOrDefault());
            StateHasChanged();
        }
    }
}
