using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class HorseTest
    { 
        private Horse _horse;

        [TestInitialize]
        public void Initialize()
        {
            _horse = new Horse();
        }

        [TestMethod]
        public void TestLegs()
        {
            Assert.AreEqual(4, _horse.Legs);
        }

    }

    internal class Horse
    {
        private int _legs;

        public int Legs
        {
            get => _legs;
            set => _legs = value;
        }
    }
}