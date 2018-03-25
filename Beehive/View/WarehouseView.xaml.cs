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
    /// Logika interakcji dla klasy WarehouseView.xaml
    /// </summary>
    public partial class WarehouseView : UserControl
    {
        private StatisticsViewModel statisticsViewModel = null;

        public WarehouseView()
        {
            InitializeComponent();
        }

        private void InitBinding()
        {
            statistics.DataContext = statisticsViewModel;
        }
        public void SetStatisticViewModel(QueenView queenView)
        {
            statisticsViewModel = queenView.statisticViewModel;
            InitBinding();
        }
    }
}
