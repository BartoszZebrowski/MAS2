using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS2.Models
{
    public class Customer
    {
        public string FullName { get; set; }
        private List<Rent> Rents { get; set; } = new();

        public Customer(string fullName)
        {
            FullName = fullName;
        }

        public void AddCarRent(Car car, int days) => new Rent(this, car, DateTime.Now, DateTime.Now.AddDays(days));
        public void AddRent(Rent rent) => Rents.Add(rent);
        public IEnumerable<Rent> GetRents() => Rents;
        public IEnumerable<Car> GetCars() => Rents.Select(rent => rent.Car);

        public void RemoveRent(Rent rent, bool twoSide = true)
        {
            if (twoSide)
                rent.Delete();
            else
                Rents.Remove(rent);
        }
    }
}
