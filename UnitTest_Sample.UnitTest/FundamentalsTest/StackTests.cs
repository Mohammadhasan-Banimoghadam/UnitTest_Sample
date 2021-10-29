using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTest_Sample.UnitTest.FundamentalsTest
{
    public class StackTests
    {
        private readonly Fundamentals.Stack<string> _stack;
        public StackTests()
        {
            _stack = new Fundamentals.Stack<string>();
        }
        [Fact]
        public void Push_ArgIsNull_ReturnArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _stack.Push(null));
        }
        [Fact]
        public void Push_ArgIsNotNull_AddObjectToList()
        {
            _stack.Push("add object to List");
            Assert.Equal(1, _stack.Count);
        }
        [Fact]
        public void Count_EmptyStack_ReturnZero()
        {
            Assert.Equal(0, _stack.Count);
        }
        [Fact]
        public void Pop_ArgIsNull_ReturnArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _stack.Pop());
        }
        [Fact]
        public void Pop_StackWithAFewObject_ReturnObjectOnTheTopList()
        {
            //Arrange
            _stack.Push("a");
            _stack.Push("b");
            _stack.Push("c");
            //Act
            var result = _stack.Pop();
            //Assert
            Assert.Equal("c", result);
        }
        [Fact]
        public void Peek_StackWithAFewObject_RemoveObjectOnTheTopList()
        {
            //Arrange
            _stack.Push("a");
            _stack.Push("b");
            _stack.Push("c");
            //Act
            var result = _stack.Pop();
            //Assert
            Assert.Equal(2, _stack.Count);
        }
        [Fact]
        public void Peek_ArgIsNull_ReturnArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _stack.Peek());
        }
        [Fact]
        public void Peek_StackWithAFewObject_ReturnObjectOnTheTopList()
        {
            //Arrange
            _stack.Push("a");
            _stack.Push("b");
            _stack.Push("c");
            //Act
            var result = _stack.Peek();
            //Assert
            Assert.Equal("c", result);
        }
        [Fact]
        public void Peek_StackWithAFewObject_DoesNotRemoveTheObjectOnTopOfTheStack()
        {
            //Arrange
            _stack.Push("a");
            _stack.Push("b");
            _stack.Push("c");
            //Act
            var result = _stack.Peek();
            //Assert
            Assert.Equal(3, _stack.Count);
        }
    }
}
