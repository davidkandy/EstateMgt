using Client.Interfaces;
using Microsoft.AspNetCore.Components;
using Shared.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Components.Lists
{
    public partial class CompanyDetailList : ComponentBase
    {
        [Parameter]
        public Guid CompanyId { get; set; }

        [Inject]
        public ICompanyServiceClient HttpClient { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public IEnumerable<CompanyDetailDto> CompanyDetails { get; set; } = new List<CompanyDetailDto>();

        public CompanyDetailDto SelectedCompanyDetail { get; set; } = new CompanyDetailDto();

        protected override async Task OnInitializedAsync()
        {

            CompanyDetails = await HttpClient.GetCompanyDetails(CompanyId);
        }

        protected void Edit(int id)
        {
            NavigationManager.NavigateTo("EditCompanyDetail/" + CompanyId + "/" + id);
        }
    }
}
