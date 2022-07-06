using Microsoft.AspNetCore.Components;
using Client.Interfaces;
using Client.Models;
using Client.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Shared.Models.DTOs;

namespace Client.Pages.Company
{
    public partial class CompanyProfile : ComponentBase
    {
        [Parameter]
        public Guid CompanyId { get; set; } = Guid.Empty;

        public CompanyDto Company { get; set; }

        [Inject]
        public ICompanyServiceClient Client { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected bool isEdit = false;

        protected override Task OnInitializedAsync()
        {
            GetCompany();
            return base.OnInitializedAsync();
        }

        private async void GetCompany()
        {
            isEdit = true;
            Company = await Client.GetCompany(CompanyId);
        }
    }
}
