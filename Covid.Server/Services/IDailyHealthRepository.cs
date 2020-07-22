using Covid.Server.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid.Server.Services
{
    public interface IDailyHealthRepository
    {
        Task UpdateForDepartmentAsync(int departmentId, DateTime date, IList<DailyHealth> dailyHealths);

        Task<IList<DailyHealth>> GetByDepartmentAsync(int departmentId, DateTime date);
    }
}
