using System;
using DataAccessLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MVPPatternDataAccess.UnitTests
{
    [TestClass]
    public class DataAccessTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Ctor_ConnectionStringIsNullOrEmpty_Throws()
        {
            DataAccess data = new DataAccess(null);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Select_ArgumentIsNullOrEmpty_Throws()
        {
            DataAccess data = new DataAccess("fakebaglanti");
            data.Select(null);
        }

    }
}
