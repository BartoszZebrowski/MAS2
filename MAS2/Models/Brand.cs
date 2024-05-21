using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS2.Models
{
    public class Brand
    {
        private Dictionary<string, Car> Cars { get; set; } = new (); // asocjacja z kwalifikatorem po numerze VIN samochodu
        public string Name { get; set; }
        public string Country { get; set; }

        public Brand(string name, string country)
        {
            Name = name;
            Country = country;
        }

        public void AddCar(string VIN, Car car)
        {
            if (Cars.ContainsKey(VIN) || Cars[VIN] == car)
                throw new Exception("Ten VIN z samochodem juz istnieje");

            Cars.Add(VIN, car);
        }

        public IEnumerable<Car> GetCars() => Cars.Values.ToList();

        public void RemoveCar(Car car)
        {
            var key = Cars.FirstOrDefault(pair => pair.Value == car).Key;

            if (key is not null)
                Cars.Remove(key);
        }

    }
}
