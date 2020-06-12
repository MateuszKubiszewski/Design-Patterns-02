// I certify that this assignment is my own work entirely, performed independently and without any help from the sources which are not allowed.
// Mateusz Kubiszewski

using System;
using System.Collections.Generic;
using BigTask2.Api;
using BigTask2.Data;

namespace BigTask2.Servants
{
    interface IAlgorithmServant
    {
        IEnumerable<Route> Handle(Request request, IGraphDatabase graph);
        void SetNext(IAlgorithmServant servant);
    }

    abstract class AlgorithmServant : IAlgorithmServant
    {
        protected IAlgorithmServant nextServant { get; set; }

        public abstract IEnumerable<Route> Handle(Request request, IGraphDatabase graph);

        public void SetNext(IAlgorithmServant servant)
        {
            nextServant = servant;
        }
    }

    interface IDecoratorServant
    {
        IGraphDatabase Handle(Filter filter, IGraphDatabase graph, IGraphDatabase cars, IGraphDatabase trains);
        void SetNext(IDecoratorServant servant);
    }

    abstract class DecoratorServant : IDecoratorServant
    {
        protected IDecoratorServant nextServant { get; set; }

        public abstract IGraphDatabase Handle(Filter filter, IGraphDatabase graph, IGraphDatabase cars, IGraphDatabase trains);

        public void SetNext(IDecoratorServant servant)
        {
            nextServant = servant;
        }
    }
}