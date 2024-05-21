using MAS2.Models;


var toyota = new Brand("Toyota", "Japonia");
var corolla = new Car("Corrolla", DateOnly.Parse("2010-07-15"));

var opel = new Brand("Opel", "Niemcy");
var astra = new Car("Astra", DateOnly.Parse("2000-01-03"));
var vectra = new Car("Vectra", DateOnly.Parse("2003-06-21"));

var customer1 = new Customer("Bartosz Zebrowski"); 

vectra.AddRentByCustomer(customer1);
customer1.AddCarRent(corolla);

opel.AddCar("1HGCM82633A123456", astra);
opel.AddCar("2T2BZMCAXKC123456", vectra);
toyota.AddCar("3FAHP0HA6AR123456", corolla);




Wheel.AddWheelToCar(astra, 16);

