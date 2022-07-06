using Microsoft.AspNetCore.Components;
using Shared.Models.DTOs;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Client.Interfaces;

namespace Client.Components.Forms
{
    public partial class AddEditEmployee : ComponentBase
    {
        [Parameter]
        public Guid EmployeeId { get; set; }

        public EmployeeForUpdate Employee { get; set; } = new EmployeeForUpdate();

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

        public string CompanyId { get; set; }
        public DateTime? DateOfEmployment { get; set; }
        public DateTime? DateOfBirth { get; set; }

        protected bool isEdit = false;

        public void SetEmployee(EmployeeForUpdate employee)
        {
            Employee = employee;
            CompanyId = employee.CompanyId.ToString();
            DateOfEmployment = DateTime.Parse(employee.DateOfEmployment.ToString());
            DateOfBirth = DateTime.Parse(employee.DateOfBirth.ToString());
    }

        protected override async void OnInitialized()
        {
            if (EmployeeId == Guid.Empty)
            {
                isEdit = false;
            }
            else
            {
                await GetEmployee();
            }
            StateHasChanged();
        }

        private async Task GetEmployee()
        {
            isEdit = true;
            var temp = await Client.GetEmployeeForUpdate(EmployeeId);
            SetEmployee(temp);

        }

        private async Task OnSubmit()
        {
            Employee.CompanyId = Guid.Parse(CompanyId);
            Employee.DateOfEmployment = DateTimeOffset.Parse(DateOfEmployment.ToString());
            Employee.DateOfBirth = DateTimeOffset.Parse(DateOfBirth.ToString());
            try
            {
                if (isEdit)
                {
                    await Client.UpdateEmployee(EmployeeId, Employee);
                }
                else
                {
                    var employeeForCreation = GetEmployeeForCreation();
                    var result = await Client.CreateEmployee(employeeForCreation);
                    EmployeeId = result.Id;
                    await GetEmployee();
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

        private EmployeeForCreation GetEmployeeForCreation()
        {
            return new EmployeeForCreation()
            {
                Title = Employee.Title,
                FirstName = Employee.FirstName,
                LastName = Employee.LastName,
                Email = Employee.Email,
                Phone1 = Employee.Phone1,
                Phone2 = Employee.Phone2,
                Street = Employee.Street,
                City = Employee.City,
                PostalCode = Employee.PostalCode,
                State = Employee.State,
                Country = Employee.Country,
                NextOfKin = Employee.NextOfKin,
                NextOfKinEmail = Employee.NextOfKinEmail,
                NextOfKinPhone1 = Employee.NextOfKinPhone1,
                NextOfKinPhone2 = Employee.NextOfKinPhone2,
                DateOfBirth = Employee.DateOfBirth,
                DateOfEmployment = Employee.DateOfEmployment,
                DepartmentId = Employee.DepartmentId,
                JobId = Employee.JobId,
                CompanyId = Employee.CompanyId
            };
        }
    }
}
