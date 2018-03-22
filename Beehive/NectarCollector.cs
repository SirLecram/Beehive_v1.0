using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beehive
{
    class NectarCollector : Worker
    {
        public override double MaxNectarCapity { get; } 
        public override double NectarMg {
            get {return nectarMg; }
            protected set {
                if (nectarMg + value > MaxNectarCapity)
                    nectarMg = MaxNectarCapity;
                else
                    nectarMg = value;
            }
        }

        public NectarCollector(int weightMg) : base(weightMg)
        {
            NectarMg = 0;
            JobsICanDo.Add(Job.NectarCollecting);
            MaxNectarCapity = 320;
        }
      
        protected override double CollectNectar()
        {
            double collectedNectar = random.Next(220, 321);
            return collectedNectar;
        }
        public override double ReturnNectar()
        {
            double amountOfNectar = NectarMg;
            NectarMg = 0;
            return amountOfNectar;
        }
    }
}
