using Covid.Client.Services;
using Covid.Shared.Dtos;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Covid.Client.Pages
{
    public class EmployeeOverviewBase : ComponentBase
    {
        //[Inject]
        //public HttpClient HttpClient { get; set; }

        [Inject] public IEmployeeService EmployeeService { get; set; }
        [Inject] public IJSRuntime JsRuntime { get; set; }

        public IEnumerable<EmployeeDto> Employees { get; set; } = new List<EmployeeDto>();
        public string Result { get; set; }

        protected async override Task OnInitializedAsync()
        {
            //Employees = await HttpClient.GetFromJsonAsync<IList<EmployeeDto>>("api/department/1/employee");

            Employees = await EmployeeService.GetForDepartmentAsync(1);
            await base.OnInitializedAsync();
        }

        protected async Task SayHello()
        {
            Result = await JsRuntime.InvokeAsync<string>("SayHello", "Mike");
        }
    }
}