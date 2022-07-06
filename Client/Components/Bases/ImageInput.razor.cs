using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Components.Bases
{
    public partial class ImageInput : ComponentBase
    {
        [Parameter]
        public string Label { get; set; }

        [Parameter]
        public string Image { get; set; }

        [Parameter]
        public string Style { get; set; }

        [Parameter]
        public EventCallback<string> ImageChanged { get; set; }

        protected void OnChanged(string value)
        {
            ImageChanged.InvokeAsync(value);
        }
    }
}
