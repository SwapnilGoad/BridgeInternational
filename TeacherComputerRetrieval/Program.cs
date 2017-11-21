using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeacherComputerRetrieval
{
    class Program
    {
        static RoutesEngine routesEngine = new RoutesEngine();
        static void Main(string[] args)
        {

            try
            {
                Console.WriteLine("Welcome to Teacher Computer Retrival Application\n");
                Console.WriteLine("Enter the input in the following format:[Starting Academy][Ending Academy][distance], [Starting Academy][Ending Academy][distance]....(Eg: AB5, BC7....):=>\n");
                string input = Console.ReadLine();
                Repository.SeedData(input);
                Console.WriteLine("1. The distance of the route A-B-C is:");
                var distance = routesEngine.CalculateDistance(Repository.GetCityById('A'), Repository.GetCityById('B'), Repository.GetCityById('C'));

                if (distance == -1)
                    Console.WriteLine("NO SUCH ROUTE!\n");
                else
                    Console.WriteLine("\t" + distance + "\n");

                Console.WriteLine("2. The distance of the route A-E-B-C-D is:");
                distance = routesEngine.CalculateDistance(Repository.GetCityById('A'), Repository.GetCityById('E'), Repository.GetCityById('B'), Repository.GetCityById('C'), Repository.GetCityById('D'));
                if (distance == -1)
                    Console.WriteLine("NO SUCH ROUTE!\n");
                else
                    Console.WriteLine("\t" + distance + "\n");

                Console.WriteLine("3. The distance of the route A-E-D is:");
                distance = routesEngine.CalculateDistance(Repository.GetCityById('A'), Repository.GetCityById('E'), Repository.GetCityById('D'));
                if (distance == -1)
                    Console.WriteLine("NO SUCH ROUTE!\n");
                else
                    Console.WriteLine("\t" + distance + "\n");

                Console.WriteLine("4.The number of trips starting at C and ending at C with a maximum of 3 stops:");
                Console.WriteLine("\t" + routesEngine.PossibleTrips(Repository.GetCityById('C'), Repository.GetCityById('C'), 3).Count + "\n");

                Console.WriteLine("5.The number of trips starting at A and ending at C with exactly 4 stops:");
                Console.WriteLine("\t" + routesEngine.PossibleTripsWithFixedNumberOfStops(Repository.GetCityById('A'), Repository.GetCityById('C'), 4).Count + "\n");

                Console.WriteLine("6.The length of the shortest route(in terms of distance to travel) from A to C:");
                Console.WriteLine("\t" + routesEngine.ShortestRoute(Repository.GetCityById('A'), Repository.GetCityById('C')) + "\n");

                //Console.WriteLine("7.The length of the shortest route(in terms of distance to travel) from B to B:");
                Console.WriteLine(routesEngine.ShortestRoute(Repository.GetCityById('B'), Repository.GetCityById('B')) + "\n");
                
                //Console.WriteLine("8.The number of different routes from C to C with a distance of less than 30:");
                //Console.WriteLine(routesEngine.PossibleTrips(Repository.GetCityById('C'), Repository.GetCityById('C'), 30).Count);
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error:" + ex.Message + "\npress any key to exit...");
                Console.ReadKey();
            }
        }
    }
}
