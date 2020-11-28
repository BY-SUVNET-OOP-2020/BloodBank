using System;

namespace BloodbankCore
{
    public class BloodDonation
    {
        public int ID { get; set; }
        public int PatientID { get; set; }
        public DateTime DonationDate { get; set; }
        public float Amount { get; set; }
        public BloodType BloodType { get; set; }
    }
}