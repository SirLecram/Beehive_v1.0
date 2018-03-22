using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beehive
{
    /// <summary>
    /// Enum that contains available jobs.
    /// </summary>
    enum Job
    {
        NectarCollecting,
        ProductionOfHoney,
        TakingAfterEggs,
        TeachingBees,
        CleaningBeehive,
        Patrol,
        Free
    }
    class Bee
    {
        protected double HoneyConsumedPerMg { get; }
        protected int WeightMg { get; }
        protected static int Index = 0;
        /// <summary>
        /// Index of Bee object
        /// </summary>
        public int IndexOfBee { get; protected set; }

        public Bee(int weightMg)
        {
            HoneyConsumedPerMg = 0.2;
            WeightMg = weightMg;
            
            IndexOfBee = Index;
            Index++;
        }
        /// <summary>
        /// Returns total amount of needed honey
        /// </summary>
        /// <returns></returns>
        public virtual double HoneyConsumptionRate()
        {
            return HoneyConsumedPerMg * WeightMg;
        }
    
    }
}
