using System;

namespace TrackEventsInsertion
{
    internal class TrackEvent
    {
        public string Localitykey { get; set; }
        public string Objectkey { get; set; }
        public string EventTime { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Floor { get; set; }
        public string DistanceMtr { get; set; }
        public string DistanceFloor { get; set; }
        public string DurationSec { get; set; }
        public string LocationSGLN { get; set; }
        public string Comments { get; set; }


    }
}