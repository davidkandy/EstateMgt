using Microsoft.AspNetCore.Components;
using Shared.Models.DTOs;
using MudBlazor;
using System;
using System.Linq;
using System.Threading.Tasks;
using Client.Interfaces;

namespace Client.Components.Forms
{
    public partial class AddEditCompany : ComponentBase
    {
        [Parameter]
        public Guid CompanyId { get; set; } = Guid.Empty;

        public CompanyForUpdate Company { get; set; } = new CompanyForUpdate();

        [Inject]
        public ICompanyServiceClient Client { get; set; }

        [Inject]
        public ISnackbar Snackbar { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public bool Saved { get; set; }

        [Parameter]
        public EventCallback<bool> SavedChanged { get; set; }

        protected bool isEdit = false;

        public void SetCompany(CompanyForUpdate company)
        {
            Company = company;
            StateHasChanged();
        }

        protected override async void OnInitialized()
        {
            if (CompanyId == Guid.Empty)
            {
                isEdit = false;
            }
            else
            {
                await GetCompany();
            }
        }

        private async Task GetCompany()
        {
            isEdit = true;
            var temp = await Client.GetCompanyForUpdate(CompanyId);
            SetCompany(temp);
        }

        private async Task OnSubmit()
        {
            try
            {
                if (isEdit)
                {
                    await Client.UpdateCompany(CompanyId, Company);
                }
                else
                {
                    var companyForCreation = GetCompanyForCreation();
                    var result = await Client.CreateCompany(companyForCreation);
                    CompanyId = result.Id;
                    await GetCompany();
                }
                Snackbar.Add("Record Saved!", Severity.Success);
                await SavedChanged.InvokeAsync(true);
            }
            catch (Exception ex)
            {
                Snackbar.Add("Error Saving Record! /br" + ex.Message, Severity.Error);
                await SavedChanged.InvokeAsync(false);
            }
            StateHasChanged();
        }

        private CompanyForCreation GetCompanyForCreation()
        {
            return new CompanyForCreation()
            {
                Name = Company.Name,
                Description = Company.Description,
                Email = Company.Email,
                Phone1 = Company.Phone1,
                Phone2 = Company.Phone2,
                Street = Company.Street,
                City = Company.City,
                PostalCode = Company.PostalCode,
                State = Company.State,
                Country = Company.Country,
                Website = Company.Website
            };
        }
    }
}
