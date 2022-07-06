using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Client.Components.Common
{
    public partial class PhoneInput : ComponentBase
    {
        [Parameter]
        public string Label { get; set; } = "Phone";
        [Parameter]
        public string Phone1 { get; set; }
        [Parameter]
        public string Phone2 { get; set; }
        [Parameter]
        public EventCallback<string> Phone1Changed { get; set; }
        [Parameter]
        public EventCallback<string> Phone2Changed { get; set; }
        [Parameter]
        public EventCallback<bool> Phone1ErrorChanged { get; set; }
        [Parameter]
        public EventCallback<string> Phone1ErrorTextChanged { get; set; }
        [Parameter]
        public EventCallback<bool> Phone2ErrorChanged { get; set; }
        [Parameter]
        public EventCallback<string> Phone2ErrorTextChanged { get; set; }
        [Parameter]
        public bool Phone1Error { get; set; } = false;
        [Parameter]
        public string Phone1ErrorText { get; set; }
        [Parameter]
        public bool Phone2Error { get; set; } = false;
        [Parameter]
        public string Phone2ErrorText { get; set; }
        [Parameter]
        public Expression<Func<string>> Phone1For { get; set; }
        [Parameter]
        public Expression<Func<string>> Phone2For { get; set; }

        private void OnPhone1Changed()
        {
            if (Phone1Error)
            {
                Phone1ErrorChanged.InvokeAsync(Phone1Error);
                Phone1ErrorTextChanged.InvokeAsync(Phone1ErrorText);
            }
            Phone1Changed.InvokeAsync(Phone1);
        }

        private void OnPhone2Changed()
        {
            if (Phone2Error)
            {
                Phone2ErrorChanged.InvokeAsync(Phone2Error);
                Phone2ErrorTextChanged.InvokeAsync(Phone2ErrorText);
            }
            Phone2Changed.InvokeAsync(Phone2);
        }
    }
}
