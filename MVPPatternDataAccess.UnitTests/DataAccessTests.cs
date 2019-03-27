using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MVPPatternDataAccess.UnitTests
{
    [TestClass]
    public class DataAccessTests
    {
        [TestMethod]
        [ExpectedException(typeof(Exception),"ConnetionString boş olamaz!")]
        public void Ctor_ConnectionStringIsNullOrEmpty_Throws()
        {
            DataAccessLayer.DataAccess.MyProperty = "fakebaglanti";
            DataAccessLayer.DataAccess data = new DataAccessLayer.DataAccess();

        }
    }
}
