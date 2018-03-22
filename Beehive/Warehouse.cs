using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beehive
{
    /// <summary>
    /// Class responsible for imitating a Warehouse. In warehouse is stored honey and nectar.
    /// It also contains methods responsible for eating and honey converting.
    /// </summary>
    class Warehouse : Building
    {
        public double AmountOfHoney { get; private set; }
        public double AmountOfNectar { get; private set; }
        
        #region Constructors
        public Warehouse(List<Worker> workersList, double amountOfHoney) :this(amountOfHoney)
        {
            WorkersList = workersList;
        }
        public Warehouse(double amountOfHoney) : base()
        {
            AmountOfNectar = 0;
            AmountOfHoney = amountOfHoney;
        }
        #endregion

        #region Methods - hungry and eating
        private void StarvationDeaths(TownHall townHall)
        {
            int howManyBeesToKill = random.Next(1, 4);
            for (int i = 0; i <= howManyBeesToKill; i++)
            {
                townHall.KillBee();
            }
        }
        private bool GetHoney(double amount)
        {
            if (AmountOfHoney >= amount)
            {
                AmountOfHoney -= amount;
                return true;
            }
            else
                return false;
        }
        
        public void GiveHoney(TownHall townHall)
        {
            for(int i = 0; i<NumberOfWorkers; i++)
            {
                double neededHoney = WorkersList.ElementAt(i).HoneyConsumptionRate();
                if(!GetHoney(neededHoney))
                {
                    StarvationDeaths(townHall);
                    break;
                }
            }
        }
        #endregion

        #region Methods - warehouse and honey production
        public void StoreNectar(double amount)
        {
            AmountOfNectar += amount;
        }
        public void MakeHoneyFromNectar(Worker nectarConverter)
        {
            double maxAmountOfNectar = nectarConverter.MaxNectarCapity;
            if(AmountOfNectar>maxAmountOfNectar)
            {
                double returnedHoney = nectarConverter.ConvertNectar(maxAmountOfNectar);
                AmountOfNectar -= maxAmountOfNectar;
                AmountOfHoney += returnedHoney;
            }
        }
        #endregion
    }
}
