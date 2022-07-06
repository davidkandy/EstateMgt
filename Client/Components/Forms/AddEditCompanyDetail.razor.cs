using Microsoft.AspNetCore.Components;
using Shared.Models.DTOs;
using MudBlazor;
using System;
using System.Threading.Tasks;
using Client.Interfaces;

namespace Client.Components.Forms
{
    public partial class AddEditCompanyDetail : ComponentBase
    {
        [Parameter]
        public Guid CompanyId { get; set; }

        [Parameter]
        public int CompanyDetailId { get; set; } = 0;

        public CompanyDetailForUpdate CompanyDetail { get; set; } = new CompanyDetailForUpdate();

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

        public void SetCompanyDetail(CompanyDetailForUpdate companyDetail)
        {
            CompanyDetail = companyDetail;
            StateHasChanged();
        }

        protected override async void OnInitialized()
        {
            if (CompanyDetailId == 0)
            {
                isEdit = false;
            }
            else
            {
                await GetCompanyDetail();
            }
        }

        private async Task GetCompanyDetail()
        {
            isEdit = true;
            var temp = await Client.GetCompanyDetailForUpdate(CompanyId, CompanyDetailId);
            SetCompanyDetail(temp);
        }

        private async Task OnSubmit()
        {
            try
            {
                if (isEdit)
                {
                    await Client.UpdateCompanyDetail(CompanyId, CompanyDetailId, CompanyDetail);
                }
                else
                {
                    var companyDetailForCreation = GetCompanyDetailForCreation();
                    var result = await Client.CreateCompanyDetail(CompanyId, companyDetailForCreation);
                    CompanyDetailId = result.Id;
                    await GetCompanyDetail();
                }
                Snackbar.Add("Record Saved!", Severity.Success);
                await SavedChanged.InvokeAsync(true);
            }
            catch (Exception ex)
            {
                Snackbar.Add("Error Saving Record!  " + ex.Message, Severity.Error);
                await SavedChanged.InvokeAsync(false);
            }
            // Toast Notification
            StateHasChanged();
        }

        private CompanyDetailForCreation GetCompanyDetailForCreation()
        {
            return new CompanyDetailForCreation()
            {
                CompanyId = CompanyId,
                Name = CompanyDetail.Name,
                Description = CompanyDetail.Description,
                Summary = CompanyDetail.Summary
            };
        }
    }
}
