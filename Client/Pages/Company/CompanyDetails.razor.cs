using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Pages.Company
{
    public partial class CompanyDetails : ComponentBase
    {
        [Parameter]
        public Guid CompanyId { get; set; }
    }
}
