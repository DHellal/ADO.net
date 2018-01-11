using Microsoft.VisualStudio.TestTools.UnitTesting;
using NorthWind2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind2.Tests
{
    [TestClass()]
    public class ContexteTests
    {
        [TestMethod()]
        public void GetPaysFournisseursTest()
        {
            Assert.AreEqual(16, Contexte1.GetPaysFournisseurs().Capacity);
        }
    }
}

namespace NorthWind2Tests
{
    class ContexteTests
    {
        [TestMethod()]          // pour considerer comme methode de test
        public void GetPaysFournisseursTest()
        {
            
            Assert.AreEqual(16, Contexte1.GetPaysFournisseurs().Capacity );
        }

        [TestMethod()]
        public void GetFournisseursTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetNbProduitTest()
        {
            Assert.Fail();
        }
    }

}

