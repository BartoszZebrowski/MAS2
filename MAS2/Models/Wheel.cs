using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS2.Models
{
    public class Wheel
    {
        public int WheelDiameterInInch { get; set; } 
        private Car Car { get; set; }

        private Wheel(Car car, int wheelDiameterInInch) 
        {
            Car = car;
            WheelDiameterInInch = wheelDiameterInInch;
        }

        public static void AddWheelToCar(Car car, int wheelDiameterInInch)
        {
            if (car is null)
                throw new Exception("Car can't be null");

            var wheel = new Wheel(car, wheelDiameterInInch);    
            car.AddWheel(wheel);
        }
    }
}
