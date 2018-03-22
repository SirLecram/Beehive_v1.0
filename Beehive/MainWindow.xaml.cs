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
        internal Queen Queen { get; private set; }
        internal TownHall TownHall { get; private set; }
        public MainWindow()
        {
            InitializeComponent();
            InitializeObjects();
            UpdateLabels();
        }

        public void UpdateLabels()
        {
            amountOfHoney.Text = "Zapasy miodu: " + TownHall.Warehouse.AmountOfHoney.ToString() + " mg.";
            amountOfNectar.Text = "Zapasy nektaru: " + TownHall.Warehouse.AmountOfNectar.ToString() + " mg.";
            aliveWorkers.Text = "Ilość pszczół robotnic: " + Building.NumberOfWorkers.ToString() + ".";
        }
        private void InitializeObjects()
        {
           // Warehouse = new Warehouse(2000);
            TownHall = new TownHall(2000);
            Queen = new Queen(300);
        }
        
        private void AssignWork_Click(object sender, RoutedEventArgs e)
        {
            Job actualJob = (Job)Enum.Parse(typeof(Job), workerBeeJob.SelectedIndex.ToString());
            if (Queen.AssignWork(TownHall, actualJob, shifts.Value))
                shiftsReports.Text += workerBeeJob.SelectionBoxItem.ToString() + ": znaleziono wolną pszczołę\n";
            else
                shiftsReports.Text += workerBeeJob.SelectionBoxItem.ToString() + ": nie znaleziono wolnej pszczoły\n";
        }
        
        private void StartShift_Click(object sender, RoutedEventArgs e)
        {
            shiftsReports.Text += Queen.StartNewShift(TownHall.Warehouse);
            TownHall.Warehouse.GiveHoney(TownHall);
            TownHall.IncreaseThePopulation(Queen.ShiftNumber);
            UpdateLabels();
        }

        private void TestButton_Click(object sender, RoutedEventArgs e)
        {
            TownHall.KillBee();
            UpdateLabels();
        }
    }
}
