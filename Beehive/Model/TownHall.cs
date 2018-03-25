using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beehive.Model
{
    /// <summary>
    /// Class responsilbe for storing data about bees. It also contains methods responsible for 
    /// creating and destroying bees.
    /// </summary>
    class TownHall : Building
    {
        public double NumberOfNectarCollectors { get; private set; }
        public double NumberOfNectarConverters { get; private set; }
        public Warehouse Warehouse { get; private set; }

        public TownHall(int honeyAmount) : base()
        {
            Warehouse = new Warehouse(honeyAmount);
            const int starterNumberOfBees = 15;
            for (int i = 0; i < starterNumberOfBees; i++)
            {
                BornNewBee();
            }
        }

        #region Main TownHall mechanics
        public void BornNewBee(List<Job> jobNewWorkerCanDo)
        {
            int weight = random.Next(100, 301);
            WorkersList.Add(new Worker(weight, jobNewWorkerCanDo));
        }
        public void BornNewBee()
        {
            int typeOfBee = random.Next(1, 6);
            int weight = random.Next(100, 301);

            switch (typeOfBee)
            {
                case 1:
                    WorkersList.Add(new NectarCollector(weight));
                    NumberOfWorkers++; NumberOfNectarCollectors++;
                    break;
                case 2:
                    WorkersList.Add(new NectarConverter(weight));
                    NumberOfWorkers++; NumberOfNectarConverters++;
                    break;
                default:
                    int howManyAbilities = random.Next(1, 5);
                    List<Job> newWorkerAbilities = new List<Job>();
                    for (int i = 0; i < howManyAbilities; i++)
                    {

                        Job jobToAdd = (Job)Enum.Parse(typeof(Job), random.Next(0, 6).ToString());
                        if (newWorkerAbilities.Contains(jobToAdd))
                            i--;
                        else
                            newWorkerAbilities.Add(jobToAdd);
                    }
                    WorkersList.Add(new Worker(weight, newWorkerAbilities));
                    NumberOfWorkers++;
                    break;

            }
        }
        internal void KillBee()
        {
            if (NumberOfWorkers > 0)
            {
                int randomWorker = random.Next(0, WorkersList.Count);
                Worker worker = WorkersList.ElementAt(randomWorker);

                if (worker is NectarCollector)
                    NumberOfNectarCollectors--;
                if (worker is NectarConverter)
                    NumberOfNectarConverters--;
                WorkersList.Remove(worker);
                NumberOfWorkers--;
            }
        }
        internal void IncreaseThePopulation(int shiftNr)
        {
            int shiftNumber = shiftNr;
            if (shiftNumber % 3 == 2)
            {
                int howManyBees = random.Next(1, 4);
                for (int i = 0; i < howManyBees; i++)
                {
                    BornNewBee();
                }
            }
        }
        #endregion
    }
}