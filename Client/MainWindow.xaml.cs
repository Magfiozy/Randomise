using System;
using System.Net.Http;
using System.Windows;
using System.Windows.Threading;

namespace Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            SetRandomNumber();
        }


        private async void SetRandomNumber()
        {
            HttpClient client = new HttpClient();
            double resultNumber = 0;

            await client.GetAsync(@"http://localhost:10823/api/randomNumbers")
                .ContinueWith(response =>
                {
                    if (response.Exception != null)
                    {
                        MessageBox.Show(response.Exception.Message);
                    }
                    else
                    {
                        HttpResponseMessage message = response.Result;

                        Double.TryParse(message.Content.ReadAsStringAsync().Result, out resultNumber);
                    }
                });

            slValue.Value = resultNumber;
            labelValue.Content = resultNumber.ToString();
        }
    }
}
