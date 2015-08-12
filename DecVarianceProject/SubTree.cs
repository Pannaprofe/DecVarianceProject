using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using DecVarianceProject.Structures;
using DecVarianceProject.Structures.TablesContents;

namespace DecVarianceProject
{
    [Serializable]
    public class SubTree
    {
        private readonly Singleton _instance;

        private  Node Top {get; set;}
        private readonly int _treeLevels;
        private int CriticalNodeNumber { get; set; }   // the Number of nodes of the tree with known number of levels

        public SubTree()
        {
            _instance = Singleton.Instance;
            //initialize tree top
            var tree = new Node
            {
                LocalCoef = 1,
                LocalProb = 1
            };
            _treeLevels = _instance.ProbsMarathon.Count;
            GetCriticalNodeNumber();
            Top = tree;
            _instance.AllResultsNoTable= new List<ResultsNotForTableContent>();

            BuildTheTree(ref tree);
            PassTheTree(Top);
        }

        //returns number of nodes in the tree, excluding top element
        private void GetCriticalNodeNumber()
        {
            for (var i = 0; i < _treeLevels; i++)
            {
                CriticalNodeNumber = CriticalNodeNumber * 3 + 3;
            }
        }

        private void BuildTheTree(ref Node tree)
        {
            var stop = false;
            var level = 0;
            var nodesNum = 0;
            var path = new List<int>();
            while (!stop)
            {
                if (level < _treeLevels)
                {
                    var node = new Node();
                    if (tree.Win1 == null)
                    {
                        
                        node.Coef = _instance.CoefsMarathon[level][1];
                        node.Prob = _instance.ProbsMarathon[level][1];
                        node.LocalCoef = Math.Round(tree.LocalCoef * node.Coef,3);
                        node.LocalProb = Math.Round(tree.LocalProb * node.Prob,6);
                        path.Add(1);
                        tree.Win1 = node;
                        node.Parent = tree;
                        tree = node;
                        tree.Path = new List<int>(path);
                        nodesNum++;
                        
                        tree.NodeNum = nodesNum;
                        level++;
                    }
                    else if (tree.Draw == null)
                    {
                        node.Coef = _instance.CoefsMarathon[level][0];
                        node.Prob = _instance.ProbsMarathon[level][0];
                        node.LocalCoef = Math.Round(tree.LocalCoef * node.Coef,3);
                        node.LocalProb = Math.Round(tree.LocalProb * node.Prob,6);
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
                        node.Coef = _instance.CoefsMarathon[level][2];
                        node.Prob = _instance.ProbsMarathon[level][2];
                        node.LocalCoef = Math.Round(tree.LocalCoef * node.Coef,3);
                        node.LocalProb = Math.Round(tree.LocalProb * node.Prob,6);
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

                if (level != _treeLevels) continue;
                if (nodesNum == CriticalNodeNumber)
                    stop = true;
                else
                {
                    path.RemoveAt(path.Count - 1);
                    level--;
                    tree = tree.Parent;
                }
            }
            Console.WriteLine(tree.Parent.Parent.Win1.Win1.Path.ToString());
        }

        private void PassTheTree(Node tree)
        {
            double payments = 0;
            double winnings = 0;
            foreach (var bet in _instance.ClientsBets)
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
                var str = string.Join(", ", tree.Path.ToArray());
                str = Regex.Replace(str, @"0", "X");
                str = Regex.Replace(str,@"[1-2]", "P$&");
                var results = new ResultsNotForTableContent()
                 {
                     Node = tree.NodeNum,
                     Probability = tree.LocalProb,
                     NodePathString = str,
                     Winnings = winnings,
                     Payments = payments,
                     NetWon = Math.Round(winnings - payments, 2),
                     NodePathList = new List<int>(tree.Path)
                 };
                _instance.AllResultsNoTable.Add(results);
            }
               

            if (tree.Win1 == null)  // the level is the last
            {
                return;
            }
            PassTheTree(tree.Win1);
            PassTheTree(tree.Draw);
            PassTheTree(tree.Win2);
        }

        private static bool HavingSuchBet(IReadOnlyList<int> path, BetInfo bet)
        {
            try
            {
                if (bet.MatchesAndOutcomes.Count > path.Count)
                    return false;
                for (var i = 0; i < bet.MatchesAndOutcomes.Count; i++)
                {
                    if (bet.MatchesAndOutcomes.Outcomes[i] != path[bet.MatchesAndOutcomes.MatchList[i]])
                        return false;
                }
                return true;
            }
            catch
            {
                return false;
            }
           
        }
    }
}
