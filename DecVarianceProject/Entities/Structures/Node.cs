﻿using System;
using System.Collections.Generic;

namespace DecVarianceProject.Entities
{
    [Serializable]
    public class Node
    {
        public Node Parent { get; set; }
        public Node Win1 { get; set; }
        public Node Win2 { get; set; }
        public Node Draw { get; set; }
        public double Coef { get; set; }
        public int Level { get; set; }
        public double Prob { get; set; }
        public double LocalCoef { get; set; }
        public double LocalProb { get; set; }
        public int NodeNum { get; set; }
        public List<int> Path { get; set; }
    }
}
