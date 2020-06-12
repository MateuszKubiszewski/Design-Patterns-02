//This file contains fragments that You have to fulfill
// I certify that this assignment is my own work entirely, performed independently and without any help from the sources which are not allowed.
// Mateusz Kubiszewski

using BigTask2.Api;
using System.Collections.Generic;

namespace BigTask2.Data
{
    public interface IGraphDatabase
    {
        //Fill the return type of the method below
        /*void*/
        Iterator<Route> GetRoutesFrom(City from);
        City GetByName(string cityName);
    }

    public abstract class GraphDatabaseDecorator : IGraphDatabase
    {
        protected IGraphDatabase graphDatabase;
        public GraphDatabaseDecorator(IGraphDatabase graph)
        {
            graphDatabase = graph;
        }
        public virtual Iterator<Route> GetRoutesFrom(City from)
        {
            return graphDatabase.GetRoutesFrom(from);
        }
        public virtual City GetByName(string cityName)
        {
            return graphDatabase.GetByName(cityName);
        }
    }

    public class MergeDatabase : GraphDatabaseDecorator
    {
        IGraphDatabase toMerge;
        bool yes;
        public MergeDatabase(IGraphDatabase graph, IGraphDatabase vehiclesDB, bool shouldIMerge = false) : base(graph)
        {
            toMerge = vehiclesDB;
            yes = shouldIMerge;
        }
        public override Iterator<Route> GetRoutesFrom(City from)
        {
            Iterator<Route> toRet = base.GetRoutesFrom(from);
            Iterator<Route> toAdd = toMerge.GetRoutesFrom(from);

            if (toAdd.IsEmpty() || !yes)
                return toRet;
            for (Route curr = toAdd.Next(); curr != null; curr = toAdd.Next())
            {
                toRet.Add(curr);
            }
            return toRet;
        }
        public override City GetByName(string cityName)
        {
            if (base.GetByName(cityName) != null)
                return base.GetByName(cityName);
            return toMerge.GetByName(cityName);
        }
    }

    public class FilterPopulation : GraphDatabaseDecorator
    {
        int minPopulation;
        public FilterPopulation(IGraphDatabase graph, int minpopulation = 0) : base(graph)
        {
            minPopulation = minpopulation;
        }
        public override Iterator<Route> GetRoutesFrom(City from)
        {
            Iterator<Route> toRet = new DatabaseIterator(new List<Route>());
            Iterator<Route> current = base.GetRoutesFrom(from);

            if (current.IsEmpty())
                return toRet;
            for (Route curr = current.Next(); curr != null; curr = current.Next())
            {
                if (curr.To.Population >= minPopulation)
                    toRet.Add(curr);
            }
            return toRet;
        }
        public override City GetByName(string cityName)
        {
            return base.GetByName(cityName);
        }
    }

    public class FilterRestaurant : GraphDatabaseDecorator
    {
        bool Restaurant;
        public FilterRestaurant(IGraphDatabase graph, bool restaurant = false) : base(graph)
        {
            Restaurant = restaurant;
        }
        public override Iterator<Route> GetRoutesFrom(City from)
        {
            Iterator<Route> toRet = new DatabaseIterator(new List<Route>());
            Iterator<Route> current = base.GetRoutesFrom(from);

            if (current.IsEmpty() || Restaurant == false)
                return current;
            for (Route curr = current.Next(); curr != null; curr = current.Next())
            {
                if (curr.To.HasRestaurant)
                    toRet.Add(curr);
            }
            return toRet;
        }
        public override City GetByName(string cityName)
        {
            return base.GetByName(cityName);
        }
    }
}