using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace addressbook_web_tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethodSquare()
        {
            Square s1 = new Square(4);
            Square s2 = new Square(6);
            Square s3 = s1;

            Assert.AreEqual(s1.Size, 4);
            Assert.AreEqual(s2.Size, 6);
            Assert.AreEqual(s3.Size, 4);

            s3.Size=15;
            Assert.AreEqual(s1.Size, 15);

            s2.Colored = true;
        }

        [TestMethod]
        public void TestMethodCircle()
        {
            Circle s1 = new Circle(4);
            Circle s2 = new Circle(6);
            Circle s3 = s1;

            Assert.AreEqual(s1.Radius, 4);
            Assert.AreEqual(s2.Radius, 6);
            Assert.AreEqual(s3.Radius, 4);

            s3.Radius = 15;
            Assert.AreEqual(s1.Radius, 15);

            s2.Colored = true;
        }
    }
}
