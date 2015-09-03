using System.Collections.Generic;
using DecVarianceProject.AppLogic;
using DecVarianceProject.Entities.Structures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DecVarianceProject.AppLogic.Tests
{
    [TestClass()]
    public class SubTreeTests
    {
        [TestMethod()]
        public void BuildTheTreeTest()
        {
            var instance = Singleton.Instance;
            instance.MatchesNum = 4;
            var simulation = new Simulation();
            simulation.Exexute();
            instance.Tree = new SubTree();
            instance.Tree.BuildTheTree(ref instance.Tree.Tree);
            var lst = new List<int>(){0,1,2,1};
            var node = instance.Tree.Top;
            var lstForCheck = new List<int>(node.Draw.Win1.Win2.Win1.Path);
            var equal = lst.Equals(lstForCheck); 
            Assert.AreEqual(equal,true);
        }
    }
}

namespace DecVarianceProjectTests.AppLogic
{
    [TestClass()]
    public class SubTreeTests
    {
        [TestMethod()]
        public void GetCriticalNodeNumberTest()
        {
            var instance = Singleton.Instance;
            instance.MatchesNum = 4;
            var subtree = new SubTree();
            Assert.AreEqual(subtree.CriticalNodeNumber,120);
        }
    }
}
