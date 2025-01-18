using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreEditor.Settings
{
    internal class Lane
    {
        public List<double> LaneAxis { get; set; }
        public List<double> LaneX { get; set; }
        public double LaneWidth { get; set; }
    }
}
