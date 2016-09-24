using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Networking.Connectivity;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace VisitorCheckIn
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private DispatcherTimer _networkTimer;

        public MainPage()
        {
            this.InitializeComponent();
            GetLocalIPAddress();

            StartNetworkTimer();
        }

        private void StartNetworkTimer()
        {
            if(_networkTimer == null)
            {
                _networkTimer = new DispatcherTimer();
                _networkTimer.Interval = TimeSpan.FromSeconds(10);
                _networkTimer.Tick += _networkTimer_Tick;
            }

            if(!_networkTimer.IsEnabled)
                _networkTimer.Start();
        }

        private void _networkTimer_Tick(object sender, object e)
        {
            GetLocalIPAddress();
        }

        private void GetLocalIPAddress()
        {
            var deviceInfo = new Windows.Security.ExchangeActiveSyncProvisioning.EasClientDeviceInformation();
            var deviceName = deviceInfo.FriendlyName;

            var icp = NetworkInformation.GetInternetConnectionProfile();

            if (icp?.NetworkAdapter == null)
            {
                textDeviecIp.Text = "Hostname: " + deviceName + " IPv4: Not Connected";
            }
            else
            {
                var hostnames = NetworkInformation.GetHostNames();
                foreach (var hn in hostnames)
                {
                    if (hn.IPInformation == null)
                        continue;

                    var _netAdapter = hn.IPInformation.NetworkAdapter;
                    var _netAdapterId = hn.IPInformation.NetworkAdapter.NetworkAdapterId;

                    if (_netAdapter != null && _netAdapterId == icp.NetworkAdapter.NetworkAdapterId)
                    {
                        var hostname = hn;
                        textDeviecIp.Text = "Hostname: " + deviceName + " IPv4:" + hostname?.CanonicalName;
                    }
                }
            }
        }
    }
}
