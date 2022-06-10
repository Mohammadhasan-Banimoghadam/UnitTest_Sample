using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTest_Sample.Mocking;
using Xunit;

namespace UnitTest_Sample.UnitTest.Mocking
{
    public class EmployeeControllerTests
    {
        private EmployeeController _employeeController;
        private Mock<IStorageEmployee> _storageEmployee;

        public EmployeeControllerTests()
        {
            _storageEmployee = new Mock<IStorageEmployee>();
            _employeeController = new EmployeeController(_storageEmployee.Object);
        }

        [Fact]
        public void DeleteEmployee_WhenCalled_DeleteTheEmployeeFromDb()
        {
            _employeeController.DeleteEmployee(1);
            _storageEmployee.Verify(se=>se.DeleteEmployee(1));
        }
    }
}
