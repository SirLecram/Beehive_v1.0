using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Beehive.ViewModel;

namespace Beehive.View
{
    /// <summary>
    /// Logika interakcji dla klasy TownHallView.xaml
    /// </summary>
    public partial class TownHallView : UserControl
    {
        private StatisticsViewModel statisticsViewModel = null;
        public TownHallView()
        {
            InitializeComponent();
        }

        private void InitBinding()
        {
            statistics.DataContext = statisticsViewModel;
        }
        public void SetStatisticsVeiwModel(QueenView queen)
        {
            statisticsViewModel = queen.statisticViewModel;
            InitBinding();
        }
    }
}
