using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Covid.Client.Services;

namespace Covid.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            //builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri("http://localhost:7000") });
            builder.Services.AddHttpClient<IEmployeeService, EmployeeService>(client => client.BaseAddress = new Uri("http://localhost:7000"));
            builder.Services.AddHttpClient<IDepartmentService, DepartmentService>(client => client.BaseAddress = new Uri("http://localhost:7000"));

            await builder.Build().RunAsync();
        }
    }
}
