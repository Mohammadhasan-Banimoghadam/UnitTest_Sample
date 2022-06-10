using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace UnitTest_Sample.Mocking
{
    public class EmployeeController
    {
        private readonly IStorageEmployee _storageEmployee;

        public EmployeeController(IStorageEmployee storageEmployee)
        {
            _storageEmployee = storageEmployee;
        }

        public ActionResult DeleteEmployee(int id)
        {
            _storageEmployee.DeleteEmployee(id);
            return RedirectToAction("Employees");
        }

        private ActionResult RedirectToAction(string employees)
        {
            return new RedirectResult(employees);
        }

        public class EmployeeContext
        {
            public DbSet<Employee> Employees { get; set; }
            public void SaveChanges()
            {

            }
        }
        public class Employee
        {
            public int Id { get; set; }
        }
    }
}
