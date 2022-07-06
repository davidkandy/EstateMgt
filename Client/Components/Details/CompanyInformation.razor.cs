using Client.Interfaces;
using Microsoft.AspNetCore.Components;
using Shared.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Components.Details
{
    public partial class CompanyInformation : ComponentBase
    {
        //[Parameter]
        //public Guid CompanyId {  get; set; }

        public CompanyDto Company { get; set; } = new CompanyDto();

        public IEnumerable<CompanyDetailDto> CompanyDetails { get; set; } = new HashSet<CompanyDetailDto>();

        [Inject]
        public ICompanyServiceClient Client { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected bool HasCompanyDetails => CompanyDetails != null && CompanyDetails.Any();

        protected override async Task OnInitializedAsync()
        {
            await GetCompany();
        }

        private async Task GetCompany()
        {
            var result = await Client.GetCompanies();
            Company = result.FirstOrDefault();
            CompanyDetails = await Client.GetCompanyDetails(Company.Id);
            StateHasChanged();
        }

        protected void EditCompany()
        {
            if (Company != null && Company.Id != Guid.Empty)
                NavigationManager.NavigateTo("EditCompany/" + Company.Id);
        }
    }
}
