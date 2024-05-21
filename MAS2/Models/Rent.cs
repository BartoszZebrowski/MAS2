using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS2.Models
{
    public class Rent
    {
        public Customer Customer { get; set; }
        public Car Car { get; set; }
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
