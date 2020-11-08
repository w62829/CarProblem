using System;

namespace Car
{ 
    class Program
    {
        static void Main(string[] args)
        {
            Car car1 = new Car("Ford", "Red", 2019, 60, 6);
            car1.Tank(30.5);
            car1.Drive(25.54);
            car1.ChangeColor("Black");
            car1.Drive(12);
            Console.WriteLine(car1.DailyKilometerCounter);
            // {
            //     var a = DateTime.Today;
            //
            //     Console.WriteLine(a);
            // }
           


        }
    }
    public class Car
    {
        private string _make;
        private int _yearOfProduction;
        private string _color;
        private int _petrolTankCapacity;
        private double _petrolUsagePer100Km;
        private double _kilometerCounter;
        private double _petrolLevel;
        private double _dailyKilometerCounter;
        
        public string Make => _make;
        public int YearOfProduction => _yearOfProduction;
        public string Color => _color;
        public int PetrolTankCapacity => _petrolTankCapacity;
        public double PetrolUsagePer100Km => _petrolUsagePer100Km;
         
         

        public double KilometerCounter => _kilometerCounter;
        public double PetrolLevel => _petrolLevel;
        public double DailyKilometerCounter => _dailyKilometerCounter;

        public Car(string make, string color, int yearOfProduction, int petrolTankCapacity, int petrolUsagePer100km)
        {
            if (string.IsNullOrEmpty(make))
                throw new ArgumentNullException("Make cannot be empty");

            if (string.IsNullOrEmpty(color))
                throw new ArgumentNullException("Colour cannot be empty");

            if (yearOfProduction < 2000 || yearOfProduction > DateTime.Now.Year)
                throw new ArgumentException("Year of production can be a number from 2000 to current year");

            if (petrolTankCapacity < 1)
                throw new ArgumentException("Petrol tank capacity needs to be positive");

            if (petrolUsagePer100km < 0)
                throw new ArgumentException("Petrol usage needs to be not negative");

            _make = make;
            _color = color;
            _yearOfProduction = yearOfProduction;
            _petrolTankCapacity = petrolTankCapacity;
            _petrolUsagePer100Km = petrolUsagePer100km;
        }

        public void Tank(double litres)
        {
            if (litres < 0)
                throw new ArgumentException("Provide a positive value");

            if (_petrolLevel + litres > _petrolTankCapacity)
                _petrolLevel = _petrolTankCapacity;
            else
                _petrolLevel += litres;
        }

        
        public void Drive(double kilometers)
        {


            var limit = 500000;
            if(kilometers < limit)
            {
                var range = 1.0 * _petrolLevel * 100 / _petrolUsagePer100Km;


                if (kilometers > range)
                {
                    DriveDaily(range);
                    _kilometerCounter += range;
                    _petrolLevel = 0;

                }
                else
                {
                     DriveDaily(kilometers);
                    _kilometerCounter += kilometers;
                    _petrolLevel -= kilometers * PetrolUsagePer100Km / 100;
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }

        }

        public void DriveDaily(double kilometers)
        {
            var currentday = DateTime.Now;
            if (currentday == DateTime.Today)
            { 
                
               _dailyKilometerCounter += kilometers;
            }
            else
            {
                _dailyKilometerCounter = 0;
            }
        }

         
         

        public void ChangeColor(string newPaint)
        {
            if (string.IsNullOrEmpty(newPaint))
                throw new ArgumentNullException("New colour cannot be empty");
            
            _color = newPaint;
        }
    }

   
}
