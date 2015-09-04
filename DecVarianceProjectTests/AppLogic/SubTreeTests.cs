using System.Collections.Generic;
using DecVarianceProject.AppLogic;
using DecVarianceProject.Entities.Structures;
using DecVarianceProject.Entities.TablesContents;
using DecVarianceProject.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace DecVarianceProjectTests.AppLogic
{
    [TestClass()]
    public class SubTreeTests
    {
        // Tests the correctness of building the tree
        [TestMethod()]
        public void BuildTheTreeTest()
        {
            var mainForm = new MainForm();   // creates DGV list
            var instance = Singleton.Instance;
            instance.MatchesNum = 4;
            var simulation = new Simulation();
            simulation.Exexute();
            instance.Tree = new SubTree();
            instance.Tree.BuildTheTree(ref instance.Tree.Tree);
            var lst = new List<int>(){0,1,2,1};
            var node = instance.Tree.Top;
            var lstForCheck = new List<int>(node.Draw.Win1.Win2.Win1.Path);
            var equal = UnorderedEqual(lst, lstForCheck);
            Assert.AreEqual(equal,true);
        }

        private static bool UnorderedEqual<T>(ICollection<T> a, ICollection<T> b)
        {
            // 1
            // Require that the counts are equal
            if (a.Count != b.Count)
            {
                return false;
            }
            // 2
            // Initialize new Dictionary of the type
            Dictionary<T, int> d = new Dictionary<T, int>();
            // 3
            // Add each key's frequency from collection A to the Dictionary
            foreach (T item in a)
            {
                int c;
                if (d.TryGetValue(item, out c))
                {
                    d[item] = c + 1;
                }
                else
                {
                    d.Add(item, 1);
                }
            }
            // 4
            // Add each key's frequency from collection B to the Dictionary
            // Return early if we detect a mismatch
            foreach (T item in b)
            {
                int c;
                if (d.TryGetValue(item, out c))
                {
                    if (c == 0)
                    {
                        return false;
                    }
                    else
                    {
                        d[item] = c - 1;
                    }
                }
                else
                {
                    // Not in dictionary
                    return false;
                }
            }
            // 5
            // Verify that all frequencies are zero
            foreach (int v in d.Values)
            {
                if (v != 0)
                {
                    return false;
                }
            }
            // 6
            // We know the collections are equal
            return true;
        }

        //tets the number of all nodes in the tree to be correct
        [TestMethod()]
        public void GetCriticalNodeNumberTest()
        {
            var instance = Singleton.Instance;
            instance.MatchesNum = 4;
            var subtree = new SubTree();
            Assert.AreEqual(subtree.CriticalNodeNumber, 120);
            instance.MatchesNum = 8;
            subtree = new SubTree();
            Assert.AreEqual(subtree.CriticalNodeNumber, 9840);
        }

        //tests the correctness of passing the tree
        [TestMethod()]
        public void PassTheTreeTest()
        {
            var mainForm = new MainForm();   // creates DGV list
            var instance = Singleton.Instance;
            instance.MatchesNum = 3;
            var simulation = new Simulation();
            simulation.Exexute();
            instance.Tree = new SubTree();
            instance.Tree.BuildTheTree(ref instance.Tree.Tree);
            instance.ClientsBetsList.Clear();
            var matchlist = new List<int>() {0, 2};
            var outcomeslist = new List<int>() {1, 1};
            const int betsize = 100;
            const int coef = 10;
            const double prob = 0.09;
            const int expectedPayments = betsize*(coef - 1);

            var bet = new BetInfo(matchlist,outcomeslist,betsize,coef,prob );
            instance.ClientsBetsList.Add(bet);
            instance.Tree.PassTheTree(instance.Tree.Top);
            var node1 = instance.Tree.Top.Win1.Win1.Win1;
            var node2 = instance.Tree.Top.Win1.Draw.Win1;

            var rez1 = new ResultsNotForTableContent();
            var rez2 = new ResultsNotForTableContent();
            foreach (var elem in instance.AllResultsNoTableList)
            {
                if (elem.Node == node1.NodeNum)
                    rez1 = elem;
                else if (elem.Node == node2.NodeNum)
                    rez2 = elem;
            }
            Assert.AreEqual(rez1.Payments,rez2.Payments);
            Assert.AreEqual(rez1.Payments,expectedPayments);
        }
    }
}
