using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecVarianceProject
{
    public class SubTree
    {
        private List<MatchParams> Probs;
        private List<MatchParams> Coefs;
        private List<BetInfo> Bets;
        private List<int> tmp = new List<int>();

        private Node Tree;
        private Node Top;

        private int TreeLevels;
        private StringBuilder stringBuilder = new StringBuilder();
        private int CriticalNodeNumber;
        public string StringOutput {get;set;}

        public SubTree(List<MatchParams> probs, List<MatchParams> coefs, List<BetInfo> bets)
        {
            this.Probs = probs;
            this.Coefs = coefs;
            this.Bets = bets;
            //initialize tree top
            Tree = new Node();
            Tree.LocalCoef = 1;
            Tree.LocalProb = 1;
            TreeLevels = probs.Count;
            GetCriticalNodeNumber();
            Top = Tree;

            BuildTheTree(ref Tree);
            PassTheTree(Top);

            StringOutput = stringBuilder.ToString();

        }

        //returns number of nodes in the tree, excluding top element
        internal void GetCriticalNodeNumber()
        {
            for (int i = 0; i < TreeLevels; i++)
            {
                CriticalNodeNumber = CriticalNodeNumber * 3 + 3;
            }
        }

        private void BuildTheTree(ref Node tree)
        {
            bool stop = false;
            int level = 0;
            int nodesNum = 0;
            var path = new List<int>();
            while (!stop)
            {
                if (level < TreeLevels)
                {
                    Node node = new Node();
                    if (tree.Win1 == null)
                    {
                        
                        node.Coef = Coefs[level].X1;
                        node.Prob = Probs[level].X1;
                        node.LocalCoef = tree.LocalCoef * node.Coef;
                        node.LocalProb = tree.LocalProb * node.Prob;
                        path.Add(1);
                        tree.Win1 = node;
                        node.Parent = tree;
                        tree = node;
                        tree.Path = new List<int>(path);
                       // Console.WriteLine(tree.Parent.Path);
                        nodesNum++;
                        
                        tree.NodeNum = nodesNum;
                        level++;
                    }
                    else if (tree.Draw == null)
                    {
                        node.Coef = Coefs[level].X;
                        node.Prob = Probs[level].X;
                        node.LocalCoef = tree.LocalCoef * node.Coef;
                        node.LocalProb = tree.LocalProb * node.Prob;
                        path.Add(0);
                        node.Path = new List<int>(path);
                        tree.Draw = node;
                        node.Parent = tree;
                        tree = node;
                        nodesNum++;
                        tree.NodeNum = nodesNum;
                        level++;
                    }
                    else if (tree.Win2 == null)
                    {
                        node.Coef = Coefs[level].X2;
                        node.Prob = Probs[level].X2;
                        node.LocalCoef = tree.LocalCoef * node.Coef;
                        node.LocalProb = tree.LocalProb * node.Prob;
                        path.Add(2);
                        node.Path = new List<int>(path);

                        tree.Win2 = node;
                        node.Parent = tree;
                        tree = node;
                        nodesNum++;
                        tree.NodeNum = nodesNum;
                        level++;
                    }
                    else
                    {
                        path.RemoveAt(path.Count-1);
                        tree = tree.Parent;
                        level--;
                    }
                }

                if (level == TreeLevels)
                {
                    if (nodesNum == CriticalNodeNumber)
                        stop = true;
                    else
                    {
                        path.RemoveAt(path.Count - 1);
                        level--;
                        tree = tree.Parent;
                    }
                }
            }
            Console.WriteLine(tree.Parent.Parent.Win1.Win1.Path.ToString());
        }

        private void PassTheTree(Node tree)
        {
            double payments = 0;
            foreach (BetInfo bet in Bets)
            {
                if (HavingSuchBet(tree.Path,bet))
                {
                    payments += bet.BetSize * bet.Coef;
                }
            }
            if (tree.Parent != null)
                stringBuilder.AppendLine(tree.NodeNum.ToString() + " " + tree.LocalProb + " path: " + getPathString(tree.Path) + " payment: " + payments);

            if (tree.Win1 == null)  // the level is the last
            {
                return;
            }
            PassTheTree(tree.Win1);
            PassTheTree(tree.Draw);
            PassTheTree(tree.Win2);
        }

        private string getPathString(List<int> lst)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var elem in lst)
                sb.Append(elem + " ");
            return sb.ToString();
        }

        private bool HavingSuchBet(List<int> path, BetInfo bet)
        {
            try
            {
                if (bet.MatchesAndOutcomes.Count > path.Count)
                    return false;
                else
                {
                    for (int i = 0; i < bet.MatchesAndOutcomes.Count; i++)
                    {
                        if (bet.MatchesAndOutcomes.Outcomes[i] != path[bet.MatchesAndOutcomes.MatchList[i]])
                            return false;
                    }
                    return true;
                }
            }
            catch
            {
                return false;
            }
           
        }
    }
}
