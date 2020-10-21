using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ExportCsvFile.Models;
using System.Text;

namespace ExportExcelDemo.Controllers
{
    public class HomeController : Controller
    {
        private List<Employee> employees = new List<Employee>
        {
            new Employee {EmployeeId = 1, EmployeeName = "John", HireDate = "10-Jan-1997"},
            new Employee {EmployeeId = 2, EmployeeName = "Joe", HireDate = "23-Mar-1998"},
            new Employee {EmployeeId = 3, EmployeeName = "Steve", HireDate = "18-Jan-1999"},
            new Employee {EmployeeId = 4, EmployeeName = "Yancy", HireDate = "30-Apr-2001"},
            new Employee {EmployeeId = 5, EmployeeName = "Mukesh", HireDate = "01-Oct-2002"},
        };

        public IActionResult Index()
        {
            return CSV();
        }

        public IActionResult CSV()
        {
            var builder = new StringBuilder();
            builder.AppendLine("EmployeeId,EmployeeName,JoinDate");

            foreach (var employee in employees)
            {
                builder.AppendLine($"{employee.EmployeeId},{employee.EmployeeName},{employee.HireDate}");
            }

            return File(Encoding.UTF8.GetBytes(builder.ToString()), "text/csv", "EmployeesList.csv");
        }

        
    }
}