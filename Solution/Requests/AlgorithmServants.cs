// I certify that this assignment is my own work entirely, performed independently and without any help from the sources which are not allowed.
// Mateusz Kubiszewski

using System;
using System.Collections.Generic;
using BigTask2.Algorithms;
using BigTask2.Api;
using BigTask2.Data;

namespace BigTask2.Servants
{
    class BFSServant : AlgorithmServant
    {
        public override IEnumerable<Route> Handle(Request request, IGraphDatabase graph)
        {
            if (request.Solver == "BFS")
            {
                IAlgorithm solver = new BFS();
                return solver.Solve(graph, graph.GetByName(request.From), graph.GetByName(request.To));
            }
            return nextServant.Handle(request, graph);
        }
    }

    class DFSServant : AlgorithmServant
    {
        public override IEnumerable<Route> Handle(Request request, IGraphDatabase graph)
        {
            if (request.Solver == "DFS")
            {
                IAlgorithm solver = new DFS();
                return solver.Solve(graph, graph.GetByName(request.From), graph.GetByName(request.To));
            }
            return nextServant.Handle(request, graph);
        }
    }

    class DijkstraServant : AlgorithmServant
    {
        public override IEnumerable<Route> Handle(Request request, IGraphDatabase graph)
        {
            if (request.Solver == "Dijkstra")
            {
                if (request.Problem == "Cost")
                {
                    IAlgorithm solver = new DijkstraCost();
                    return solver.Solve(graph, graph.GetByName(request.From), graph.GetByName(request.To));
                }
                if (request.Problem == "Time")
                {
                    IAlgorithm solver = new DijkstraTime();
                    return solver.Solve(graph, graph.GetByName(request.From), graph.GetByName(request.To));
                }
            }
            return null;
        }
    }
}