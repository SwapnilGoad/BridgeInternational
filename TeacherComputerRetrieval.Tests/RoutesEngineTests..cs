using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TeacherComputerRetrieval.Tests
{
    [TestClass]
    public class RoutesEngineTests
    {

        [TestMethod]
        public void CalculateDistance_with_a_valid_route_should_return_the_distance()
        {
            RoutesEngine RoutesEngine = new RoutesEngine();

            City A = new City('A');
            City B = new City('B');
            City C = new City('C');
            City D = new City('D');
            City E = new City('E');

            A.Connections.Add(B, 5);
            B.Connections.Add(C, 4);
            C.Connections.Add(D, 8);
            D.Connections.Add(C, 8);
            D.Connections.Add(E, 6);
            A.Connections.Add(D, 5);
            C.Connections.Add(E, 2);
            E.Connections.Add(B, 3);
            A.Connections.Add(E, 7);

            Assert.IsTrue(9 == RoutesEngine.CalculateDistance(A, B, C));
            Assert.IsTrue(5 == RoutesEngine.CalculateDistance(A, D));
            Assert.IsTrue(13 == RoutesEngine.CalculateDistance(A, D, C));
            Assert.IsTrue(22 == RoutesEngine.CalculateDistance(A, E, B, C, D));
        }

        [TestMethod]
        public void CalculateDistance_with_a_invalid_route_should_return_negative()
        {
            RoutesEngine RoutesEngine = new RoutesEngine();

            City A = new City('A');
            City B = new City('B');
            City C = new City('C');
            City D = new City('D');
            City E = new City('E');

            A.Connections.Add(B, 5);
            B.Connections.Add(C, 4);
            C.Connections.Add(D, 8);
            D.Connections.Add(C, 8);
            D.Connections.Add(E, 6);
            A.Connections.Add(D, 5);
            C.Connections.Add(E, 2);
            E.Connections.Add(B, 3);
            A.Connections.Add(E, 7);

            Assert.IsTrue(-1 == RoutesEngine.CalculateDistance(A, E, D));
        }

        [TestMethod]
        public void PossibleTrips_should_return_the_trips_between_two_cities()
        {
            RoutesEngine RoutesEngine = new RoutesEngine();

            City A = new City('A');
            City B = new City('B');
            City C = new City('C');
            City D = new City('D');
            City E = new City('E');

            A.Connections.Add(B, 5);
            B.Connections.Add(C, 4);
            C.Connections.Add(D, 8);
            D.Connections.Add(C, 8);
            D.Connections.Add(E, 6);
            A.Connections.Add(D, 5);
            C.Connections.Add(E, 2);
            E.Connections.Add(B, 3);
            A.Connections.Add(E, 7);

            Assert.IsTrue(2 == RoutesEngine.PossibleTrips(C, C, 3).Count);
            Assert.IsTrue(3 == RoutesEngine.PossibleTrips(A, C, 3).Count);
            Assert.IsTrue(6 == RoutesEngine.PossibleTrips(A, C, 4).Count);
            Assert.IsTrue(3 == RoutesEngine.PossibleTrips(D, C, 3).Count);
            Assert.IsTrue(1 == RoutesEngine.PossibleTrips(E, B, 1).Count);
            Assert.IsTrue(2 == RoutesEngine.PossibleTrips(E, C, 4).Count);
        }

        [TestMethod]
        public void PossibleTripsWithFixedNumberOfStops_should_return_the_trips_between_two_cities_with_exactly_informed_number_of_stops()
        {
            RoutesEngine RoutesEngine = new RoutesEngine();

            City A = new City('A');
            City B = new City('B');
            City C = new City('C');
            City D = new City('D');
            City E = new City('E');

            A.Connections.Add(B, 5);
            B.Connections.Add(C, 4);
            C.Connections.Add(D, 8);
            D.Connections.Add(C, 8);
            D.Connections.Add(E, 6);
            A.Connections.Add(D, 5);
            C.Connections.Add(E, 2);
            E.Connections.Add(B, 3);
            A.Connections.Add(E, 7);

            Assert.IsTrue(3 == RoutesEngine.PossibleTripsWithFixedNumberOfStops(A, C, 4).Count);
        }

        [TestMethod]
        public void ShortestRoute_should_return_shortest_route_between_two_cities()
        {
            RoutesEngine RoutesEngine = new RoutesEngine();

            City A = new City('A');
            City B = new City('B');
            City C = new City('C');
            City D = new City('D');
            City E = new City('E');

            A.Connections.Add(B, 5);
            B.Connections.Add(C, 4);
            C.Connections.Add(D, 8);
            D.Connections.Add(C, 8);
            D.Connections.Add(E, 6);
            A.Connections.Add(D, 5);
            C.Connections.Add(E, 2);
            E.Connections.Add(B, 3);
            A.Connections.Add(E, 7);
            Assert.IsTrue(9 == RoutesEngine.ShortestRoute(A, C));
        }

    }
}
  
