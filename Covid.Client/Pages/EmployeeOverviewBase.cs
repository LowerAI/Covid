using Covid.Client.Services;
using Covid.Shared.Dtos;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Covid.Client.Pages
{
    public class EmployeeOverviewBase : ComponentBase
    {
        //[Inject]
        //public HttpClient HttpClient { get; set; }

        [Inject]
        public IEmployeeService EmployeeService { get; set; }

        public IEnumerable<EmployeeDto> Employees { get; set; } = new List<EmployeeDto>();

        protected async override Task OnInitializedAsync()
        {
            //Employees = await HttpClient.GetFromJsonAsync<IList<EmployeeDto>>("api/department/1/employee");

            Employees = await EmployeeService.GetForDepartmentAsync(1);
            await base.OnInitializedAsync();
        }
    }
}