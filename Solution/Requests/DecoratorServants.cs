// I certify that this assignment is my own work entirely, performed independently and without any help from the sources which are not allowed.
// Mateusz Kubiszewski

using System;
using System.Collections.Generic;
using BigTask2.Algorithms;
using BigTask2.Api;
using BigTask2.Data;

namespace BigTask2.Servants
{
    class MergeCarsServant : DecoratorServant
    {
        public override IGraphDatabase Handle(Filter filter, IGraphDatabase graph, IGraphDatabase cars, IGraphDatabase trains)
        {
            if (filter.AllowedVehicles.Contains(VehicleType.Car))
            {
                IGraphDatabase db = new MergeDatabase(graph, cars, true);
                return nextServant.Handle(filter, db, cars, trains);
            }
            return nextServant.Handle(filter, graph, cars, trains);
        }
    }

    class MergeTrainsServant : DecoratorServant
    {
        public override IGraphDatabase Handle(Filter filter, IGraphDatabase graph, IGraphDatabase cars, IGraphDatabase trains)
        {
            if (filter.AllowedVehicles.Contains(VehicleType.Train))
            {
                IGraphDatabase db = new MergeDatabase(graph, trains, true);
                return nextServant.Handle(filter, db, cars, trains);
            }
            return nextServant.Handle(filter, graph, cars, trains);
        }
    }

    class FilterPopulationServant : DecoratorServant
    {
        public override IGraphDatabase Handle(Filter filter, IGraphDatabase graph, IGraphDatabase cars, IGraphDatabase trains)
        {
            if (filter.MinPopulation > 0)
            {
                IGraphDatabase db = new FilterPopulation(graph, filter.MinPopulation);
                return nextServant.Handle(filter, db, cars, trains);
            }
            return nextServant.Handle(filter, graph, cars, trains);
        }
    }

    class FilterRestaurantServant : DecoratorServant
    {
        public override IGraphDatabase Handle(Filter filter, IGraphDatabase graph, IGraphDatabase cars, IGraphDatabase trains)
        {
            if (filter.RestaurantRequired)
            {
                IGraphDatabase db = new FilterRestaurant(graph, true);
                return db;
            }
            return graph;
        }
    }
}