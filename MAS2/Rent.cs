namespace MAS2
{
    public class Rent
    {
        public Customer Customer { get; private set; }
        public Car Car { get; private set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }

        public Rent(Customer customer, Car car, DateTime dateFrom, DateTime dateTo)
        {
            DateFrom = dateFrom;
            DateTo = dateTo;

            Customer = customer;
            Customer.AddRent(this);

            Car = car;
            Car.AddRent(this);
        }

        public void Delete()
        {
            Car.RemoveRent(this, false);
            Customer.RemoveRent(this, false);
        }
    }
}
