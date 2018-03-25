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


namespace Beehive
{
    /// <summary>
    /// 
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeObjects();
        }

        private void InitializeObjects()
        {
            queenView.SetReportTextBox(shiftsReports);
            warehouseView.SetStatisticViewModel(queenView);
            townHallView.SetStatisticsVeiwModel(queenView);
        }
        
    }
}
