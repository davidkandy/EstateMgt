using Client.Interfaces;
using Microsoft.AspNetCore.Components;
using Shared.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Components.Lists
{
    public partial class EmployeeList : ComponentBase
    {
        [Inject]
        public ICompanyServiceClient HttpClient { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public IEnumerable<EmployeeDto> Employees { get; set; } = new List<EmployeeDto>();

        protected override async Task OnInitializedAsync()
        {
            Employees = await HttpClient.GetEmployees();
        }

        protected void OnSelectEmployee(Guid id)
        {
            NavigationManager.NavigateTo("EditEmployee/" + id);
        }
    }
}
