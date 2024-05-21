namespace MAS2.Models
{
    public class Car : IDisposable
    {
        private static List<Wheel> AllWheels = new();

        public Brand Brand { get; private set; } // assocjacja kwalifikowana po numerze VIN (tyko z drugiej strony)
        private List<Wheel> Wheels { get; set; } = new(); // kompozycja
        private List<Rent> Rents { get; set; } = new();// assocjacja z atrybutem
        private string Model { get; set; }
        private DateOnly ProductionDate { get; set; }

        public Car(string model, DateOnly productionDate)
        {
            Model = model;
            ProductionDate = productionDate;
        }

        public void Dispose()
        {
            foreach (var wheel in Wheels)
                AllWheels.Remove(wheel);
        }

        public void AddMark(string VIN, Brand brand)
        {
            Brand = brand;
            brand.AddCar(VIN, this);
        }

        public void AddRentByCustomer(Customer customer, int days) => new Rent(customer, this, DateTime.Now, DateTime.Now.AddDays(days));
        public void AddRent(Rent rent) => Rents.Add(rent);

        public void AddWheel(Wheel wheel)
        {
            if (Wheels.Contains(wheel))
                throw new Exception("You can't set the same wheel two times");

            if (AllWheels.Contains(wheel))
                throw new Exception("This wheel is connected with other Car");

            Wheels.Add(wheel);
            AllWheels.Add(wheel);
        }

        public IReadOnlyCollection<Wheel> GetWheels() => Wheels.AsReadOnly();
        public IReadOnlyCollection<Rent> GetRents() => Rents.AsReadOnly();
        public IReadOnlyCollection<Customer> GetCustomers() => Rents.Select(rent => rent.Customer).ToList().AsReadOnly();
        public void RemoveWheel(Wheel wheel)
        {
            Wheels.Remove(wheel);
            AllWheels.Remove(wheel);
        }

        public void RemoveBrand() => Brand = null;
        public void RemoveRent(Rent rent, bool twoSide = true)
        {
            if (twoSide)
                rent.Delete();
            else
                Rents.Remove(rent);
        }
    }
}
