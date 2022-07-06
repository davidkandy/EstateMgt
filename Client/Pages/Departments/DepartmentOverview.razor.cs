using Microsoft.AspNetCore.Components;
using Client.Interfaces;
using Client.Models;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.Models.DTOs;

namespace Client.Pages.Departments
{
    public partial class DepartmentOverview : ComponentBase
    {
        [Inject]
        public ICompanyServiceClient HttpClient { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public IEnumerable<DepartmentDto> Departments { get; set; } = new List<DepartmentDto>();

        //public DepartmentDto SelectedDepartment { get; set; } = new DepartmentDto();

        protected override async Task OnInitializedAsync()
        {

            Departments = await HttpClient.GetDepartments();
        }

        protected void OnSelectDepartment(int id)
        {
            NavigationManager.NavigateTo("EditDepartment/" + id);
        }
    }
}
