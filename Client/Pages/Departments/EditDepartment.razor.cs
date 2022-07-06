using Microsoft.AspNetCore.Components;
using Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Pages.Departments
{
    public partial class EditDepartment : ComponentBase
    {
        [Parameter]
        public int DepartmentId { get; set; }
    }
}
