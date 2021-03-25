using EmployeeWeb.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EmployeeWeb.Data
{
    public class CloudEmployeeService : IEmployeeService
    {
        private readonly HttpClient client;
        private string uri = "http://localhost:5003";
        
        public CloudEmployeeService()
        {
            client = new HttpClient();

        }
        public async Task AddEmployeeAsync(Employee employeeToAdd)
        {
            string employeeAsJson = JsonSerializer.Serialize(employeeToAdd);
            HttpContent content = new StringContent(employeeAsJson, Encoding.UTF8, "application/json");
            await client.PostAsync(uri + "/employees", content);
           
        }

        public async Task<IList<Employee>> GetEmployeesAsync()
        {
            Task<string> stringAsync = client.GetStringAsync(uri + "/employees");
            string message = await stringAsync;

            List<Employee> result = JsonSerializer.Deserialize<List<Employee>>(message);
            return result;
        }
    }
}
