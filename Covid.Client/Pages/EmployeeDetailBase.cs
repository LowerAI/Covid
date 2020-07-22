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
    public class EmployeeDetailBase : ComponentBase
    {
        [Parameter]
        public string EmployeeId { get; set; }

        public EmployeeDto Employee { get; set; } = new EmployeeDto();

        [Inject]
        public HttpClient HttpClient { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Employee = await HttpClient.GetFromJsonAsync<EmployeeDto>($"api/department/1/employee/{EmployeeId}");

            await base.OnInitializedAsync();
        }
    }
}