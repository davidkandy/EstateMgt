using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Components.Bases
{
    public partial class DatePickerBase : ComponentBase
    {
        [Parameter]
        public string Label { get; set; }
        [Parameter]
        public DateTime? DateValue { get; set; }
        [Parameter]
        public string Format { get; set; }
        [Parameter]
        public bool Required { get; set; } = false;
        [Parameter]
        public string RequiredError { get; set; }
        [Parameter]
        public bool Error { get; set; } = false;
        [Parameter]
        public string ErrorText { get; set; }
        [Parameter]
        public EventCallback<DateTime?> DateValueChanged { get; set; }



        private Task OnDateValueChanged(DateTime? value)
        {
            this.DateValue = value;

            return DateValueChanged.InvokeAsync(this.DateValue);
        }
    }
}
