using System;
using System.Linq;
using Windows.Networking;
using Windows.Networking.Connectivity;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace ShowIPAddr
{
    public sealed partial class MainPage : Page
    {
        DispatcherTimer timer;

        public MainPage()
        {
            this.InitializeComponent();

            // timer
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 3, 0); // 3sec
            timer.Tick += this.HandleTimer;
            timer.Start();

            UpdateIpAddr();
        }

        private void HandleTimer(object sender, object e)
        {
            UpdateIpAddr();
        }

        private void UpdateIpAddr()
        {
            string ipaddr = "";
            var infos = NetworkInformation.GetHostNames().Where((x) => x.Type == HostNameType.Ipv4);
            var count = infos.Count();
            var i = 0;
            foreach (var addr in infos) 
            {
                ipaddr += addr.DisplayName;
                if (i < count - 1)
                {
                    ipaddr += "\n";
                }
                i++;
            }
            this.ipaddress.Text = ipaddr;
        }
    }
}
