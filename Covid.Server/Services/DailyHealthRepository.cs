using Covid.Server.Data;
using Covid.Server.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid.Server.Services
{
    public class DailyHealthRepository : IDailyHealthRepository
    {
        private readonly MyDbContext _myContext;

        public DailyHealthRepository(MyDbContext myContext)
        {
            _myContext = myContext;
        }

        public async Task<IList<DailyHealth>> GetByDepartmentAsync(int departmentId, DateTime date)
        {
            var employeeIds = await _myContext.Employees
                .Where(x => x.DepartmentId == departmentId)
                .Select(x => x.Id).ToListAsync();

            var dailyHealths = await _myContext.DailyHealths
                .Where(x => x.Date == date && employeeIds.Contains(x.EmployeeId))
                .ToListAsync();

            return dailyHealths;
        }

        public async Task UpdateForDepartmentAsync(int departmentId, DateTime date, IList<DailyHealth> dailyHealths)
        {
            var employeeIds = await _myContext.Employees
                .Where(x => x.DepartmentId == departmentId)
                .Select(x => x.Id)
                .ToListAsync();

            var inDb = await _myContext.DailyHealths
                .Where(x => x.Date == date && employeeIds.Contains(x.EmployeeId))
                .ToListAsync();

            foreach (var dbItem in inDb)
            {
                var one = dailyHealths.SingleOrDefault(x => x.EmployeeId == dbItem.EmployeeId && x.Date == dbItem.Date);

                if (one != null)
                {
                    dbItem.HealthCondition = one.HealthCondition;
                    dbItem.Temperature = one.Temperature;
                    dbItem.Remark = one.Remark;
                    _myContext.Update(dbItem);
                }
            }

            var dbKeys = inDb.Select(x => new { x.EmployeeId, x.Date }).ToList();
            var inconmingKeys = dailyHealths.Select(x => new { x.EmployeeId, x.Date }).ToList();
            var toAddKeys = inconmingKeys.Except(dbKeys);
            foreach (var addKey in toAddKeys)
            {
                var toAdd = dailyHealths.Single(x => x.EmployeeId == addKey.EmployeeId && x.Date == addKey.Date);
                await _myContext.AddAsync(toAdd);
            }

            var toRemoveKeys = dbKeys.Except(inconmingKeys);
            foreach (var removeKey in toRemoveKeys)
            {
                var toRemove = inDb.Single(x => x.EmployeeId == removeKey.EmployeeId && x.Date == removeKey.Date);
                _myContext.Remove(toRemove);
            }

            await _myContext.SaveChangesAsync();
        }
    }
}
