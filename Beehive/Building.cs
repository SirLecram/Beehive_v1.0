using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beehive
{
    class Building
    {
        protected Random random = new Random();
        public static double NumberOfWorkers { get; protected set; }
        protected static List<Worker> workerList;
        public List<Worker> WorkersList
        {
            get { return workerList; }
            protected set { workerList = value; /*NumberOfWorkers = workerList.Count; */}
        }
        public Building()
        {
            WorkersList = new List<Worker>();
        }
    }
}
