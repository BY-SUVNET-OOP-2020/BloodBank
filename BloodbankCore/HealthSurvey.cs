using System;
using System.Collections.Generic;

namespace BloodbankCore
{
    public class HealthSurvey
    {
        public int ID { get; set; }
        public DateTime LastUpdated { get; set; }
        public Dictionary<string, string> questions;

        //Vi behöver att sätt att kolla om en hälsoundersökning
        //är valid och en donation får utföras. Här får mer kod läggas till för en sådan check!
        public bool IsValid { get { return true; } }
    }
}