using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Beehive
{
    /// <summary>
    /// Class represents Queen of Beehive. It is responsilbe for managing other bees.
    /// </summary>
    class Queen : Bee
    {
        /// <summary>
        /// Represents the number of actual shift
        /// </summary>
        public int ShiftNumber { get; private set; }
        private double QueensHoneyConsumptionPerMg { get; }

        public Queen(int weightMg) : base(weightMg)
        {
            ShiftNumber = 0;
            QueensHoneyConsumptionPerMg = 0.15;
        }

    /// <summary>
    /// Method which shearches the WorkerList to assign work to the right bee.
    /// </summary>
    /// <param name="townHall"></param>
    /// <param name="jobToDo"></param>
    /// <param name="numberOfShifts"></param>
    /// <returns></returns>
        public bool AssignWork(TownHall townHall, Job jobToDo, int numberOfShifts)
        {
            List<Worker> workerList = townHall.WorkersList;
            if (LookForNectarCollectors(townHall, jobToDo, numberOfShifts))
                return true;
            if (LookForNectarConverter(townHall, jobToDo, numberOfShifts))
                return true;
            for (int i = 0; i<Building.NumberOfWorkers; i++)
            {
                Worker worker = workerList.ElementAt(i);
                if (worker.DoThisJob(jobToDo, numberOfShifts))
                {
                    MessageBox.Show("Przypisano pracę pszczole nr: " + (i+1).ToString());
                    return true;
                } 
            }
            return false;
        }
        /// <summary>
        /// Method used to start next shift
        /// </summary>
        /// <param name="warehouse"></param>
        /// <returns></returns>
        public string StartNewShift(Warehouse warehouse)
        {
            string raport = "";
            for (int i = 0; i < Building.NumberOfWorkers; i++)
            {
                
                Worker worker = warehouse.WorkersList.ElementAt(i);

                bool checkWorkEnd = worker.WorkNextShift();
                switch (worker.CurrentJob)
                {
                    case Job.NectarCollecting:
                        warehouse.StoreNectar(worker.ReturnNectar());
                        break;
                    case Job.ProductionOfHoney:
                        warehouse.MakeHoneyFromNectar(worker);
                        break;
                }
                if (worker.DayOff)
                    raport += "Pszczoła nr " + (i + 1).ToString() + " jest teraz na urlopie.\n";
                else if (checkWorkEnd)
                    raport += "Pszczoła nr " + (i+1).ToString() + " właśnie zakończyła swoje zadanie.\n";
                else if (worker.CurrentJob == Job.Free)
                    raport += "Pszczoła nr " + (i+1).ToString() + " nic nie robi.\n";
                else
                {
                    raport += "Pszczoła nr " + (i + 1).ToString() + " będzie robić " +
                        worker.CurrentJob.ToString() + " przez " + worker.ShiftsLeft.ToString() +
                        " zmian roboczych.\n";
                }
                
            }
            ShiftNumber++;
            return raport;
        }
        public override double HoneyConsumptionRate()
        {
            double consumption = base.HoneyConsumptionRate();
            consumption += WeightMg * QueensHoneyConsumptionPerMg;
            return consumption;

        }
        private bool LookForNectarCollectors(TownHall townHall, Job jobToDo, int numberOfShifts)
        {
            if(townHall.WorkersList.Count != 0)
            {
                for (int i = 0; i < townHall.WorkersList.Count; i++)
                {
                    Worker worker = townHall.WorkersList.ElementAt(i);
                    if (worker is NectarCollector)
                    {
                        worker = worker as NectarCollector;
                        if (worker.DoThisJob(jobToDo, numberOfShifts))
                        {
                            MessageBox.Show("Przypisano pracę N/C nr: " + (i + 1).ToString());
                            return true;
                        }
                    }
                }
                
            }
            return false;

        }
        private bool LookForNectarConverter(TownHall townHall, Job jobToDo, int numberOfShifts)
        {
            if(townHall.WorkersList.Count !=0)
            {
                for (int i = 0; i < townHall.WorkersList.Count; i++)
                {
                    Worker worker = townHall.WorkersList.ElementAt(i);
                    if (worker is NectarConverter)
                    {
                        worker = worker as NectarConverter;
                        if (worker.DoThisJob(jobToDo, numberOfShifts))
                        {
                            MessageBox.Show("Przypisano pracę pszczole NectarConverter nr: " + (i + 1).ToString());
                            return true;
                        }
                    }
                }
            }
            
            return false;
        }
    }
}
