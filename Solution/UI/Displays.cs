// I certify that this assignment is my own work entirely, performed independently and without any help from the sources which are not allowed.
// Mateusz Kubiszewski

using BigTask2.Api;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BigTask2.Ui
{
    class XMLDisplay : IDisplay
    {
        void PrintCity(City city)
        {
            Console.WriteLine($"<City/>");
            Console.WriteLine($"<Name>{city.Name}</Name>");
            Console.WriteLine($"<Population>{city.Population}</Population>");
            Console.WriteLine($"<HasRestaurant>{city.HasRestaurant}</HasRestaurant>\n");
        }
        void PrintRoute(Route route)
        {
            Console.WriteLine($"<Route/>");
            Console.WriteLine($"<Vehicle>{route.VehicleType}</Vehicle>");
            Console.WriteLine($"<Cost>{route.Cost}</Cost>");
            Console.WriteLine($"<TravelTime>{route.TravelTime}</TravelTime>\n");
        }
        void PrintSum(double Time, double Cost)
        {
            Console.WriteLine($"<totalTime>{Time:0.##}<totalTime/>");
            Console.WriteLine($"<totalCost>{Cost:0.##}<totalCost/>\n");
        }
        public void Print(IEnumerable<Route> routes)
        {
            if (routes == null)
            {
                Console.WriteLine("Nothing to display I am sorry\n");
                return;
            }
            double totalTime = 0;
            double totalCost = 0;
            PrintCity(routes.First().From);
            foreach (var route in routes)
            {
                totalTime += route.TravelTime;
                totalCost += route.Cost;
                PrintRoute(route);
                PrintCity(route.To);
            }
            PrintSum(totalTime, totalCost);
        }
    }
    class KeyValueDisplay : IDisplay
    {
        void PrintCity(City city)
        {
            Console.WriteLine($"=City=");
            Console.WriteLine($"Name = {city.Name}");
            Console.WriteLine($"Population = {city.Population}");
            Console.WriteLine($"HasRestaurant = {city.HasRestaurant}\n");
        }
        void PrintRoute(Route route)
        {
            Console.WriteLine($"=Route=");
            Console.WriteLine($"Vehicle = {route.VehicleType}");
            Console.WriteLine($"Cost = {route.Cost}");
            Console.WriteLine($"TravelTime = {route.TravelTime}\n");
        }
        void PrintSum(double Time, double Cost)
        {
            Console.WriteLine($"totalTime={Time:0.##}");
            Console.WriteLine($"totalCost={Cost:0.##}\n");
        }
        public void Print(IEnumerable<Route> routes)
        {
            if (routes == null)
            {
                Console.WriteLine("Nothing to display I am sorry\n");
                return;
            }
            double totalTime = 0;
            double totalCost = 0;
            PrintCity(routes.First().From);
            foreach (var route in routes)
            {
                totalTime += route.TravelTime;
                totalCost += route.Cost;
                PrintRoute(route);
                PrintCity(route.To);
            }
            PrintSum(totalTime, totalCost);
        }
    }
}

//=City=
//Name=Novigrad
//Population = 800000
//HasRestaurant=False

//=Route=
//Vehicle=Car
//Cost = 690,54
//TravelTime=457,55

//=City=
//Name=Zootopia
//Population = 700000
//HasRestaurant=False

//=Route=
//Vehicle=Car
//Cost = 66,79
//TravelTime=65,25

//=City=
//Name=Gotham
//Population = 4500000
//HasRestaurant=True

//totalTime = 522,8
//totalCost=757,33

//<City/>
//<Name>Novigrad</Name>
//<Population>800000</Population>
//<HasRestaurant>False</HasRestaurant>

//<Route/>
//<Vehicle>Car</Vehicle>
//<Cost>690,54</Cost>
//<TravelTime>457,55</TravelTime>

//<City/>
//<Name>Zootopia</Name>
//<Population>700000</Population>
//<HasRestaurant>False</HasRestaurant>

//<Route/>
//<Vehicle>Car</Vehicle>
//<Cost>66,79</Cost>
//<TravelTime>65,25</TravelTime>

//<City/>
//<Name>Gotham</Name>
//<Population>4500000</Population>
//<HasRestaurant>True</HasRestaurant>

//<totalTime>522,8</totalTime>
//<totalCost>757,33</totalCost>