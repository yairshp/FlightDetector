using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FlightDetector;

namespace FlightDetector
{
    class MyFooterModel: IFooterModel
    {
        IClient client;
        string[] lines;
        volatile Boolean stop;
        double csvNumOfLine;
        Boolean hasDone = false;
        public event PropertyChangedEventHandler PropertyChanged;
        public int nextLine;
        public int NextLine
        {
            get { return nextLine; }
            set { 
                nextLine = value;
                NotifyPropertyChanged("nextLine");
            }
        }

        private int playbackSpeed;
        public int PlaybackSpeed
        {
            get { return playbackSpeed; }
            set
            {
                playbackSpeed = value;
            }
        }

        public MyFooterModel(IClient Client)
        {
            this.client = Client;
            this.playbackSpeed = 100;
            stop = false;
            CsvParser csvParser = new CsvParser();
            lines = csvParser.GetCsvLines("reg_flight.csv");
            csvNumOfLine = lines.Length;
            nextLine = 0;
        }


        public void start()
        {   
            new Thread(delegate () {
                // Read the file and display it line by line.  
                while ((nextLine < csvNumOfLine) && !stop)
                   {
                    if (nextLine < csvNumOfLine) {
                        client.write(lines[nextLine]);
                    }

                        Thread.Sleep(playbackSpeed);
                        NextLine++;
                }
            }).Start();
        }

        public void play()
        {
            stop = false;
            this.start();
        }


        public void connect(string ip, int port)
        {
            client.connect(ip, port);
        }
        public void stopPlay()
        {
            stop = true;
        }
        public void disconnect()
        {
            client.disconnect();
        }
        public Boolean getHasDone()
        {
            return hasDone;
        }

        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

    }
}
