using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTest_Sample.Fundamentals;
using Xunit;

namespace UnitTest_Sample.UnitTest.FundamentalsTest
{
    public class CustomerControllerTests
    {
        private readonly CustomerController _customerController;
        public CustomerControllerTests()
        {
            _customerController = new CustomerController();
        }

        [Fact]
        public void GetCustomer_IdIsZero_ReturnNotFound()
        {
            var result = _customerController.GetCustomer(0);
            Assert.IsType<NotFound>(result);
        }
        [Fact]
        public void GetCustomer_IdIsNotZero_ReturnOk()
        {
            var result = _customerController.GetCustomer(1);
            Assert.IsType<OK>(result);
        }
    }
}
