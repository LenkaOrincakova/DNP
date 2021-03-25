using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EmployeeWeb.Model
{
    public class Employee
    {
        [Required]
        [JsonPropertyName("employeeId")]
        public int EmployeeId { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("hourlyWage")]
        public double HourlyWage { get; set; }
        [JsonPropertyName("hoursPerMonth")]
        public double HoursPerMonth { get; set; }
        //public bool HasOvertime { get; set; }
        public double GetMonthlyPay()
        {

            if (HoursPerMonth > 150)
            {
                double OvertimePay = (HoursPerMonth - 150) * (HourlyWage * 1.5);
                return OvertimePay + (150 * HourlyWage);
            }
            else
            {
                return HourlyWage * HoursPerMonth;
            }
        }

    }
}



      