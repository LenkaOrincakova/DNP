using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeWebService.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace EmployeeWebService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (EmployeeDbContext employeeDbContext = new EmployeeDbContext())
            {
                if(!employeeDbContext.Employees.Any())
                {
                    Seed(employeeDbContext);
                }
            }
                CreateHostBuilder(args).Build().Run();
        }

        private static void Seed(EmployeeDbContext employeeDbContext)
        {
            string[] words = ("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque condimentum a libero ultrices congue. Vestibulum tellus lectus, gravida non fringilla at, scelerisque nec neque. Proin non nulla et nisl porta pharetra ut id massa. Pellentesque sit amet ante quam. Proin a maximus urna, at sagittis odio. Ut auctor urna ac nibh tempus porta. In eu orci felis. Nullam tempus justo ligula, ut dignissim mauris dictum ullamcorper. Morbi fermentum dictum tempor. Sed dictum enim quis pharetra consequat. Sed tempus quis lorem sit amet facilisis. Suspendisse sollicitudin lacus ac ultricies viverra. Etiam efficitur imperdiet mi. Praesent non dapibus lectus, venenatis congue urna. Praesent egestas hendrerit semper." +
                       "Phasellus ut laoreet neque. In dictum luctus libero vitae aliquet. Nulla eu velit orci. Vivamus libero ante, condimentum eget felis vel, aliquam viverra enim. Nulla nibh odio, rhoncus sed ex a, efficitur ullamcorper dolor. Ut tempor semper est, in lobortis nisi bibendum non. Nullam interdum, elit nec vehicula lobortis, nulla erat consequat ipsum, ac dapibus nisi nibh ut lectus." +
                       "Nam mattis nulla tincidunt tempor tincidunt. Sed vitae luctus neque. Duis nunc turpis, condimentum et enim nec, malesuada vehicula leo. Nullam in ligula feugiat, viverra nibh et, ultricies ipsum. Proin rhoncus congue nisi, eu interdum est. Etiam ornare, leo ac imperdiet malesuada, nisl quam dapibus justo, eu convallis neque metus nec urna. Fusce hendrerit dolor ut risus consequat semper. Sed sed enim lacus. Sed eget lorem lobortis, mollis urna vel, feugiat magna. Ut cursus erat massa, interdum cursus neque vulputate at. Aliquam luctus dictum augue a convallis." +
                       "Quisque molestie faucibus nisi a efficitur. Nam accumsan porta tellus, vel dictum nunc vulputate nec. In consectetur pulvinar sem, sit amet pharetra justo varius in. Nulla placerat pretium ultrices. Curabitur eu ex ultricies, commodo enim dapibus, bibendum purus. Aliquam suscipit eget quam eu imperdiet. Proin iaculis sollicitudin ante, quis porttitor nisl euismod ut. Proin lacinia ipsum quis elementum lobortis. Proin luctus mi eu congue tempus. Morbi commodo porta lacus a pharetra. Pellentesque ullamcorper sem arcu, a bibendum mi feugiat maximus. Suspendisse potenti." +
                       "Proin commodo felis tempor, maximus sem ac, volutpat ante. Nullam sed sollicitudin eros. Nulla nec lacus nibh. Quisque bibendum neque eu neque condimentum, eleifend mollis arcu sagittis. Etiam volutpat nunc orci, sit amet laoreet dolor commodo quis. Duis a tellus ultrices, consequat dui et, gravida dolor. Proin eu mi ac lacus malesuada ullamcorper. Duis pulvinar tortor quis bibendum blandit. Sed auctor porttitor risus sodales molestie. Cras quam nibh, tincidunt quis augue a, dapibus efficitur diam. Aliquam id tortor eget ante aliquet commodo non a nulla. Quisque mattis augue id urna pharetra rutrum. Nulla ipsum ante, molestie eu imperdiet in, semper et massa. Aenean velit ipsum, feugiat quis est nec, gravida fermentum lorem.").Split(' ');
            
           
                Employee employee = new Employee
                {
                    EmployeeId = 1,
                   HourlyWage= 145,
                    HoursPerMonth = 28
                };
                employeeDbContext.Add(employee);
            

            employeeDbContext.SaveChanges();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
