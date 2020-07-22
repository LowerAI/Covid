using Covid.Shared.Dtos;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Covid.Client.Pages
{
    public class EmployeeOverviewBase : ComponentBase
    {
        [Inject]
        public HttpClient HttpClient { get; set; }

        public IEnumerable<EmployeeDto> Employees { get; set; } = new List<EmployeeDto>();

        protected async override Task OnInitializedAsync()
        {
            Employees = await HttpClient.GetFromJsonAsync<IList<EmployeeDto>>("api/department/1/employee");
            await base.OnInitializedAsync();
        }
    }
}
