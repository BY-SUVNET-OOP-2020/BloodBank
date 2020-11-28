using System;
using System.Collections.Generic;

namespace BloodbankCore
{
    public class HealthSurvey
    {
        public int ID { get; set; }
        public DateTime LastUpdated { get; set; }
        public Dictionary<string, string> questions;
    }
}