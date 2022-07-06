using Microsoft.AspNetCore.Components;
using Shared.Models.DTOs;
using MudBlazor;
using Shared.Models.DTOs.Admin;
using Client.Interfaces;
using System.Globalization;

namespace Client.Components.Forms
{
    public partial class AddEditEstate : ComponentBase
    {
        [Parameter] public Guid EstateId { get; set; }
        public EstateForUpdate Estate { get; set; } = new EstateForUpdate();
        [Inject] public IEstateServiceClient Client { get; set; }
        [Inject] public ISnackbar Snackbar { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }
        [Parameter] public bool Saved { get; set; }
        [Parameter]
        public EventCallback<bool> SavedChanged { get; set; }
        public string CompanyId { get; set; }
        protected bool isEdit = false;
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime DateCompleted { get; set; } = DateTime.Now;


        public void SetEstate(EstateForUpdate estate)
        {
            Estate = estate;
            StateHasChanged();
        }

        private async Task GetEstateDetail()
        {
            isEdit = true;
            var temp = await Client.GetEstateForUpdate(EstateId);
            SetEstate(temp);
        }

        private async Task OnSubmit()
        {
            try
            {
                if (isEdit)
                {
                    await Client.UpdateEstate(EstateId, Estate);
                }
                else
                {
                    var estateForCreation = GetEstateForCreation();

                    System.Diagnostics.Debugger.Break();

                    var result = await Client.CreateEstate(estateForCreation);

                    System.Diagnostics.Debugger.Break();

                    EstateId = result.Id;
                    await GetEstateDetail();
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

        private EstateForCreation GetEstateForCreation()
        {
            return new EstateForCreation()
            {
                Name = Estate.Name,
                City = Estate.City,
                Description = Estate.Description,
                State = Estate.State,
                Status = Estate.Status,
                Size = Estate.Size,
                PostalCode = Estate.PostalCode,
                Geolocation = Estate.Geolocation
                //StartDate = Estate.StartDate,
                //DateCompleted = Estate.DateCompleted,
            };
        }
    }
}
