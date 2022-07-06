using Microsoft.AspNetCore.Components;
using Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Pages.Employees
{
    public partial class EditEmployee : ComponentBase
    {
        [Parameter]
        public Guid EmployeeId { get; set; } = Guid.Empty;
    }
}
