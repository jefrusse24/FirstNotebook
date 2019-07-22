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

namespace HWEmulatorView2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        List<Cell> CellList = new List<Cell>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddCells()
        {
            Cell cell = new Cell()
            {
                Enabled = true,
                Customer = "Brooksville - Mebane",
                CellName = "AOB201",
                EnableLift = true,
                LiftCount = 5
            };
            CellList.Add(cell);
            cell = new Cell()
            {
                Enabled = true,
                Customer = "Brooksville - Mebane",
                CellName = "AOB202",
                EnableLift = true,
                LiftCount = 4
            };
            CellList.Add(cell);

            // Beth
            cell = new Cell()
            {
                Enabled = true,
                Customer = "CnS - Bethlehem",
                CellName = "AIB02_Level1",
                EnableLift = true,
                LiftCount = 4
            };
            CellList.Add(cell);
            cell = new Cell()
            {
                Enabled = true,
                Customer = "CnS - Bethlehem",
                CellName = "SAIB01A_Level4",
                EnableLift = true,
                LiftCount = 4
            };
            CellList.Add(cell);
            cell = new Cell()
            {
                Enabled = true,
                Customer = "CnS - Bethlehem",
                CellName = "SAIBO1B_Level4",
                EnableLift = true,
                LiftCount = 4
            };
            CellList.Add(cell);
            cell = new Cell()
            {
                Enabled = true,
                Customer = "CnS - Bethlehem",
                CellName = "AOB01_Level4",
                EnableLift = true,
                LiftCount = 4
            };
            CellList.Add(cell);
            cell = new Cell()
            {
                Enabled = true,
                Customer = "CnS - Bethlehem",
                CellName = "AOB02_Level4",
                EnableLift = true,
                LiftCount = 4
            };
            CellList.Add(cell);

        }



    }

    public class Cell
    {
        public bool Enabled { get; set; }
        public string Customer { get; set; }
        public string CellName { get; set; }
        public bool EnableLift { get; set; }
        public int LiftCount { get; set; }
    }
}
