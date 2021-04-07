using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightDetector
{
    class FooterViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private MyFooterModel model;
        public FooterViewModel(MyFooterModel model)
        {
            this.model = model;
            model.connect("127.0.0.1", 5400);
            model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e) {
                NotifyPropertyChanged("VM_" + e.PropertyName);
            };
        }
        private int playbackSpeed;
        public int VM_playbackSpeed
        {
            get { return playbackSpeed; }
            set
            {
                playbackSpeed = value;
                model.PlaybackSpeed= value;
            }
        }
        private Boolean play;
        public Boolean VM_play
        {
            get { return play; }
            set { 
                play = value;
                model.play();
            }
        }

        public int VM_NextLine
        {
            get { return model.NextLine; }
            set {
                model.nextLine = value;
            }
        }
        public void stopPlay()
        {
            model.stopPlay();
        }

        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
