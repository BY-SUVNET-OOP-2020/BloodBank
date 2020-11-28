using System.Collections.Generic;

namespace BloodbankCore
{
    public class BloodDonationRepository
    {
        List<BloodDonation> bloodDonations;

        public void AddBloodDonation(BloodDonation donation)
        {
            bloodDonations.Add(donation);
        }

        public void RemoveBloodOfType(BloodType type, int units)
        {

        }

        public float GetAmountOfBloodType(BloodType type)
        {
            return 0;
        }
    }
}