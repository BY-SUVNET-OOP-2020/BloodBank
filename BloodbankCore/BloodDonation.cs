using System;

namespace BloodbankCore
{
    public class BloodDonation
    {
        public int Id { get; set; }
        public int DonorId { get; set; }
        public DateTime DonationDate { get; private set; }
        public int AmountInMl { get; set; }

        public BloodDonation(int donorId)
        {
            DonorId = donorId;
            DonationDate = DateTime.Now;
        }
    }
}