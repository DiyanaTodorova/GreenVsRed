using NUnit.Framework;
using GreenVsRed;

namespace GreenVSRedTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            Grid grid = new Grid(3, 3);
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}