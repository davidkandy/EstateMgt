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
    public partial class StateSelector : ComponentBase
    {
        [Parameter]
        public string Label { get; set; }

        [Parameter]
        public string State { get; set; }

        [Parameter]
        public EventCallback<string> StateChanged { get; set; }

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

        private IEnumerable<string> stateOptions = new HashSet<string>();

        public IEnumerable<string> GetStateOptions()
        {
            return stateOptions;
        }

        public void SetStateOptions(IEnumerable<string> value)
        {
            stateOptions = value;
        }

        protected async Task<IEnumerable<string>> SearchAsync(string value)
        {
            stateOptions = await Task.Run(() => Nigeria.GetStates());
            
            if (string.IsNullOrEmpty(value))
            {
                return stateOptions;
            }

            return stateOptions.Where(x => x.Contains(value, StringComparison.InvariantCultureIgnoreCase));
        }

        private async void OnChanged(string value)
        {
            if (Error)
            {
                await ErrorChanged.InvokeAsync(Error);
                await ErrorTextChanged .InvokeAsync(ErrorText);
            }
            await StateChanged.InvokeAsync(value);
            await SearchAsync(value);
            StateHasChanged();
        }
    }
}
