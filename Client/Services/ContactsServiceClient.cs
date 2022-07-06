using Microsoft.Extensions.Configuration;
using Client.Interfaces;
using Shared.Models.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Client.Services
{
    public class ContactsServiceClient : IContactsServiceClient
    {
        private readonly HttpClient _client;

        public ContactsServiceClient(HttpClient client, IConfiguration configuration)
        {
            _client = client;
            _client.BaseAddress = new Uri(configuration["ContactsServiceUrl"]);
            _client.Timeout = new TimeSpan(0, 0, 30);
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        // Organization

        public async Task<IEnumerable<OrganizationDto>> GetOrganizations()
        {
            var result = await _client.GetAsync("api/organizations");

            if (!result.IsSuccessStatusCode)
                return null;
            var content = await result.Content.ReadAsStringAsync();
            var organizations = JsonConvert.DeserializeObject<IEnumerable<OrganizationDto>>(content);
            return organizations;
        }

        public async Task<IEnumerable<OrganizationLookupDto>> GetOrganizationsLookup()
        {
            var result = await _client.GetAsync("api/organizations/lookup");

            if (!result.IsSuccessStatusCode)
                return null;
            var content = await result.Content.ReadAsStringAsync();
            var organizations = JsonConvert.DeserializeObject<IEnumerable<OrganizationLookupDto>>(content);
            return organizations;
        }

        public async Task<OrganizationDto> GetOrganization(Guid id)
        {
            var result = await _client.GetAsync("api/organizations/" + id);

            if (!result.IsSuccessStatusCode)
                return null;
            var content = await result.Content.ReadAsStringAsync();
            var organization = JsonConvert.DeserializeObject<OrganizationDto>(content);
            return organization;
        }

        public async Task<OrganizationForUpdate> GetOrganizationForUpdate(Guid id)
        {
            var result = await _client.GetAsync("api/organizations/" + id);

            if (!result.IsSuccessStatusCode)
                return null;
            var content = await result.Content.ReadAsStringAsync();
            var organization = JsonConvert.DeserializeObject<OrganizationForUpdate>(content);
            return organization;
        }

        public async Task<OrganizationDto> CreateOrganization(OrganizationForCreation organization)
        {
            var organizationToCreate = JsonConvert.SerializeObject(organization);
            var request = new HttpRequestMessage(HttpMethod.Post, "api/organizations")
            {
                Content = new StringContent(organizationToCreate)
            };
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var createdOrganization = JsonConvert.DeserializeObject<OrganizationDto>(content);
            return createdOrganization;
        }

        public async Task<OrganizationDto> UpdateOrganization(Guid id, OrganizationForUpdate organization)
        {
            var organizationToUpdate = JsonConvert.SerializeObject(organization);
            var request = new HttpRequestMessage(HttpMethod.Put, "api/organizations/" + id)
            {
                Content = new StringContent(organizationToUpdate)
            };
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var updatedOrganization = JsonConvert.DeserializeObject<OrganizationDto>(content);
            return updatedOrganization;
        }

        public async Task DeleteOrganization(Guid id)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, "api/organizations/" + id);

            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();
        }

        // Contact


        public async Task<IEnumerable<ContactDto>> GetContacts()
        {
            var result = await _client.GetAsync("api/contacts");

            if (!result.IsSuccessStatusCode)
                return null;
            var content = await result.Content.ReadAsStringAsync();
            var contacts = JsonConvert.DeserializeObject<IEnumerable<ContactDto>>(content);
            return contacts;
        }

        public async Task<IEnumerable<ContactOrOrganizationDto>> GetContactsAndOrganizations()
        {
            var result = await _client.GetAsync("api/contacts/contactsandorganizations");

            if (!result.IsSuccessStatusCode)
                return null;
            var content = await result.Content.ReadAsStringAsync();
            var contacts = JsonConvert.DeserializeObject<IEnumerable<ContactOrOrganizationDto>>(content);
            return contacts;
        }

        public async Task<ContactDto> GetContact(Guid id)
        {
            var result = await _client.GetAsync("api/contacts/" + id);

            if (!result.IsSuccessStatusCode)
                return null;
            var content = await result.Content.ReadAsStringAsync();
            var contact = JsonConvert.DeserializeObject<ContactDto>(content);
            return contact;
        }

        public async Task<ContactForUpdate> GetContactForUpdate(Guid id)
        {
            var result = await _client.GetAsync("api/contacts/forupdate/" + id);

            if (!result.IsSuccessStatusCode)
                return null;
            var content = await result.Content.ReadAsStringAsync();
            var contact = JsonConvert.DeserializeObject<ContactForUpdate>(content);

            return contact;
        }

        public async Task<ContactDto> CreateContact(ContactForCreation contact)
        {
            var activityToCreate = JsonConvert.SerializeObject(contact);
            var request = new HttpRequestMessage(HttpMethod.Post, "api/contacts")
            {
                Content = new StringContent(activityToCreate)
            };
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var createdContact = JsonConvert.DeserializeObject<ContactDto>(content);
            return createdContact;
        }

        public async Task<ContactDto> UpdateContact(Guid id, ContactForUpdate contact)
        {
            var contactToUpdate = JsonConvert.SerializeObject(contact);
            var request = new HttpRequestMessage(HttpMethod.Put, "api/contacts/" + id)
            {
                Content = new StringContent(contactToUpdate)
            };
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var updatedContact = JsonConvert.DeserializeObject<ContactDto>(content);
            return updatedContact;
        }

        public async Task DeleteContact(Guid id)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, "api/contacts/" + id);

            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();
        }
    }
}
