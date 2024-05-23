using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS2
{
    public class Company : IDisposable
    {
        private List<Car> Cars { get; set; } = new();
        public string Name { get; set; }

        public Company(string name)
        {
            Name = name;
        }

        public void AddCar(Car car)
        {
            if (Cars.Contains(car))
                return;

            Cars.Add(car);
            car.SetCompany(this);
        }
        public void RemoveCar(Car car) => Cars.Remove(car);

        public IReadOnlyCollection<Car> GetCars() => Cars;

        public void Dispose()
        {
            foreach (var car in Cars)
            {
                car.RemoveCompany();
            }
        }
    }
}
