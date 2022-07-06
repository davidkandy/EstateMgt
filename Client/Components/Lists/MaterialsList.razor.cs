using Client.Interfaces;
using Microsoft.AspNetCore.Components;
using Shared.Models.DTOs;

namespace Client.Components.Lists
{
    public partial class MaterialsList : ComponentBase
    {
        [Inject]
        public ICompanyServiceClient HttpClient { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public IEnumerable<DepartmentDto> Departments { get; set; } = new List<DepartmentDto>();

        public DepartmentDto SelectedDepartment { get; set; } = new DepartmentDto();

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
