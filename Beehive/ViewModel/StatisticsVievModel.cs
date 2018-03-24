using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Beehive.Model;

namespace Beehive.ViewModel
{
    class StatisticsVievModel //: INotifyPropertyChanged
    {
        private Queen queen = new Queen(300);
        private TownHall townHall = new TownHall(2000);

        public string AssignWork(Job jobToDo, int value)
        {
            string report = "";
            if (queen.AssignWork(townHall, jobToDo, value))
                report += ": znaleziono wolną pszczołę\n";
            else
                report += ": nie znaleziono wolnej pszczoły\n";
            return report;
        }
        
    }
}
