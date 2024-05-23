namespace MAS2
{
    public class Customer : IDisposable
    {
        public string FullName { get; set; }
        private List<Rent> Rents { get; set; } = new();

        public Customer(string fullName)
        {
            FullName = fullName;
        }

        public void Dispose()
        {
            foreach (var rent in Rents)
            {
                RemoveRent(rent, true);
            }
        }

        public void AddCarRent(Car car, int days) => new Rent(this, car, DateTime.Now, DateTime.Now.AddDays(days));
        public void AddRent(Rent rent) => Rents.Add(rent);
        public IReadOnlyCollection<Rent> GetRents() => Rents;
        public IReadOnlyCollection<Car> GetCars() => Rents.Select(rent => rent.Car).ToList();

        public void RemoveRent(Rent rent, bool twoSide = true)
        {
            if (twoSide)
                rent.Delete();
            else
                Rents.Remove(rent);
        }

    }
}
