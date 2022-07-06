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
using Client.Static;

namespace Client.Services
{
    public class CompanyServiceClient : ICompanyServiceClient
    {
        private readonly HttpClient _client;

        public CompanyServiceClient(HttpClient client, IConfiguration configuration)
        {
            _client = client;
            _client.BaseAddress = new Uri(APIEndpoints.ServerBaseUrl);
            _client.Timeout = new TimeSpan(0, 0, 30);
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        // Company

        public async Task<IEnumerable<CompanyDto>> GetCompanies()
        {
            var result = await _client.GetAsync("api/company");

            if (!result.IsSuccessStatusCode)
                return null;
            var content = await result.Content.ReadAsStringAsync();
            var companies = JsonConvert.DeserializeObject<IEnumerable<CompanyDto>>(content);
            return companies;
        }

        public async Task<CompanyDto> GetCompany(Guid id)
        {
            var result = await _client.GetAsync("api/company/" + id);

            if (!result.IsSuccessStatusCode)
                return null;
            var content = await result.Content.ReadAsStringAsync();
            var company = JsonConvert.DeserializeObject<CompanyDto>(content);
            return company;
        }

        public async Task<CompanyForUpdate> GetCompanyForUpdate(Guid id)
        {
            var result = await _client.GetAsync("api/company/" + id);

            if (!result.IsSuccessStatusCode)
                return null;
            var content = await result.Content.ReadAsStringAsync();
            var company = JsonConvert.DeserializeObject<CompanyForUpdate>(content);
            return company;
        }

        public async Task<CompanyDto> CreateCompany(CompanyForCreation company)
        {
            var companyToCreate = JsonConvert.SerializeObject(company);
            var request = new HttpRequestMessage(HttpMethod.Post, "api/company")
            {
                Content = new StringContent(companyToCreate)
            };
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var createdCompany = JsonConvert.DeserializeObject<CompanyDto>(content);
            return createdCompany;
        }

        public async Task<CompanyDto> UpdateCompany(Guid id, CompanyForUpdate company)
        {
            var companyToUpdate = JsonConvert.SerializeObject(company);
            var request = new HttpRequestMessage(HttpMethod.Put, "api/company/" + id)
            {
                Content = new StringContent(companyToUpdate)
            };
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var updatedCompany = JsonConvert.DeserializeObject<CompanyDto>(content);
            return updatedCompany;
        }

        public async Task DeleteCompany(Guid id)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, "api/company/" + id);

            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();
        }

        // Departments

        public async Task<IEnumerable<DepartmentDto>> GetDepartments()
        {
            var result = await _client.GetAsync("api/departments");

            if (!result.IsSuccessStatusCode)
                return null;
            var content = await result.Content.ReadAsStringAsync();
            var departments = JsonConvert.DeserializeObject<IEnumerable<DepartmentDto>>(content);
            return departments;
        }

        public async Task<DepartmentDto> GetDepartment(int id)
        {
            var result = await _client.GetAsync("api/departments/" + id);

            if (!result.IsSuccessStatusCode)
                return null;
            var content = await result.Content.ReadAsStringAsync();
            var department = JsonConvert.DeserializeObject<DepartmentDto>(content);
            return department;
        }

        public async Task<DepartmentForUpdate> GetDepartmentForUpdate(int id)
        {
            var result = await _client.GetAsync("api/departments/" + id);

            if (!result.IsSuccessStatusCode)
                return null;
            var content = await result.Content.ReadAsStringAsync();
            var department = JsonConvert.DeserializeObject<DepartmentForUpdate>(content);
            return department;
        }

        public async Task<DepartmentDto> CreateDepartment(DepartmentForCreation department)
        {
            var departmentToCreate = JsonConvert.SerializeObject(department);
            var request = new HttpRequestMessage(HttpMethod.Post, "api/departments")
            {
                Content = new StringContent(departmentToCreate)
            };
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var createdDepartment = JsonConvert.DeserializeObject<DepartmentDto>(content);
            return createdDepartment;
        }

        public async Task<DepartmentDto> UpdateDepartment(int id, DepartmentForUpdate department)
        {
            var departmentToUpdate = JsonConvert.SerializeObject(department);
            var request = new HttpRequestMessage(HttpMethod.Put, "api/departments/" + id)
            {
                Content = new StringContent(departmentToUpdate)
            };
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var updatedDepartment = JsonConvert.DeserializeObject<DepartmentDto>(content);
            return updatedDepartment;
        }

        public async Task DeleteDepartment(int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, "api/departments/" + id);

            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();
        }


        // Jobs


        public async Task<IEnumerable<JobDto>> GetJobs()
        {
            var result = await _client.GetAsync("api/jobs");

            if (!result.IsSuccessStatusCode)
                return null;
            var content = await result.Content.ReadAsStringAsync();
            var jobs = JsonConvert.DeserializeObject<IEnumerable<JobDto>>(content);
            return jobs;
        }

        public async Task<JobDto> GetJob(int id)
        {
            var result = await _client.GetAsync("api/jobs/" + id);

            if (!result.IsSuccessStatusCode)
                return null;
            var content = await result.Content.ReadAsStringAsync();
            var job = JsonConvert.DeserializeObject<JobDto>(content);
            return job;
        }

        public async Task<JobForUpdate> GetJobForUpdate(int id)
        {
            var result = await _client.GetAsync("api/jobs/" + id);

            if (!result.IsSuccessStatusCode)
                return null;
            var content = await result.Content.ReadAsStringAsync();
            var job = JsonConvert.DeserializeObject<JobForUpdate>(content);
            return job;
        }

        public async Task<JobDto> CreateJob(JobForCreation job)
        {
            var jobToCreate = JsonConvert.SerializeObject(job);
            var request = new HttpRequestMessage(HttpMethod.Post, "api/jobs")
            {
                Content = new StringContent(jobToCreate)
            };
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var createdNote = JsonConvert.DeserializeObject<JobDto>(content);
            return createdNote;
        }

        public async Task<JobDto> UpdateJob(int id, JobForUpdate job)
        {
            var jobToUpdate = JsonConvert.SerializeObject(job);
            var request = new HttpRequestMessage(HttpMethod.Put, "api/jobs/" + id)
            {
                Content = new StringContent(jobToUpdate)
            };
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var updatedNote = JsonConvert.DeserializeObject<JobDto>(content);
            return updatedNote;
        }

        public async Task DeleteJob(int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, "api/jobs/" + id);

            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();
        }


        // Employee


        public async Task<IEnumerable<EmployeeDto>> GetEmployees()
        {
            var result = await _client.GetAsync("api/employees");

            if (!result.IsSuccessStatusCode)
                return null;
            var content = await result.Content.ReadAsStringAsync();
            var employees = JsonConvert.DeserializeObject<IEnumerable<EmployeeDto>>(content);
            return employees;
        }

        public async Task<IEnumerable<EmployeeLookupDto>> GetEmployeesLookup()
        {
            var result = await _client.GetAsync("api/employees/lookup");

            if (!result.IsSuccessStatusCode)
                return null;
            var content = await result.Content.ReadAsStringAsync();
            var employees = JsonConvert.DeserializeObject<IEnumerable<EmployeeLookupDto>>(content);
            return employees;
        }

        public async Task<IEnumerable<EmployeeWithPhotoDto>> GetEmployeesWithPhoto()
        {
            var result = await _client.GetAsync("api/employees/withphoto");

            if (!result.IsSuccessStatusCode)
                return null;
            var content = await result.Content.ReadAsStringAsync();
            var employees = JsonConvert.DeserializeObject<IEnumerable<EmployeeWithPhotoDto>>(content);
            return employees;
        }

        public async Task<IEnumerable<EmployeeFullDto>> GetFullEmployees()
        {
            var result = await _client.GetAsync("api/employees/full");

            if (!result.IsSuccessStatusCode)
                return null;
            var content = await result.Content.ReadAsStringAsync();
            var employees = JsonConvert.DeserializeObject<IEnumerable<EmployeeFullDto>>(content);
            return employees;
        }

        public async Task<EmployeeDto> GetEmployee(Guid id)
        {
            var result = await _client.GetAsync("api/employees/" + id);

            if (!result.IsSuccessStatusCode)
                return null;
            var content = await result.Content.ReadAsStringAsync();
            var employee = JsonConvert.DeserializeObject<EmployeeDto>(content);
            return employee;
        }

        public async Task<EmployeeWithPhotoDto> GetEmployeeWithPhoto(Guid id)
        {
            var result = await _client.GetAsync("api/employees/withphoto/" + id);

            if (!result.IsSuccessStatusCode)
                return null;
            var content = await result.Content.ReadAsStringAsync();
            var employee = JsonConvert.DeserializeObject<EmployeeWithPhotoDto>(content);
            return employee;
        }

        public async Task<EmployeeFullDto> GetFullEmployee(Guid id)
        {
            var result = await _client.GetAsync("api/employees/full/" + id);

            if (!result.IsSuccessStatusCode)
                return null;
            var content = await result.Content.ReadAsStringAsync();
            var employee = JsonConvert.DeserializeObject<EmployeeFullDto>(content);
            return employee;
        }

        public async Task<EmployeeForUpdate> GetEmployeeForUpdate(Guid id)
        {
            var result = await _client.GetAsync("api/employees/forupdate/" + id);

            if (!result.IsSuccessStatusCode)
                return null;
            var content = await result.Content.ReadAsStringAsync();
            var employee = JsonConvert.DeserializeObject<EmployeeForUpdate>(content);

            return employee;
        }

        public async Task<EmployeeDto> CreateEmployee(EmployeeForCreation employee)
        {
            var activityToCreate = JsonConvert.SerializeObject(employee);
            var request = new HttpRequestMessage(HttpMethod.Post, "api/employees")
            {
                Content = new StringContent(activityToCreate)
            };
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var createdEmployee = JsonConvert.DeserializeObject<EmployeeDto>(content);
            return createdEmployee;
        }

        public async Task<EmployeeDto> UpdateEmployee(Guid id, EmployeeForUpdate employee)
        {
            var employeeToUpdate = JsonConvert.SerializeObject(employee);
            var request = new HttpRequestMessage(HttpMethod.Put, "api/employees/" + id)
            {
                Content = new StringContent(employeeToUpdate)
            };
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var updatedEmployee = JsonConvert.DeserializeObject<EmployeeDto>(content);
            return updatedEmployee;
        }

        public async Task DeleteEmployee(Guid id)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, "api/employees/" + id);

            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();
        }


        // CompanyDetails


        public async Task<IEnumerable<CompanyDetailDto>> GetCompanyDetails(Guid companyId)
        {
            var result = await _client.GetAsync("api/company/" + companyId + "/companydetails");

            if (!result.IsSuccessStatusCode)
                return null;
            var content = await result.Content.ReadAsStringAsync();
            var companyDetails = JsonConvert.DeserializeObject<IEnumerable<CompanyDetailDto>>(content);
            return companyDetails;
        }

        public async Task<CompanyDetailDto> GetCompanyDetail(Guid companyId, int id)
        {
            var result = await _client.GetAsync("api/company/" + companyId + "/companydetails/" + id);

            if (!result.IsSuccessStatusCode)
                return null;
            var content = await result.Content.ReadAsStringAsync();
            var companyDetail = JsonConvert.DeserializeObject<CompanyDetailDto>(content);
            return companyDetail;
        }

        public async Task<CompanyDetailForUpdate> GetCompanyDetailForUpdate(Guid companyId, int id)
        {
            var result = await _client.GetAsync("api/company/" + companyId + "/companydetails/" + id);

            if (!result.IsSuccessStatusCode)
                return null;
            var content = await result.Content.ReadAsStringAsync();
            var companyDetail = JsonConvert.DeserializeObject<CompanyDetailForUpdate>(content);

            return companyDetail;
        }

        public async Task<CompanyDetailDto> CreateCompanyDetail(Guid companyId, CompanyDetailForCreation companyDetail)
        {
            var activityToCreate = JsonConvert.SerializeObject(companyDetail);
            var request = new HttpRequestMessage(HttpMethod.Post, "api/company/" + companyId + "/companydetails")
            {
                Content = new StringContent(activityToCreate)
            };
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var createdCompanyDetail = JsonConvert.DeserializeObject<CompanyDetailDto>(content);
            return createdCompanyDetail;
        }

        public async Task<CompanyDetailDto> UpdateCompanyDetail(Guid companyId, int id, CompanyDetailForUpdate companyDetail)
        {
            var companyDetailToUpdate = JsonConvert.SerializeObject(companyDetail);
            var request = new HttpRequestMessage(HttpMethod.Put, "api/company/" + companyId + "/companydetails/" + id)
            {
                Content = new StringContent(companyDetailToUpdate)
            };
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var updatedCompanyDetail = JsonConvert.DeserializeObject<CompanyDetailDto>(content);
            return updatedCompanyDetail;
        }

        public async Task DeleteCompanyDetail(Guid companyId, int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, "api/company/" + companyId + "/companydetails/" + id);

            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();
        }
    }
}
