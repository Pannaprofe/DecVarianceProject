using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DecVarianceProject;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DecVarianceProject.Tests
{
    [TestClass()]
    public class SubTreeTests:Form1
    {

        SubTree Tree;
        public SubTreeTests()
        {
            SubTreeTests tests = new SubTreeTests();
            tests.ObtainData();
            Tree = new SubTree(ProbsMarathon, CoefsMarathon, AllBets);
        }

        [TestMethod()]
        public void SubTreeTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetOutputTest()
        {
            Assert.Fail();
        }
        [TestMethod()]
        public void TestNodesNumber()
        {
        }
    }
}
