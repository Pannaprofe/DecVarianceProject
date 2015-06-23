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
        public List<VisualizedResults> AllVisualizedResults { get; private set; }

        private Node Tree;
        public  Node Top {get; private set;}
        private int TreeLevels;
        public int CriticalNodeNumber { get; private set; }   // the Number of nodes of the tree with known number of levels

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
            AllVisualizedResults = new List<VisualizedResults>();

            BuildTheTree(ref Tree);
            PassTheTree(Top);
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
            double winnings = 0;
            foreach (BetInfo bet in Bets)
            {
                if (HavingSuchBet(tree.Path,bet))
                {
                    payments += bet.BetSize * (bet.Coef-1);
                }
                else
                {
                    winnings += bet.BetSize;
                }
            }
            payments = Math.Round(payments, 2);
            winnings = Math.Round(winnings, 2);
            if (tree.Parent != null)
            {
                VisualizedResults visualizedResults = new VisualizedResults(tree.NodeNum, tree.Path, tree.LocalProb, payments, winnings);
                AllVisualizedResults.Add(visualizedResults);
            }
               

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
