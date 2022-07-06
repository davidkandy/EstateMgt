using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Components.Bases
{
    public partial class DropdownBase<T> : ComponentBase
    {
        [Parameter]
        public string Label { get; set; }

        [Parameter]
        public IEnumerable<T> ValueList { get; set; }

        [Parameter]
        public T Value { get; set; }

        [Parameter]
        public string DisplayProperty { get; set; }

        [Parameter]
        public string ValueProperty { get; set; }

        [Parameter]
        public EventCallback<T> ValueChanged { get; set; }

        [Parameter]
        public bool IsDisabled { get; set; }

        public async Task SetValue(T value)
        {
            this.Value = value;
            await ValueChanged.InvokeAsync(this.Value);
            await InvokeAsync(StateHasChanged);
        }

        //private Task OnValueChanged(ChangeEventArgs changeEventArgs)
        //{
        //    this.Value = (T)Enum.Parse(typeof(T), changeEventArgs.Value.ToString());

        //    return ValueChanged.InvokeAsync(this.Value);
        //}

        public void Disable()
        {
            this.IsDisabled = true;
            InvokeAsync(StateHasChanged);
        }

        public void Enable()
        {
            this.IsDisabled = false;
            InvokeAsync(StateHasChanged);
        }
    }
}
