using System.Collections.Generic;

namespace BloodbankCore
{
    public class DonorRepository
    {
        List<Donor> donors = new List<Donor>();

        public void AddDonor(Donor newDonor)
        {
            donors.Add(newDonor);
        }

        public Donor GetDonorById(int id)
        {
            foreach (var item in donors)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }

            return null;
        }
    }
}