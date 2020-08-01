using Covid.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid.Client.Services
{
    public interface IDepartmentService
    {
        public Task<IEnumerable<DepartmentDto>> GetAllAsync();
    }
}
