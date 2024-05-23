namespace MAS2
{
    public class Brand : IDisposable
    {
        private Dictionary<string, Car> Cars { get; set; } = new ();
        public string Name { get; set; }
        public string Country { get; set; }

        public Brand(string name, string country)
        {
            Name = name;
            Country = country;
        }

        public void AddCar(string VIN, Car car)
        {
            if (Cars.ContainsKey(VIN))
                if (Cars[VIN] == car)
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

        public Car GetCarByVin(string VIN)
        {
            Cars.TryGetValue(VIN, out var car);
            return car;
        }

        public void Dispose()
        {
            foreach (var car in Cars.Values)
            {
                car.RemoveBrand();
            }
        }
    }
}
