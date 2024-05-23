namespace MAS2
{
    public class Wheel
    {
        public int Size { get; set; } 
        public Car Car { get; private set; }

        private Wheel(Car car, int wheelDiameterInInch) 
        {
            Car = car;
            Size = wheelDiameterInInch;
        }

        public static void AddWheelToCar(Car car, int size)
        {
            if (car is null)
                throw new Exception("Car can't be null");

            var wheel = new Wheel(car, size);    
            car.AddWheel(wheel);
        }

        internal void RemoveCar()
        {
            Car = null;
        }
    }
}
