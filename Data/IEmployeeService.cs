using EmployeeWeb.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeWeb.Data
{
    public interface IEmployeeService
    {
        Task AddEmployeeAsync(Employee employeeToAdd);
        Task<IList<Employee>> GetEmployeesAsync();
        

    }
}
