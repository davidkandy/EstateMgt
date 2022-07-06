using System.Net.Http.Headers;
using Client.Interfaces;
using Client.Static;
using MudBlazor;
using Newtonsoft.Json;
using Shared.Models.DTOs.Admin;

namespace Client.Services
{
    public class EstateServiceClient : IEstateServiceClient
    {
        private readonly HttpClient _client;

        public EstateServiceClient(HttpClient client)
        {
            _client = client;
            _client.BaseAddress = new Uri(APIEndpoints.ServerBaseUrl);
            _client.Timeout = new TimeSpan(0, 0, 30);
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }


        public async Task<IEnumerable<EstateDto>> GetEstates()
        {
            var result = await _client.GetAsync("api/estates");

            if (!result.IsSuccessStatusCode) return null;

            var content = await result.Content.ReadAsStringAsync();
            var estates = JsonConvert.DeserializeObject<IEnumerable<EstateDto>>(content);
            return estates;
        }

        public async Task<EstateDto> GetEstate(Guid id)
        {
            var result = await _client.GetAsync("api/estates/" + id);

            if (!result.IsSuccessStatusCode) return null;

            var content = await result.Content.ReadAsStringAsync();
            var estate = JsonConvert.DeserializeObject<EstateDto>(content);
            return estate;
        }

        public async Task<EstateForUpdate> GetEstateForUpdate(Guid id)
        {
            var result = await _client.GetAsync("api/estates/" + id);

            if (!result.IsSuccessStatusCode) return null;

            var content = await result.Content.ReadAsStringAsync();
            var estate = JsonConvert.DeserializeObject<EstateForUpdate>(content);
            return estate;
        }

        public async Task<EstateDto> CreateEstate(EstateForCreation estate)
        {
            var estateToCreate = JsonConvert.SerializeObject(estate);
            var request = new HttpRequestMessage(HttpMethod.Post, "api/estates")
            {
                Content = new StringContent(estateToCreate)
            };
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var createdEstate = JsonConvert.DeserializeObject<EstateDto>(content);
            return createdEstate;
        }

        public async Task<EstateDto> UpdateEstate(Guid id, EstateForUpdate estate)
        {
            var estateToUpdate = JsonConvert.SerializeObject(estate);
            var request = new HttpRequestMessage(HttpMethod.Put, "api/estates/" + id)
            {
                Content = new StringContent(estateToUpdate)
            };
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var updatedEstate = JsonConvert.DeserializeObject<EstateDto>(content);
            return updatedEstate;
        }

        public async Task DeleteEstate(Guid id)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, "api/estates/" + id);

            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();
        }

        public async Task<IEnumerable<HousingBlockDto>> GetHousingBlocks()
        {
            var result = await _client.GetAsync("api/housingblocks");

            if (!result.IsSuccessStatusCode) return null;

            var content = await result.Content.ReadAsStringAsync();
            var housingBlocks = JsonConvert.DeserializeObject<IEnumerable<HousingBlockDto>>(content);
            return housingBlocks;
        }

        public async Task<HousingBlockDto> GetHousingBlock(Guid id)
        {
            var result = await _client.GetAsync("api/housingblocks/" + id);

            if (!result.IsSuccessStatusCode) return null;

            var content = await result.Content.ReadAsStringAsync();
            var housingBlock = JsonConvert.DeserializeObject<HousingBlockDto>(content);
            return housingBlock;
        }

        public async Task<HousingBlockForUpdate> GetHousingBlockForUpdate(Guid id)
        {
            var result = await _client.GetAsync("api/housingblocks/" + id);

            if (!result.IsSuccessStatusCode) return null;

            var content = await result.Content.ReadAsStringAsync();
            var housingBlock = JsonConvert.DeserializeObject<HousingBlockForUpdate>(content);
            return housingBlock;
        }

        public async Task<HousingBlockDto> CreateHousingBlock(HousingBlockForCreation housingBlock)
        {
            var housingBlockToCreate = JsonConvert.SerializeObject(housingBlock);
            var request = new HttpRequestMessage(HttpMethod.Post, "api/housingblocks")
            {
                Content = new StringContent(housingBlockToCreate)
            };
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var createdHousingBlock = JsonConvert.DeserializeObject<HousingBlockDto>(content);
            return createdHousingBlock;
        }

        public async Task<HousingBlockDto> UpdateHousingBlock(Guid id, HousingBlockForUpdate housingBlock)
        {
            var housingBlockToUpdate = JsonConvert.SerializeObject(housingBlock);
            var request = new HttpRequestMessage(HttpMethod.Put, "api/housingblocks/" + id)
            {
                Content = new StringContent(housingBlockToUpdate)
            };
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var updatedHousingBlock = JsonConvert.DeserializeObject<HousingBlockDto>(content);
            return updatedHousingBlock;
        }

        public async Task DeleteHousingBlock(Guid id)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, "api/housingblocks/" + id);

            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();
        }

        public async Task<IEnumerable<HousingTypeDto>> GetHousingTypes()
        {
            var result = await _client.GetAsync("api/housingtypes");

            if (!result.IsSuccessStatusCode)
                return null;
            var content = await result.Content.ReadAsStringAsync();
            var housingTypes = JsonConvert.DeserializeObject<IEnumerable<HousingTypeDto>>(content);
            return housingTypes;
        }

        public async Task<HousingTypeDto> GetHouseType(Guid id)
        {
            var result = await _client.GetAsync("api/housingtypes/" + id);

            if (!result.IsSuccessStatusCode)
                return null;
            var content = await result.Content.ReadAsStringAsync();
            var housingType = JsonConvert.DeserializeObject<HousingTypeDto>(content);
            return housingType;
        }

        public async Task<HousingTypeForUpdate> GetHousingTypeForUpdate(Guid id)
        {
            var result = await _client.GetAsync("api/housingtypes/" + id);

            if (!result.IsSuccessStatusCode)
                return null;
            var content = await result.Content.ReadAsStringAsync();
            var housingType = JsonConvert.DeserializeObject<HousingTypeForUpdate>(content);
            return housingType;
        }

        public async Task<HousingTypeDto> CreateHousingType(HousingTypeForCreation housingType)
        {
            var housingTypeToCreate = JsonConvert.SerializeObject(housingType);
            var request = new HttpRequestMessage(HttpMethod.Post, "api/housingtypes")
            {
                Content = new StringContent(housingTypeToCreate)
            };
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var updatedHousingType = JsonConvert.DeserializeObject<HousingTypeDto>(content);
            return updatedHousingType;
        }

        public async Task<HousingTypeDto> UpdateHousingType(Guid id, HousingTypeForUpdate housingType)
        {
            var housingTypeToUpdate = JsonConvert.SerializeObject(housingType);
            var request = new HttpRequestMessage(HttpMethod.Put, "api/housingtypes/" + id)
            {
                Content = new StringContent(housingTypeToUpdate)
            };
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var updatedHousingType = JsonConvert.DeserializeObject<HousingTypeDto>(content);
            return updatedHousingType;
        }

        public async Task DeleteHousingType(Guid id)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, "api/housingTypes/" + id);

            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();
        }

        public async Task<IEnumerable<HousingUnitDto>> GetHousingUnits()
        {
            var result = await _client.GetAsync("api/housingunits");

            if (!result.IsSuccessStatusCode)
                return null;
            var content = await result.Content.ReadAsStringAsync();
            var housingUnits = JsonConvert.DeserializeObject<IEnumerable<HousingUnitDto>>(content);
            return housingUnits;
        }

        public async Task<HousingUnitDto> GetHousingUnit(Guid id)
        {
            var result = await _client.GetAsync("api/housingunits/" + id);

            if (!result.IsSuccessStatusCode)
                return null;
            var content = await result.Content.ReadAsStringAsync();
            var housingUnit = JsonConvert.DeserializeObject<HousingUnitDto>(content);
            return housingUnit;
        }

        public async Task<HousingUnitForUpdate> GetHousingUnitForUpdate(Guid id)
        {
            var result = await _client.GetAsync("api/housingunits/" + id);

            if (!result.IsSuccessStatusCode) return null;

            var content = await result.Content.ReadAsStringAsync();
            var housingUnit = JsonConvert.DeserializeObject<HousingUnitForUpdate>(content);
            return housingUnit;
        }

        public async Task<HousingUnitDto> CreateHousingUnit(HousingUnitForCreation housingUnit)
        {
            var housingUnitToCreate = JsonConvert.SerializeObject(housingUnit);
            var request = new HttpRequestMessage(HttpMethod.Post, "api/housingunits")
            {
                Content = new StringContent(housingUnitToCreate)
            };
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var createdHousingUnit = JsonConvert.DeserializeObject<HousingUnitDto>(content);
            return createdHousingUnit;
        }

        public async Task<HousingUnitDto> UpdateHousingUnit(Guid id, HousingUnitForUpdate housingUnit)
        {
            var housingUnitToUpdate = JsonConvert.SerializeObject(housingUnit);
            var request = new HttpRequestMessage(HttpMethod.Put, "api/housingunits/" + id)
            {
                Content = new StringContent(housingUnitToUpdate)
            };
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var updatedHousingUnit = JsonConvert.DeserializeObject<HousingUnitDto>(content);
            return updatedHousingUnit;
        }

        public async Task DeleteHousingUnit(Guid id)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, "api/housingunits/" + id);

            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();
        }
    }
}
