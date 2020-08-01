using Covid.Client.Services;
using Covid.Shared.Dtos;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Covid.Client.Pages
{
    public class EmployeeDetailBase : ComponentBase
    {
        [Parameter]
        public string EmployeeId { get; set; }

        public EmployeeDto Employee { get; set; } = new EmployeeDto();

        //[Inject]
        //public HttpClient HttpClient { get; set; }

        [Inject]
        public IEmployeeService EmployeeService { get; set; }

        protected async override Task OnInitializedAsync()
        {
            //Employee = await HttpClient.GetFromJsonAsync<EmployeeDto>($"api/department/1/employee/{EmployeeId}");

            Employee = await EmployeeService.GetOneForDepartmentAsync(1, int.Parse(EmployeeId));
            await base.OnInitializedAsync();
        }

        public void Button_Click()
        {
            Employee.Name = "Roberto Baggio";
        }
    }
}