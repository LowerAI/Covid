using Covid.Server.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid.Server.Services
{
    public interface IEmployeeRepository
    {
        Task<IList<Employee>> GetForDepartmentAsync(int departmentId);
        Task<Employee> GetOneAsync(int departmentId, int id);
        Task<Employee> AddAsync(Employee employee);
        Task UpdateAsync(Employee employee);
        Task DeleteAsync(int id);
    }
}
