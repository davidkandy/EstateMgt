using Client.Interfaces;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using Shared.Models.DTOs;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Components.Forms
{
    public partial class AddEditDepartment : ComponentBase
    {
        [Parameter]
        public int DepartmentId { get; set; } = 0;

        public DepartmentForUpdate Department { get; set; } = new DepartmentForUpdate();

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

        public void SetDepartment(DepartmentForUpdate department)
        {
            Department = department;
            StateHasChanged();
        }

        protected override async void OnInitialized()
        {
            if (DepartmentId == 0)
            {
                isEdit = false;
            }
            else
            {
                await GetDepartment();
            }
        }

        private async Task GetDepartment()
        {
            isEdit = true;
            var temp = await Client.GetDepartmentForUpdate(DepartmentId);
            SetDepartment(temp);
        }

        private async Task OnSubmit()
        {
            try
            {
                if (isEdit)
                {
                    await Client.UpdateDepartment(DepartmentId, Department);
                }
                else
                {
                    var departmentForCreation = GetDepartmentForCreation();
                    var result = await Client.CreateDepartment(departmentForCreation);
                    DepartmentId = result.Id;
                    await GetDepartment();
                }
                Snackbar.Add("Record Saved!", Severity.Success);
                await SavedChanged.InvokeAsync(true);
            }
            catch (Exception ex)
            {
                Snackbar.Add("Error Saving Record! /br" + ex.Message, Severity.Error);
                await SavedChanged.InvokeAsync(false);
            }
            // Toast Notification
            StateHasChanged();
        }

        private DepartmentForCreation GetDepartmentForCreation()
        {
            return new DepartmentForCreation()
            {
                Name = Department.Name,
                Description = Department.Description
            };
        }
    }
}
