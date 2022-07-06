using Client.Interfaces;
using Microsoft.AspNetCore.Components;
using Shared.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Components.Lists
{
    public partial class JobList : ComponentBase
    {
        [Inject]
        public ICompanyServiceClient HttpClient { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public IEnumerable<JobDto> Jobs { get; set; } = new List<JobDto>();

        public JobDto SelectedJob { get; set; } = new JobDto();

        protected override async Task OnInitializedAsync()
        {
            Jobs = await HttpClient.GetJobs();
        }

        protected void AddNew()
        {
            NavigationManager.NavigateTo("NewJob");
        }

        protected void Edit(int id)
        {
            NavigationManager.NavigateTo("EditJob/" + id);
        }
    }
}
