using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;

using Microsoft.VisualBasic.FileIO;

namespace TrackEventsInsertion
{
    public partial class Form1 : Form
    {
        private IFirebaseClient client;
        public Form1()
        {
            InitializeComponent();
            IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "T0XRAsmHpuOIABRQNUUmiLGv7miw5rmXBgoJt5Y2",
            BasePath = "https://test-43981.firebaseio.com/"
        };
            client = new FireSharp.FirebaseClient(config);
            if (client != null)
            {
                Console.WriteLine("Connection ÓK");

            }
        }

        public bool run = false;

        private void button1_Click(object sender, EventArgs e)
        {
            run = true;
            startinsertion();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            run = false;
        }



        public async void startinsertion()
        {
            int count = 0;
            string path = @"C:\Users\rikke\Dropbox\Bachelorprojekt\Data\rapport2.csv";
            using (TextFieldParser csvParser = new TextFieldParser(path))
            {
                csvParser.CommentTokens = new string[] { "#" };
                csvParser.SetDelimiters(new string[] { ";" });
                csvParser.HasFieldsEnclosedInQuotes = true;
                csvParser.ReadLine();
                while (run.Equals(true))
                {

                    //    while (!csvParser.EndOfData&& run.Equals(true))
                    //{
                    // Skip the row with the column names

                    // Read current line fields, pointer moves to the next line.
                    for (int i = 0; i < 10; i++)
                    {
                    
                        string[] fields = csvParser.ReadFields();

                        var trackEvent = new TrackEvent
                        {
                            Localitykey = fields[0],
                            Objectkey = fields[1],
                            EventTime = fields[2],
                            Latitude = fields[3],
                            Longitude = fields[4],
                            Floor = fields[5],
                            DistanceMtr = fields[6],
                            DistanceFloor = fields[7],
                            DurationSec = fields[8],
                            LocationSGLN = fields[9],
                            Comments = fields[10]
                        };

                        FirebaseResponse response = await client.SetTaskAsync("TrackEvents/" + i, trackEvent);
                        TrackEvent result = response.ResultAs<TrackEvent>();
                        Thread.Sleep(2000);
                       
                            //}
                            //string[] fields = csvParser.ReadFields();

                            //var trackEvent = new TrackEvent
                            //{
                            //    Localitykey = fields[0],
                            //    Objectkey = fields[1],
                            //    EventTime = fields[2],
                            //    Latitude = fields[3],
                            //    Longitude = fields[4],
                            //    Floor = fields[5],
                            //    DistanceMtr = fields[6],
                            //    DistanceFloor = fields[7],
                            //    DurationSec = fields[8],
                            //    LocationSGLN = fields[9],
                            //    Comments = fields[10]
                            //};

                            //FirebaseResponse response = await client.SetTaskAsync("TrackEvents/" + count, trackEvent);
                            //TrackEvent result = response.ResultAs<TrackEvent>();
                            //Thread.Sleep(2000);
                            //count++;
                            }
                        }
                
                
            }
        }

    }
}
