using FlightDetector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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

namespace FlightDetector
{
    /// <summary>
    /// Interaction logic for Footer.xaml
    /// </summary>
    public partial class FooterView : UserControl
    {
        FooterViewModel vm;
        public FooterView()
        {
            InitializeComponent();
            vm = new FooterViewModel(new MyFooterModel(new Client()));
            DataContext = vm;
            vm.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
            {
            };
            ComboBox speeds = new ComboBox();
        }

        private void playButton_Click(object sender, RoutedEventArgs e)
        {
            vm.VM_play = true;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Handle();

        }
        private void Handle()
        {
           
            switch (speeds.SelectedItem.ToString().Split(new string[] { ": " }, StringSplitOptions.None).Last())
            {
                case "0.25":
                    vm.VM_playbackSpeed = 400;
                    break;
                case "0.5":
                    vm.VM_playbackSpeed = 200;
                    break;
                case "0.75":
                    vm.VM_playbackSpeed = 133;
                    break;
                case "Normal":
                    vm.VM_playbackSpeed = 100;
                    break;
                case "1.25":
                    vm.VM_playbackSpeed = 80;
                    break;
                case "1.5":
                    vm.VM_playbackSpeed = 66;
                    break;
                case "1.75":
                    vm.VM_playbackSpeed = 57;
                    break;
                case "2":
                    vm.VM_playbackSpeed = 50;
                    break;
            }
        }

        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            vm.VM_NextLine = Convert.ToInt32(slider.Value.ToString());
        }

        private void stopButton_Click_1(object sender, RoutedEventArgs e)
        {
            vm.stopPlay();
        }

        private void skipToTheEndButton_Click(object sender, RoutedEventArgs e)
        {
        }

        private void skipToTheStartButton_Click(object sender, RoutedEventArgs e)
        {
            vm.VM_NextLine = 0;
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void fastForwardButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
