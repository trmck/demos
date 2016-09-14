using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace VehicleGateway
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private const int TIME_UNIT_SEC = 1000;

        private int _tickCount = 0;
        DispatcherTimer _sendTimer;

        public MainPage()
        {
            this.InitializeComponent();

            StartTimer();
        }

        private void StartTimer()
        {
            if(_sendTimer == null)
            {
                _sendTimer = new DispatcherTimer();
                _sendTimer.Interval = TimeSpan.FromSeconds(1);
                _sendTimer.Tick += OnSendTimer_Tick;
            }

            if (!_sendTimer.IsEnabled)
            {
                _sendTimer.Start();
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Timer is already running. StartTimer action will be ignored.");
            }
        }


        private void StopTimer()
        {
            if (_sendTimer.IsEnabled)
            {
                _sendTimer.Stop();
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Timer is not running. StopTimer action will be ignored.");
            }
        }

        private void OnSendTimer_Tick(object sender, object e)
        {
            _tickCount++;
            UpdateUploadTimerUI(_tickCount);
        }

        private void UpdateUploadTimerUI(int tick)
        {
            int _remainingTime = 30 - (tick % 31);
            string _countDown = String.Format("00:00:{0:00}", _remainingTime);
            textCountdownTimer.Text = _countDown;
            if(_remainingTime == 0)
            {
                textLastUpload.Text = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
            }
        }
    }
}
