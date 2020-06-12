//This file contains fragments that You have to fulfill
// I certify that this assignment is my own work entirely, performed independently and without any help from the sources which are not allowed.
// Mateusz Kubiszewski

using BigTask2.Api;
using System.Collections.Generic;

namespace BigTask2.Data
{
	class AdjacencyListDatabase : IGraphDatabase
	{
		private Dictionary<string, City> cityDictionary = new Dictionary<string, City>();
		private Dictionary<City, List<Route>> routes = new Dictionary<City, List<Route>>();

		private void AddCity(City city)
		{
			if (!cityDictionary.ContainsKey(city.Name))
				cityDictionary[city.Name] = city;
		}
		public AdjacencyListDatabase(IEnumerable<Route> routes)
		{
			foreach (Route route in routes)
			{
				AddCity(route.From);
				AddCity(route.To);
				if (!this.routes.ContainsKey(route.From))
				{
					this.routes[route.From] = new List<Route>();
				}
				this.routes[route.From].Add(route);
			}
		}
		public AdjacencyListDatabase()
		{
		}
		public void AddRoute(City from, City to, double cost, double travelTime, VehicleType vehicle)
		{
			AddCity(from);
			AddCity(to);
			if (!routes.ContainsKey(from))
			{
				routes[from] = new List<Route>();
			}
			routes[from].Add(new Route { From = from, To = to, Cost = cost, TravelTime = travelTime, VehicleType = vehicle });
		}

		public /*void*/ Iterator<Route> GetRoutesFrom(City from)
		{
			/*
			 * Fill this fragment and return Type.
			 * Modyfing existing code in this class is forbidden.
			 * Adding new elements (fields, private classes) to this class is allowed.
			 */
			if (!routes.ContainsKey(from))
				return new DatabaseIterator(new List<Route>());
			return new DatabaseIterator(routes[from]);
		}

		public City GetByName(string cityName)
		{
			return cityDictionary.GetValueOrDefault(cityName);
		}
	}
}