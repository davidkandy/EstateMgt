using Shared.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Client.Interfaces
{
    public interface IContactsServiceClient
    {
        Task<IEnumerable<OrganizationDto>> GetOrganizations();
        Task<IEnumerable<OrganizationLookupDto>> GetOrganizationsLookup();
        Task<OrganizationDto> GetOrganization(Guid id);
        Task<OrganizationForUpdate> GetOrganizationForUpdate(Guid id);
        Task<OrganizationDto> CreateOrganization(OrganizationForCreation organization);
        Task<OrganizationDto> UpdateOrganization(Guid id, OrganizationForUpdate organization);
        Task DeleteOrganization(Guid id);

        Task<IEnumerable<ContactDto>> GetContacts();
        Task<IEnumerable<ContactOrOrganizationDto>> GetContactsAndOrganizations();
        Task<ContactDto> GetContact(Guid id);
        Task<ContactForUpdate> GetContactForUpdate(Guid id);
        Task<ContactDto> CreateContact(ContactForCreation contact);
        Task<ContactDto> UpdateContact(Guid id, ContactForUpdate contact);
        Task DeleteContact(Guid id);
    }
}