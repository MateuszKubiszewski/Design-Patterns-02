// I certify that this assignment is my own work entirely, performed independently and without any help from the sources which are not allowed.
// Mateusz Kubiszewski

using BigTask2.Api;
using System.Collections.Generic;

namespace BigTask2.Data
{
    public abstract class Iterator<T>
    {
        public abstract T Next();
        public abstract bool IsEmpty();
        public abstract void Add(Route route);
    }

    class DatabaseIterator : Iterator<Route>
    {
        List<Route> Routes;
        int CurrentRoute = 0;

        public DatabaseIterator(List<Route> routes)
        {
            Routes = routes;
        }

        public override Route Next()
        {
            if (CurrentRoute == Routes.Count)
            {
                CurrentRoute = 0;
                return null;
            }
            while (Routes[CurrentRoute] == null)
            {
                CurrentRoute++;
                if (CurrentRoute == Routes.Count)
                {
                    CurrentRoute = 0;
                    return null;
                }
            }
            return Routes[CurrentRoute++];
        }

        public override bool IsEmpty()
        {
            return Routes.Count == 0;
        }

        public override void Add(Route route)
        {
            Routes.Add(route);
        }
    }

}