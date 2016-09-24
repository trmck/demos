using System;
using System.Collections.Generic;
using System.ComponentModel;
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

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace VisitorCheckIn
{
    public partial class VirtualKeyboard : UserControl, INotifyPropertyChanged
    {
        private bool _showNumericKeyboard = false;

        public event PropertyChangedEventHandler PropertyChanged;

        public bool ShowNumericKeyboard
        {
            get
            {
                return _showNumericKeyboard;
            }

            set
            {
                _showNumericKeyboard = value; this.OnPropertyChanged("ShowNumericKeyboard");
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                this.PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }

        public VirtualKeyboard()
        {
            this.InitializeComponent();
            DataContext = this;
        }


    }
}
