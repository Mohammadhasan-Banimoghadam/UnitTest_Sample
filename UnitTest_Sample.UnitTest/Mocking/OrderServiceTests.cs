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
    public class OrderServiceTests
    {
        private readonly Mock<IStorage> _storage;
        private readonly OrderService _orderService;
        public OrderServiceTests()
        {
            _storage = new Mock<IStorage>();
            _orderService = new OrderService(_storage.Object);
        }

        [Fact]
        public void PlaceOrder_WhenCalled_StoreTheOrder()
        {
            var order = new Order();
            _orderService.PlaceOrder(order);
            _storage.Verify(s => s.Store(order));
        }
    }
}
