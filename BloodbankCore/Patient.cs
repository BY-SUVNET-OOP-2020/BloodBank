using System;

namespace BloodbankCore
{
    public class Patient
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public HealthSurvey HealthSurvey { get; set; }
        public BloodType BloodType { get; set; }
    }
}