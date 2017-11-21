using System;
using System.Collections.Generic;
using System.Linq;

namespace TeacherComputerRetrieval
{
    public class RoutesEngine
    {
        public int CalculateDistance(params City[] cities)
        {
            int distance = 0;

            for (int i = 0; (i + 1) < cities.Length; i++)
            {
                KeyValuePair<City, int> nextCity = cities[i].Connections.Where(x => x.Key.Id == cities[i + 1].Id).FirstOrDefault();
                if (null != nextCity.Key)
                    distance += nextCity.Value;
                else
                    return -1;
            }

            return distance;
        }

        public IList<Trip> PossibleTrips(City startCity, City endCity, int numberOfStops)
        {
            IList<Trip> trips = new List<Trip>();
            IList<Trip> possibleTrips = new List<Trip>();

            Queue<City> searchQueue = new Queue<City>();
            searchQueue.Enqueue(startCity);

            City current;

            int[] lastLevels = new int[numberOfStops + 1];
            int level = 0;
            lastLevels[level] = 1;

            int tripPointer = 0;
            int index = 0;

            trips.Add(new Trip());

            while (searchQueue.Count != 0)
            {
                lastLevels[level]--;
                current = searchQueue.Dequeue();

                trips[tripPointer].Cities.Add(current);

                if (current.Id == endCity.Id && index > 0)
                {
                    possibleTrips.Add(trips[tripPointer]);
                }

                if ((level + 1) <= numberOfStops)
                {
                    foreach (KeyValuePair<City, int> node in current.Connections)
                    {
                        searchQueue.Enqueue(node.Key);
                    }

                    lastLevels[level + 1] += current.Connections.Count;

                    while (trips.Count < lastLevels[level + 1])
                    {
                        trips.Add(new Trip());
                    }
                }

                tripPointer++;

                if (lastLevels[level] == 0)
                {
                    level++;
                    tripPointer = 0;
                }

                index++;
            }

            return possibleTrips;
        }

        public int ShortestRoute(City startCity, City endCity)
        {
            var shortestDistance = Int32.MaxValue;
                IList<Trip> PossibleTrips = new List<Trip>();
                var RoutesToEndCity = MapRoute(startCity, endCity).Distinct();

                foreach (var c in RoutesToEndCity)
                {
                    var distance = CalculateDistance(startCity, c);
                    if (distance > 0)
                    {
                        distance += c.Connections[endCity];
                    }
                    if (distance < shortestDistance)
                    {
                        shortestDistance = distance;
                    }
                }             
            return shortestDistance;
        }

        public IList<City> MapRoute(City startCity, City endCity)
        {

            List<City> cities = new List<City>();
            int i=0;
            foreach(var city in startCity.Connections.Keys)
            { 
                if(city.Connections.ContainsKey(endCity))
                {
                    cities.Add(city);                    
                }
                else
                {                   
                   cities.AddRange(MapRoute(city, endCity));                                    
                }
            }
            return cities;
        }

        private IList<City> FindAllIncomingConnections(City EndCity)
        {
            IList<City> cities = new List<City>();
            var AllCities = Repository.GetAllCities();
            foreach (var city in AllCities)
            {
                if(city.Connections.ContainsKey(EndCity))
                {
                    cities.Add(city);
                }               
            }
            return cities;                 
        }

        private IList<City> FindAllOutGoingConnections(City startCity)
        {
            IList<City> cities = new List<City>();
            foreach(var city in startCity.Connections.Keys)
            {
                cities.Add(city);
            }
            return cities;
        }

        public IList<Trip> PossibleTripsWithFixedNumberOfStops(City startCity, City endCity, int numberOfStops)
        {
            IList<Trip> trips = new List<Trip>();
            IList<Trip> possibleTrips = new List<Trip>();

            Queue<City> searchQueue = new Queue<City>();
            searchQueue.Enqueue(startCity);

            City current;

            int[] lastLevels = new int[numberOfStops + 1];
            int level = 0;
            lastLevels[level] = 1;

            int tripPointer = 0;
            int index = 0;

            trips.Add(new Trip());

            while (searchQueue.Count != 0)
            {
                lastLevels[level]--;
                current = searchQueue.Dequeue();

                trips[tripPointer].Cities.Add(current);

                if (current.Id == endCity.Id && index > 0 && level == numberOfStops)
                {
                    possibleTrips.Add(trips[tripPointer]);
                }

                if ((level + 1) <= numberOfStops)
                {
                    foreach (KeyValuePair<City, int> node in current.Connections)
                    {
                        searchQueue.Enqueue(node.Key);
                    }

                    lastLevels[level + 1] += current.Connections.Count;

                    while (trips.Count < lastLevels[level + 1])
                    {
                        trips.Add(new Trip());
                    }
                }

                tripPointer++;

                if (lastLevels[level] == 0)
                {
                    level++;
                    tripPointer = 0;
                }

                index++;
            }

            return possibleTrips;
        }

        public int NoOfShortestRouteLessThanGivenDistance(City startCity, City endCity, int distance, int MaxLocations)
        {
            int numberOfRoutes = 0;
            var PossibleRoutes = PossibleTrips(startCity, endCity, MaxLocations);
            foreach(var route in PossibleRoutes)
            {
                var cities = route.Cities.ToArray();
                if (CalculateDistance(cities) < distance && CalculateDistance(cities) != -1)
                {
                    numberOfRoutes++;
                }
            }
            return numberOfRoutes;
        }

    }

}