using Microsoft.AspNetCore.Components;
using Shared.Models.DTOs;
using MudBlazor;
using System;
using System.Linq;
using System.Threading.Tasks;
using Client.Interfaces;

namespace Client.Components.Forms
{
    public partial class AddEditJob : ComponentBase
    {
        [Parameter]
        public int JobId { get; set; } = 0;

        public JobForUpdate Job { get; set; } = new JobForUpdate();

        [Inject]
        public ICompanyServiceClient Client { get; set; }

        [Inject]
        public ISnackbar Snackbar {  get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public bool Saved { get; set; }

        [Parameter]
        public EventCallback<bool> SavedChanged { get; set; }

        protected bool isEdit = false;

        public void SetJob(JobForUpdate job)
        {
            Job = job;
            StateHasChanged();
        }

        protected override async void OnInitialized()
        {
            if (JobId == 0)
            {
                isEdit = false;
            }
            else
            {
                await GetJob();
            }
        }

        private async Task GetJob()
        {
            isEdit = true;
            var temp = await Client.GetJobForUpdate(JobId);
            SetJob(temp);
        }

        private async Task OnSubmit()
        {
            try
            {
                if (isEdit)
                {
                    await Client.UpdateJob(JobId, Job);
                }
                else
                {
                    var jobForCreation = GetJobForCreation();
                    var result = await Client.CreateJob(jobForCreation);
                    JobId = result.Id;
                    await GetJob();
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

        private JobForCreation GetJobForCreation()
        {
            return new JobForCreation()
            {
                JobTitle = Job.JobTitle,
                JobDescription = Job.JobDescription,
                Responsibilities = Job.Responsibilities
            };
        }
    }
}
