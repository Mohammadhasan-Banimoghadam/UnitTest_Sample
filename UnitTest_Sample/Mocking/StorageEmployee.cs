
using static UnitTest_Sample.Mocking.EmployeeController;

namespace UnitTest_Sample.Mocking
{
    public interface IStorageEmployee
    {
        public void DeleteEmployee(int id);
    }
    public class StorageEmployee : IStorageEmployee
    {
        private readonly EmployeeContext _db;
        public StorageEmployee()
        {
            _db = new EmployeeContext();
        }

        public void DeleteEmployee(int id)
        {
            var employee = _db.Employees.Find(id);
            _db.Employees.Remove(employee);
            _db.SaveChanges();
        }
    }
}
