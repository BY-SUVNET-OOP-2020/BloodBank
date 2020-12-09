using System;

namespace BloodbankCore
{
    public class Donor
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public HealthSurvey HealthSurvey { get; set; }
        public BloodType BloodType { get; set; }

        public Donor()
        {
            //Se till så att en health survey altid skapas när en
            //ny donator skapas
            HealthSurvey = new HealthSurvey();
        }
    }
}