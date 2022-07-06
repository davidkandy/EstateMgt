using Microsoft.AspNetCore.Components;

namespace Client.Components.Common
{
    public partial class AddressInput : ComponentBase
    {
        [Parameter]
        public string Label { get; set; } = "Address";
        [Parameter]
        public string Street { get; set; }
        [Parameter]
        public string City { get; set; }
        [Parameter]
        public string State { get; set; }
        [Parameter]
        public string Country { get; set; }
        [Parameter]
        public string PostalCode { get; set; }
        [Parameter]
        public EventCallback<string> StreetChanged { get; set; }
        [Parameter]
        public EventCallback<string> CityChanged { get; set; }
        [Parameter]
        public EventCallback<string> PostalCodeChanged { get; set; }
        [Parameter]
        public EventCallback<string> StateChanged { get; set; }
        [Parameter]
        public EventCallback<string> CountryChanged { get; set; }

        private void OnStreetChanged()
        {
            StreetChanged.InvokeAsync(Street);
        }

        private void OnCityChanged()
        {
            CityChanged.InvokeAsync(City);
        }

        private void OnPostalCodeChanged()
        {
            PostalCodeChanged.InvokeAsync(PostalCode);
        }

        private void OnStateChanged()
        {
            StateChanged.InvokeAsync(State);
        }

        private void OnCountryChanged()
        {
            CountryChanged.InvokeAsync(Country);
        }
    }
}
