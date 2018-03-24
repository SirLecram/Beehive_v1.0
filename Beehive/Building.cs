using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beehive
{
    class Building
    {
        protected Random random = new Random();
        public static double NumberOfWorkers { get; protected set; }
        protected static ObservableCollection<Worker> workerList;
        public ObservableCollection<Worker> WorkersList
        {
            get { return workerList; }
            protected set { workerList = value; /*NumberOfWorkers = workerList.Count; */}
        }
        public Building()
        {
            WorkersList = new ObservableCollection<Worker>();
        }
    }
}
