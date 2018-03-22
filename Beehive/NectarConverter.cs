using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beehive
{
    class NectarConverter : Worker
    {
        public override double MaxNectarCapity { get; }

        public NectarConverter(int weightMg) : base(weightMg)
        {
            JobsICanDo.Add(Job.ProductionOfHoney);
            MaxNectarCapity = 350;
        }
    }
}
