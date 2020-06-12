// I certify that this assignment is my own work entirely, performed independently and without any help from the sources which are not allowed.
// Mateusz Kubiszewski

using BigTask2.Algorithms;
using BigTask2.Api;
using BigTask2.Data;
using BigTask2.Servants;
using BigTask2.Ui;
using System;
using System.Collections.Generic;
using System.IO;

namespace BigTask2
{
    class Program
    {
        static IEnumerable<Route> ServeRequest(Request request)
        {
            (IGraphDatabase cars, IGraphDatabase trains) = MockData.InitDatabases();

            if (request.From == "" || request.To == "" || request.Filter.MinPopulation < 0 || request.Filter.AllowedVehicles.Count == 0)
            {
                Console.WriteLine("Invalid Data\n");
                return null;
            }

            IGraphDatabase db = new AdjacencyListDatabase();
            IDecoratorServant mergecars = new MergeCarsServant();
            IDecoratorServant mergetrains = new MergeTrainsServant();
            IDecoratorServant filterpop = new FilterPopulationServant();
            IDecoratorServant filterrest = new FilterRestaurantServant();
            mergecars.SetNext(mergetrains);
            mergetrains.SetNext(filterpop);
            filterpop.SetNext(filterrest);
            IGraphDatabase db4 = mergecars.Handle(request.Filter, db, cars, trains);

            /*
			 *
			 * Add request handling here and return calculated route
			 *  5. The operation of the request
                Operation of the request should:
                — get the required data from any of the user interfaces using RequestMapper, <= in execute before serverequest
                — check if the data is correct (non-blank 'from' and 'to' fields, non-negative minimal population, at least one means of transport is chosen),
                — detect which algorithm is required,
                — deliver data to the algorithm,
                — allow the addition of city filters and road filters.
			 */
            IAlgorithmServant bfs = new BFSServant();
            IAlgorithmServant dfs = new DFSServant();
            IAlgorithmServant dijkstra = new DijkstraServant();
            bfs.SetNext(dfs);
            dfs.SetNext(dijkstra);
            return bfs.Handle(request, db4);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("---- Xml Interface ----");
            /*
			 * Create XML System Here
             * and execute prepared strings
			 */
            IFactory xmlFactory = new XMLFactory();
            ISystem xmlSystem = CreateSystem(xmlFactory);
            Execute(xmlSystem, "xml_input.txt");
            Console.WriteLine();

            Console.WriteLine("---- KeyValue Interface ----");
            /*
			 * Create INI System Here
             * and execute prepared strings
			 */
            IFactory kvFactory = new KeyValueFactory();
            ISystem keyValueSystem = CreateSystem(kvFactory);
            Execute(keyValueSystem, "key_value_input.txt");
            Console.WriteLine();
        }

        /* Prepare method Create System here (add return, arguments and body)*/
        static ISystem CreateSystem(IFactory factory) 
        {
            ISystem system = factory.GetSystem();
            system.Display = factory.GetDisplay();
            system.Form = factory.GetForm();
            return system;
        }

        static void Execute(ISystem system, string path)
        {
            IEnumerable<IEnumerable<string>> allInputs = ReadInputs(path);
            foreach (var inputs in allInputs)
            {
                foreach (string input in inputs)
                {
                    system.Form.Insert(input);
                }
                var request = RequestMapper.Map(system.Form);
                var result = ServeRequest(request);
                system.Display.Print(result);
                Console.WriteLine("==============================================================");
            }
        }

        private static IEnumerable<IEnumerable<string>> ReadInputs(string path)
        {
            using (StreamReader file = new StreamReader(path))
            {
                List<List<string>> allInputs = new List<List<string>>();
                while (!file.EndOfStream)
                {
                    string line = file.ReadLine();
                    List<string> inputs = new List<string>();
                    while (!string.IsNullOrEmpty(line))
                    {
                        inputs.Add(line);
                        line = file.ReadLine();
                    }
                    if (inputs.Count > 0)
                    {
                        allInputs.Add(inputs);
                    }
                }
                return allInputs;
            }
        }
    }
}
