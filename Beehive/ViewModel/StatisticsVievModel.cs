using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Beehive.Model;

namespace Beehive.ViewModel
{
    class StatisticsViewModel : INotifyPropertyChanged
    {
        #region Models and attributes
        private Queen queen = new Queen(300);
        private TownHall townHall = new TownHall(2000);
        private Warehouse warehouse = null;
        
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Proporties to binding
        public string Honey
        {
            get { return warehouse.AmountOfHoney.ToString(); }
        }
        public string Nectar
        {
            get { return warehouse.AmountOfNectar.ToString() ; }
        }

        public string AllBees
        {
            get { return townHall.WorkersList.Count.ToString(); }
        }
        public string AllCollectors
        {
            get
            {
                int numberOfNectarCollectors = 0;
                foreach (Worker worker in townHall.WorkersList)
                {
                    if (CheckIsNectarCollector(worker))
                        numberOfNectarCollectors++;
                }
                return numberOfNectarCollectors.ToString();
            }
        }
        public string FreeCollectors
        {
            get
            {
                int numberOfFreeNectarCollectors = 0;
                foreach (Worker worker in townHall.WorkersList)
                {
                    if (CheckIsNectarCollector(worker) && worker.CurrentJob == Job.Free)
                        numberOfFreeNectarCollectors++;
                }
                return numberOfFreeNectarCollectors.ToString();
            }
        }
        public string AllConverters
        {
            get
            {
                int numberOfNectarConverters = 0;
                foreach (Worker worker in townHall.WorkersList)
                {
                    if (CheckIsNectarConverter(worker))
                        numberOfNectarConverters++;
                }
                return numberOfNectarConverters.ToString();
            }
        }
        public string FreeConverters
        {
            get
            {
                int numberOfFreeNectarConverters = 0;
                foreach (Worker worker in townHall.WorkersList)
                {
                    if (CheckIsNectarConverter(worker) && worker.CurrentJob == Job.Free)
                        numberOfFreeNectarConverters++;
                }
                return numberOfFreeNectarConverters.ToString();
            }
        }
        public string AllWorkers
        {
            get
            {
                int numberOfWorkers = 0;
                foreach (Worker worker in townHall.WorkersList)
                {
                    if (!CheckIsNectarCollector(worker) && !CheckIsNectarConverter(worker))
                        numberOfWorkers++;
                }
                return numberOfWorkers.ToString();
            }
        }
        public string FreeWorkers
        {
            get
            {
                int numberOfFreeWorkers = 0;
                foreach (Worker worker in townHall.WorkersList)
                {
                    if (!CheckIsNectarCollector(worker) && !CheckIsNectarConverter(worker)
                        && worker.CurrentJob == Job.Free)
                        numberOfFreeWorkers++;
                }
                return numberOfFreeWorkers.ToString();
            }
        }

        #endregion

        public StatisticsViewModel()
        {
            warehouse = townHall.Warehouse;
        }

        #region Methods - operations on Queen model
        /// <summary>
        /// It is a method which returns report to QueenView. The report tells you 
        /// if you've found the right worker to selected job.
        /// </summary>
        /// <param name="jobToDo"></param>
        /// <param name=shiftNumber"></param>
        /// <returns></returns>
        public string AssignWork(Job jobToDo, int value)
        {
            string report = "";
            if (queen.AssignWork(townHall, jobToDo, value))
            {
                report += ": znaleziono wolną pszczołę\n";
                AmountOfWorkersChanged();
            }
            else
                report += ": nie znaleziono wolnej pszczoły\n";
            return report;
        }
        /// <summary>
        /// It is a method which starts new shift and return report.
        /// </summary>
        /// <returns></returns>
        public string StartNextShift()
        {
            string report = "";
            report += queen.StartNewShift(warehouse);
            warehouse.GiveHoney(townHall);
            townHall.IncreaseThePopulation(queen.ShiftNumber);
            OnPropertyChanged("Honey");
            OnPropertyChanged("Nectar");
            AmountOfWorkersChanged();
            return report;
        }
        #endregion

        #region Methods - Operations on TownHall Model
        private bool CheckIsNectarCollector(Worker worker)
        {
            return (worker is NectarCollector) ? true : false;
        }
        private bool CheckIsNectarConverter(Worker worker)
        {
            return (worker is NectarConverter) ? true : false;
        }
        private void AmountOfWorkersChanged()
        {
            OnPropertyChanged("AllBees");
            OnPropertyChanged("AllCollectors");
            OnPropertyChanged("AllConverters");
            OnPropertyChanged("AllWorkers");
            OnPropertyChanged("FreeCollectors");
            OnPropertyChanged("FreeConverters");
            OnPropertyChanged("FreeWorkers");
        }
        #endregion

        #region Events
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler propertyChanged = PropertyChanged;
            if (propertyChanged != null)
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}