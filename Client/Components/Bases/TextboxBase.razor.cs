using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace Client.Components.Bases
{
    public partial class TextboxBase : ComponentBase
    {
        [Parameter]
        public string Label { get; set; }
        [Parameter]
        public string Text { get; set; }
        [Parameter]
        public string Property { get; set; }
        [Parameter]
        public Expression<Func<string>> For { get; set; }
        [Parameter]
        public object Validation { get; set; }
        [Parameter]
        public EventCallback<object> ValidationChanged { get; set; }
        [Parameter]
        public EventCallback<string> TextChanged { get; set; }
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
        [Parameter]
        public bool MultiLine { get; set; } = false;
        [Parameter]
        public int Lines { get; set; } = 1;

        private void OnTextChanged()
        {
            if (Error)
                NotifyError();
            TextChanged.InvokeAsync(Text);
        }

        protected override Task OnParametersSetAsync()
        {
            if (MultiLine && Lines == 1)
                Lines = 2;

            return base.OnParametersSetAsync();
        }

        private void NotifyError()
        {
            ErrorChanged.InvokeAsync(Error);
            ErrorTextChanged.InvokeAsync(ErrorText);
        }

        protected void AddLine(KeyboardEventArgs e)
        {
            if (MultiLine && e.Code == "Enter")
            {
                if (Lines == 1)
                {
                    var temp = Text;
                    Lines += 1;
                    StateHasChanged();
                    Text = temp;
                    StateHasChanged();
                }
                else
                {
                    Lines += 1;
                    StateHasChanged();
                }
            }
        }
    }
}
