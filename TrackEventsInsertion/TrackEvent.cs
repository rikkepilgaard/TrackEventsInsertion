using System;

namespace TrackEventsInsertion
{
    internal class TrackEvent
    {
        public string localitykey { get; set; }
        public string objectkey { get; set; }
        public string eventTime { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string floor { get; set; }
        public string distanceMtr { get; set; }
        public string distanceFloor { get; set; }
        public string durationSec { get; set; }
        public string locationSgln { get; set; }
        public string comments { get; set; }


    }
}