using DatabaseEntities;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
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
using System.Windows.Shapes;
using TCPConnectionAPIClientModule_C_sharp_;

namespace UserApp_.NET_Framework_
{
    /// <summary>
    /// Логика взаимодействия для Diagram.xaml
    /// </summary>
    public partial class Diagram : Window
    {
        public Func<ChartPoint, string> PointLabel { get; set; }
        List<Vehicle> vehicles;
        private IAdminAccess module;
        public SeriesCollection SeriesCollection { get; set; }
        public Diagram(IAdminAccess module)
        {
            this.module = module;
            vehicles = module.GetAllVehicles();
            InitializeComponent();
            if (vehicles.Count == 0)
            {
                MessageBox.Show("Нет данных!");
            }
            else
            {
                List<string> existingDealers = new List<string>();
                SeriesCollection = new SeriesCollection();
                foreach (var item in vehicles)
                {
                    if (!existingDealers.Contains(item.Dealer))
                    {
                        var countrySeries = new PieSeries
                        {
                            Title = item.Dealer,
                            Values = new ChartValues<ObservableValue> { new ObservableValue(vehicles.FindAll(c => c.Dealer == item.Dealer).Count) },
                            DataLabels = true
                        };
                        SeriesCollection.Add(countrySeries);
                    }
                    existingDealers.Add(item.Dealer);
                }
                DataContext = this;
            }
            PointLabel = chartPoint => string.Format("{0}({1:p})", chartPoint.Y, chartPoint.Participation);
            DataContext = this;
            Chart.Update(true, true);
        }
        private void pipChart_DataClick(object sender, LiveCharts.ChartPoint chartPoint)
        {
            var chart = (LiveCharts.Wpf.PieChart)chartPoint.ChartView;


            //clear selected slice
            foreach (PieSeries series in chart.Series)
            {
                series.PushOut = 0;

                var selectedSeries = (PieSeries)chartPoint.SeriesView;
                selectedSeries.PushOut = 8;
            }

        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}


