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
    public partial class TitleSelector : ComponentBase
    {
        [Parameter]
        public string Label { get; set; }

        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public EventCallback<string> TitleChanged { get; set; }

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

        public IEnumerable<string> TitleOptions { get; set; } = new HashSet<string>();

        protected async Task<IEnumerable<string>> SearchAsync(string value)
        {
            TitleOptions = await Task.Run(() => Titles.GetTitles());
            
            if (string.IsNullOrEmpty(value))
            {
                return TitleOptions;
            }

            return TitleOptions.Where(x => x.Contains(value, StringComparison.InvariantCultureIgnoreCase));
        }

        private async void OnChanged(string value)
        {
            if (Error)
            {
                await ErrorChanged.InvokeAsync(Error);
                await ErrorTextChanged .InvokeAsync(ErrorText);
            }
            await TitleChanged.InvokeAsync(value);
            await SearchAsync(value);
            StateHasChanged();
        }
    }
}
