using Microsoft.AspNetCore.Components;
using Client.Interfaces;
using Client.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using Shared.Models.DTOs;

namespace Client.Pages.Company
{
    public partial class NewCompany : ComponentBase
    {
        [Parameter]
        public Guid CompanyId { get; set; }

        public CompanyForCreation Company { get; set; }

        [Inject]
        public ICompanyServiceClient Client { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected bool isEdit = true;

        public void SetCompany(CompanyForCreation company)
        {
            Company = company;
            StateHasChanged();
        }

        protected override void OnInitialized()
        {
            
        }
    }
}
