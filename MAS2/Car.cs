namespace MAS2
{
    public class Car : IDisposable
    {
        private static List<Wheel> AllWheels = new();


        public Company Company { get; private set; }
        public Brand Brand { get; private set; }
        private List<Wheel> Wheels { get; set; } = new();
        private List<Rent> Rents { get; set; } = new();
        public string Model { get; set; }
        public DateOnly ProductionDate { get; set; }

        public Car(string model, DateOnly productionDate)
        {
            Model = model;
            ProductionDate = productionDate;
        }

        public void Dispose()
        {
            foreach (var wheel in Wheels)
            {
                AllWheels.Remove(wheel);
                wheel.RemoveCar();
            }

            foreach (var rent in Rents)
            {
                RemoveRent(rent, true);
            }

            Brand.RemoveCar(this);
            Company.RemoveCar(this);
        }

        public void SetCompany(Company company)
        {
            Company = company;
            Company.AddCar(this);
        }

        public void RemoveCompany() => Company = null;

        public void AddMark(string VIN, Brand brand)
        {
            if (Brand == brand)
                return;

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
