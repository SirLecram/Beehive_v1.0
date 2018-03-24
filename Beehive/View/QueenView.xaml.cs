using Beehive.ViewModel;
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


namespace Beehive.View
{
    /// <summary>
    /// Logika interakcji dla klasy QueenView.xaml
    /// </summary>
    public partial class QueenView : UserControl
    {
        public QueenView()
        {
            InitializeComponent();
            InitBinding();
        }
        private TextBox shiftsReports = null;
        private StatisticsVievModel statisticViewModel = new StatisticsVievModel();
        private void InitBinding()
        {
            gridDataContext.DataContext = statisticViewModel;
        }
        public void SetReportTextBox(TextBox textBox)
        {
            shiftsReports = textBox;
        }

        private void AssignWork_Click(object sender, RoutedEventArgs e)
        {
            Job actualJob = (Job)Enum.Parse(typeof(Job), workerBeeJob.SelectedIndex.ToString());
            shiftsReports.Text += workerBeeJob.SelectedIndex.ToString() +
                statisticViewModel.AssignWork(actualJob, shifts.Value);
        }

        private void StartShift_Click(object sender, RoutedEventArgs e)
        {
          /*  shiftsReports.Text += Queen.StartNewShift(TownHall.Warehouse);
            townHall.Warehouse.GiveHoney(TownHall);
            townHall.IncreaseThePopulation(Queen.ShiftNumber);
            UpdateLabels();*/
        }

        private void TestButton_Click(object sender, RoutedEventArgs e)
        {
          /*  townHall.KillBee();
            UpdateLabels();*/
        }
        public void UpdateLabels()
        {
           /* amountOfHoney.Text = "Zapasy miodu: " + TownHall.Warehouse.AmountOfHoney.ToString() + " mg.";
            amountOfNectar.Text = "Zapasy nektaru: " + TownHall.Warehouse.AmountOfNectar.ToString() + " mg.";
            aliveWorkers.Text = "Ilość pszczół robotnic: " + Building.NumberOfWorkers.ToString() + ".";*/
        }
    }
}
