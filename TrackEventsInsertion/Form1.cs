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
using FireSharp.Exceptions;
using FireSharp.Interfaces;
using FireSharp.Response;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.FileIO;
using Newtonsoft.Json;

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
            start200insertion();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            run = true;
            startContinousInsertion();
        }

        
        private string trackGLN;
        
 

        public async void start200insertion()
        {
            
            string path = @"C:\Users\rikke\Dropbox\Bachelorprojekt\Data\rapport2.csv";
            using (TextFieldParser csvParser = new TextFieldParser(path))
            {
                csvParser.CommentTokens = new string[] { "#" };
                csvParser.SetDelimiters(new string[] { ";" });
                csvParser.HasFieldsEnclosedInQuotes = true;
                csvParser.ReadLine();

                for (int i = 0; i < 200; i++)
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
                    
                    FirebaseResponse getresponse = await client.GetTaskAsync("TrackEvents/" + trackEvent.objectkey);

                    if (getresponse.Body!="null")
                    {
                        
                        String jsonResponse = getresponse.Body;

                        dynamic array = JsonConvert.DeserializeObject(jsonResponse);
                        List<String> timestamp = new List<string>();

                        foreach (var var in array)
                        {
                            String time = var.Name;
                            timestamp.Add(time);

                        }

                        if (timestamp.Count < 2)
                        {
                            FirebaseResponse response = await client.SetTaskAsync(
                                "TrackEvents/" + trackEvent.objectkey + "/" + trackEvent.eventTime, trackEvent);
                        }
                        else
                        {
                            FirebaseResponse deleteTask =
                                await client.DeleteTaskAsync(
                                    "TrackEvents/" + trackEvent.objectkey + "/" + timestamp[0]);
                            FirebaseResponse response = await client.SetTaskAsync(
                                "TrackEvents/" + trackEvent.objectkey + "/" + trackEvent.eventTime, trackEvent);
                        }
                    }
                    else
                    {
                        FirebaseResponse response = await client.SetTaskAsync(
                            "TrackEvents/" + trackEvent.objectkey + "/" + trackEvent.eventTime, trackEvent);
                    }
                }
                
            }
        }

        
            
        public async void startContinousInsertion()
        {
        int count = 201;
        string path = @"C:\Users\rikke\Dropbox\Bachelorprojekt\Data\rapport2.csv";
            using (TextFieldParser csvParser = new TextFieldParser(path))
            {
                csvParser.CommentTokens = new string[] { "#" };
                csvParser.SetDelimiters(new string[] { ";" });
                csvParser.HasFieldsEnclosedInQuotes = true;
                for (int i = 0; i < count; i++)
                {
                    csvParser.ReadLine();
                }
                
                while (!csvParser.EndOfData&& run.Equals(true)) { 
                        string[] fields = csvParser.ReadFields();
                    count++;

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

                FirebaseResponse getresponse = await client.GetTaskAsync("TrackEvents/" + trackEvent.objectkey);

                if (getresponse.Body != "null")
                {

                    String jsonResponse = getresponse.Body;

                    dynamic array = JsonConvert.DeserializeObject(jsonResponse);
                    List<String> timestamp = new List<string>();

                    foreach (var var in array)
                    {
                        String time = var.Name;
                        timestamp.Add(time);

                    }

                    if (timestamp.Count < 2)
                    {
                        FirebaseResponse response = await client.SetTaskAsync(
                            "TrackEvents/" + trackEvent.objectkey + "/" + trackEvent.eventTime, trackEvent);
                    }
                    else
                    {
                        FirebaseResponse deleteTask =
                            await client.DeleteTaskAsync(
                                "TrackEvents/" + trackEvent.objectkey + "/" + timestamp[0]);
                        FirebaseResponse response = await client.SetTaskAsync(
                            "TrackEvents/" + trackEvent.objectkey + "/" + trackEvent.eventTime, trackEvent);
                    }
                }
                else
                {
                    FirebaseResponse response = await client.SetTaskAsync(
                        "TrackEvents/" + trackEvent.objectkey + "/" + trackEvent.eventTime, trackEvent);
                }
            }
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            run = false;
            
        }
    }


    }

