using Shared.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Client.Interfaces
{
    public interface ICompanyServiceClient
    {
        Task<IEnumerable<CompanyDto>> GetCompanies();
        Task<CompanyDto> GetCompany(Guid id);
        Task<CompanyForUpdate> GetCompanyForUpdate(Guid id);
        Task<CompanyDto> CreateCompany(CompanyForCreation company);
        Task<CompanyDto> UpdateCompany(Guid id, CompanyForUpdate company);
        Task DeleteCompany(Guid id);

        Task<IEnumerable<CompanyDetailDto>> GetCompanyDetails(Guid companyId);
        Task<CompanyDetailDto> GetCompanyDetail(Guid companyId, int id);
        Task<CompanyDetailForUpdate> GetCompanyDetailForUpdate(Guid companyId, int id);
        Task<CompanyDetailDto> CreateCompanyDetail(Guid companyId, CompanyDetailForCreation companyDetail);
        Task<CompanyDetailDto> UpdateCompanyDetail(Guid companyId, int id, CompanyDetailForUpdate companyDetail);
        Task DeleteCompanyDetail(Guid companyId, int id);

        Task<IEnumerable<EmployeeDto>> GetEmployees();
        Task<IEnumerable<EmployeeFullDto>> GetFullEmployees();
        Task<IEnumerable<EmployeeWithPhotoDto>> GetEmployeesWithPhoto();
        Task<IEnumerable<EmployeeLookupDto>> GetEmployeesLookup();
        Task<EmployeeDto> GetEmployee(Guid id);
        Task<EmployeeFullDto> GetFullEmployee(Guid id);
        Task<EmployeeWithPhotoDto> GetEmployeeWithPhoto(Guid id);
        Task<EmployeeForUpdate> GetEmployeeForUpdate(Guid id);
        Task<EmployeeDto> CreateEmployee(EmployeeForCreation employee);
        Task<EmployeeDto> UpdateEmployee(Guid id, EmployeeForUpdate employee);
        Task DeleteEmployee(Guid id);
        
        Task<IEnumerable<DepartmentDto>> GetDepartments();
        Task<DepartmentDto> GetDepartment(int id);
        Task<DepartmentForUpdate> GetDepartmentForUpdate(int id);
        Task<DepartmentDto> CreateDepartment(DepartmentForCreation department);
        Task<DepartmentDto> UpdateDepartment(int id, DepartmentForUpdate department);
        Task DeleteDepartment(int id);

        Task<IEnumerable<JobDto>> GetJobs();
        Task<JobDto> GetJob(int id);
        Task<JobForUpdate> GetJobForUpdate(int id);
        Task<JobDto> CreateJob(JobForCreation job);
        Task<JobDto> UpdateJob(int id, JobForUpdate job);
        Task DeleteJob(int id);
    }
}