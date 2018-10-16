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

        //public bool run = false;

        private void button1_Click(object sender, EventArgs e)
        {
            //run = true;
            start200insertion();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //run = false;
            startMinuteInsertion();
        }

        int count = 0;
        private string trackGLN;
        public async void insertPerId()
        {
            string path1 = @"C:\Users\rikke\Dropbox\Bachelorprojekt\Data\rapport21.csv";
            using (TextFieldParser csvParser = new TextFieldParser(path1))
            {
                csvParser.CommentTokens = new string[] {"#"};
                csvParser.SetDelimiters(new string[] {";"});
                csvParser.HasFieldsEnclosedInQuotes = true;
                csvParser.ReadLine();
                for (int i = 0; i < 100; i++)
                {
                    string[] fields = csvParser.ReadFields();

                    var trackEvent = new TrackEvent
                    {
                        localitykey = fields[0],
                        objectkey = fields[1],
                        eventTime = fields[2],
                        latitude = fields[3],
                        longitude = fields[4],
                        floor = fields[5],
                        distanceMtr = fields[6],
                        distanceFloor = fields[7],
                        durationSec = fields[8],
                        locationSgln = fields[9],
                        comments = fields[10]
                    };

                    trackGLN = trackEvent.locationSgln.Replace(".", "-");

                    FirebaseResponse response = await client.SetTaskAsync("TrackEvents/" + trackEvent.objectkey+"/"+trackEvent.eventTime+"/"+trackGLN, trackEvent);
                    
                    
                    TrackEvent result = response.ResultAs<TrackEvent>();
                }
            }
        }


















        public async void start200insertion()
        {
            
            string path = @"C:\Users\rikke\Dropbox\Bachelorprojekt\Data\rapport2.csv";
            using (TextFieldParser csvParser = new TextFieldParser(path))
            {
                csvParser.CommentTokens = new string[] { "#" };
                csvParser.SetDelimiters(new string[] { ";" });
                csvParser.HasFieldsEnclosedInQuotes = true;
                csvParser.ReadLine();
                
                    //    while (!csvParser.EndOfData&& run.Equals(true))
               
                    // Read current line fields, pointer moves to the next line.
                    for (int i = 0; i < 199; i++)
                    {                   
                        string[] fields = csvParser.ReadFields();

                        var trackEvent = new TrackEvent
                        {
                            localitykey = fields[0],
                            objectkey = fields[1],
                            eventTime = fields[2],
                            latitude = fields[3],
                            longitude = fields[4],
                            floor = fields[5],
                            distanceMtr = fields[6],
                            distanceFloor = fields[7],
                            durationSec = fields[8],
                            locationSgln = fields[9],
                            comments = fields[10]
                        };

                        FirebaseResponse response = await client.SetTaskAsync("TrackEvents/" + count, trackEvent);
                        count++;
                        TrackEvent result = response.ResultAs<TrackEvent>();                        
                            }
                        }
                
                
            }
        public async void startMinuteInsertion()
        {
            
            string path = @"C:\Users\rikke\Dropbox\Bachelorprojekt\Data\rapport2.csv";
            using (TextFieldParser csvParser = new TextFieldParser(path))
            {
                csvParser.CommentTokens = new string[] { "#" };
                csvParser.SetDelimiters(new string[] { ";" });
                csvParser.HasFieldsEnclosedInQuotes = true;
                csvParser.ReadLine();

                //    while (!csvParser.EndOfData&& run.Equals(true))

                // Read current line fields, pointer moves to the next line.
                for (int i = 0; i < 100; i++)
                {
                    string[] fields = csvParser.ReadFields();

                    var trackEvent = new TrackEvent
                    {
                        localitykey = fields[0],
                        objectkey = fields[1],
                        eventTime = fields[2],
                        latitude = fields[3],
                        longitude = fields[4],
                        floor = fields[5],
                        distanceMtr = fields[6],
                        distanceFloor = fields[7],
                        durationSec = fields[8],
                        locationSgln = fields[9],
                        comments = fields[10]
                    };

                    FirebaseResponse response = await client.SetTaskAsync("TrackEvents/" + count, trackEvent);
                    TrackEvent result = response.ResultAs<TrackEvent>();
                    count++;
                    Thread.Sleep(1000);
                }
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            insertPerId();
        }
    }


    }

