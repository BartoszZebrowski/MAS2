using MAS2;

//Brands
var toyota = new Brand("Toyota", "Japonia");
var opel = new Brand("Opel", "Niemcy");

//Cars
var astra = new Car("Astra", DateOnly.Parse("2000-01-03"));
var vectra = new Car("Vectra", DateOnly.Parse("2003-06-21"));
var corolla = new Car("Corrolla", DateOnly.Parse("2010-07-15"));

var company1 = new Company("Wyporzyczalnex");
company1.AddCar(vectra);

//Customers
var customer1 = new Customer("Bartosz Zebrowski");
var customer2 = new Customer("Jan Kowalski");

//Seting brands
opel.AddCar("1HGCM82633A123456", astra);
opel.AddCar("2T2BZMCAXKC123456", vectra);
toyota.AddCar("3FAHP0HA6AR123456", corolla);

//Renting
vectra.AddRentByCustomer(customer1, 6);
customer1.AddCarRent(corolla,5);

//Adding Wheel
Wheel.AddWheelToCar(astra, 16);
Wheel.AddWheelToCar(astra, 16);
Wheel.AddWheelToCar(astra, 16);
Wheel.AddWheelToCar(astra, 16);

var wheel1 = astra.GetWheels().First();

astra.RemoveWheel(wheel1);
toyota.RemoveCar(corolla);

var rent1 = customer1.GetRents().First();

customer1.RemoveRent(rent1);
company1.RemoveCar(vectra);


Console.WriteLine("");


