using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beehive
{
    /// <summary>
    /// DO ZROBIENIA: Do zrobienia prace zwiazane z miodem i nektarem, dayoff
    /// </summary>
    class Worker : Bee
    {
        //DAYOFF DZIALA, Nalezy dodac juz tylko informacje - alert ze pszczola bedzie na wolnym
        protected Random random = new Random();
        #region Job Attributs
        public Job CurrentJob { get; private set; }
        protected List<Job> JobsICanDo { get; }
        public int ShiftsLeft { get; private set; }
        private int shiftsWorked;
        public int ShiftsWorked
        {
            get { return shiftsWorked; }
            private set
            {
                if (shiftsWorked == 6)
                {
                    DayOff = !DayOff;
                    AdditionalHoneyConsumptionPerMg = 0;
                    shiftsWorked = 0;
                }                  
                else
                    shiftsWorked = value;
            }
        }
        public bool DayOff { get; private set; }
        public virtual double MaxNectarCapity { get; }
        protected double nectarMg;
        public virtual double NectarMg
        {
            get { return nectarMg; }
            protected set
            {
                if (nectarMg + value > MaxNectarCapity)
                    nectarMg = MaxNectarCapity;
                else
                    nectarMg = value;
            }
        }
        protected double honeyMg;
        protected virtual double HoneyMg{ get { return honeyMg; } set { honeyMg = value; } }
        #endregion

        #region Eating Attributs
        private double AdditionalHoneyConsumptionPerMg { get; set; }
        private double HoneyUnitsPerShiftsWorked { get; }
#endregion

        #region Constructors
        public Worker(int weightMg, List<Job> jobsICanDo) : this(weightMg)
        {
            JobsICanDo = jobsICanDo;
            JobsICanDo.Add(Job.Free);
            
        }
        protected Worker(int weightMg) :base(weightMg)
        {
            DayOff = false;
            ShiftsLeft = ShiftsWorked = 0;
            AdditionalHoneyConsumptionPerMg = 0;
            CurrentJob = Job.Free;
            HoneyUnitsPerShiftsWorked = 2.0;
            JobsICanDo = new List<Job>();
            MaxNectarCapity = 100;
        }
        #endregion

        #region Mechanics Of Bees Life
        public bool DoThisJob(Job jobToDo, int shifts)
        {  
            if(DayOff)
            {
                DayOff = !DayOff;
                return false;
            }
            if(CurrentJob != Job.Free)
            {
                return false;
            }

            foreach (Job job in JobsICanDo)
            {
                if (job == jobToDo)
                {
                    CurrentJob = jobToDo;
                    ShiftsLeft = shifts;
                    if (jobToDo == Job.Patrol || jobToDo == Job.CleaningBeehive ||
                        jobToDo == Job.TeachingBees)
                        AdditionalHoneyConsumptionPerMg = 0.1;
                    else
                        AdditionalHoneyConsumptionPerMg = 0;
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Jezeli pszczolka wlasnie skonczyla swoja prace zwraca true;
        /// </summary>
        /// <returns></returns>
        public bool WorkNextShift()
        {
            switch(CurrentJob)
            {
                case Job.NectarCollecting:
                    NectarMg = CollectNectar();
                    break;
                case Job.ProductionOfHoney:

                    break;
            }
            if (CurrentJob != Job.Free && !DayOff)
                ShiftsWorked++;
            if (ShiftsLeft > 0 && !DayOff)
                ShiftsLeft--;
            if (DayOff)
            {
                DayOff = !DayOff;
                ShiftsWorked = 0;
                return false;
            }
            else if (ShiftsLeft == 0 && CurrentJob != Job.Free)
            {
                CurrentJob = Job.Free;
                return true;
            }
            else if (ShiftsLeft == 0 && CurrentJob == Job.Free)
            {
                ShiftsWorked = 0;
                DayOff = false;
                return false;
            }
            
            return false;

        }
        public override double HoneyConsumptionRate()
        {
            double consumption = base.HoneyConsumptionRate();
            consumption += WeightMg * AdditionalHoneyConsumptionPerMg;
            consumption += HoneyUnitsPerShiftsWorked * ShiftsWorked;
            return consumption;
        }
        #endregion

        #region NectarCollecting
        protected virtual double CollectNectar()
        {
            double collectedNectar = random.Next(40, 101);
            return collectedNectar;
        }
        public virtual double ReturnNectar()
        {
            double amountOfNectar = NectarMg;
            NectarMg = 0;
            return amountOfNectar;
        }
        #endregion

        #region Production of Honey
        public double ConvertNectar(double amountOfNectar)
        {
            double convertedHoney = random.Next((int)MaxNectarCapity-30, (int) MaxNectarCapity + 1);
            return convertedHoney;
        }
        #endregion
    }
}
