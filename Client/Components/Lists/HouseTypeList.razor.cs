using Client.Interfaces;
using Microsoft.AspNetCore.Components;
using Shared.Models.DTOs;
using Shared.Models.DTOs.Admin;

namespace Client.Components.Lists
{
    public partial class HousingTypeList : ComponentBase
    {
        [Inject]
        public IEstateServiceClient HttpClient { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public IEnumerable<HousingTypeDto> HousingTypes { get; set; } = new List<HousingTypeDto>();
        //public IEnumerable<DepartmentDto> Departments { get; set; } = new List<DepartmentDto>();

        public DepartmentDto SelectedDepartment { get; set; } = new DepartmentDto();

        protected override async Task OnInitializedAsync()
        {
            HousingTypes = await HttpClient.GetHousingTypes();
        }

        protected void OnSelectDepartment(int id)
        {
            NavigationManager.NavigateTo("EditDepartment/" + id);
        }
    }
}
