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

    private async void button1_Click(object sender, EventArgs e)
        {
            for (int i = 4; i < 10; i++)
            {
                var trackEvent = new TrackEvent
                {
                    Localitykey = "CONNECTION OK",
                    Objectkey = "S00"
                };
                FirebaseResponse response = await client.SetTaskAsync("TrackEvents/" + i, trackEvent);
                TrackEvent result = response.ResultAs<TrackEvent>(); 
                Thread.Sleep(1000);
            }
    }
    }
}
