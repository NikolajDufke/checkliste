using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestAfClassLibrary_.NET_Core_;

namespace UnitTest
{
    [TestClass]
    public class UnitTest
    {
        private Book _book;

        [TestInitialize]
        public void Initialize()
        {
            _book = new Book();
        }

        [TestMethod]
        public void TestAuthorName()
        {
            //Arrange
            //Book book = new Book();

            //Act
            _book.Author = "Anders Kristian Børjesson";

            //Assert
            Assert.AreEqual("Anders Kristian Børjesson", _book.Author);

            _book.Author = "Anders B";

            Assert.AreEqual("Anders B",_book.Author);

        }

        [TestMethod]
        public void TestToString()
        {
            //Arrange
            //Book book = new Book();

            //Act
            _book.Author = "Benjamin Sørensen";
            _book.Title = "How to get good at TFT";
            _book.Price = 50.50;
            string result = _book.ToString();

            //Assert
            Assert.AreEqual("Benjamin Sørensen How to get good at TFT 50,5", result);

        }

        [TestMethod]
        public void TestKommatal()
        {
            //Arrange
            //Book book = new Book();

            //Act
            _book.Price = 10.0/3.0;

            //Assert
            Assert.AreEqual(3.3333,_book.Price, 0.0001);

            try
            {
                _book.Price = -0.01;
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException ex){ }
            
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestIllegalPrice()
        {
            //Arrange

            //Act
            _book.Price = -0.01;

            //Assert
        }
    }
}
