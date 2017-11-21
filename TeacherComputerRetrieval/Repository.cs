using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeacherComputerRetrieval
{
    public class Repository
    {
        static readonly List<City> _lstCities;

        static Repository()
        {
            _lstCities = new List<City>();
        }
        public static void SeedData(string input)
        {
            if (!Validator.ValidateInput(input))
            {
                throw new Exception("Invalid Input");
            }
            else
            {
                var tempRoutes = input.Split(',');
                for (int i = 0; i < tempRoutes.Length; i++)
                {
                    AddCity(tempRoutes[i].Trim());                        
                }  
            }
        }

        private static void AddCity(string city)
        {
            var tempArray = city.ToUpper().ToCharArray();
            var distance = int.Parse(city.Substring(2));
            //Add the Starting City

            var StartCity = _lstCities.FirstOrDefault(c => c.Id ==  tempArray[0]);

            //Check if the City already Exists
            if(StartCity == null)
            {
                //If the Cty Doesn't exists create a new city Record and add it to the list of cities
                StartCity = new City(tempArray[0]);
                _lstCities.Add(StartCity);
            }

            //Add The Ending City
            var EndCity = _lstCities.FirstOrDefault(c => c.Id == tempArray[1]);
            //Check if the City already Exists
            if (EndCity == null)
            {
                //If the City Doesn't exists create a new city Record and add it to the list of cities
                EndCity = new City(tempArray[1]);
                _lstCities.Add(EndCity);
            }

            //Add Route Information to the Start city Routes.
            StartCity.Connections.Add(EndCity, distance);
            
        }

        public static City GetCityById(char id)
        {
            return _lstCities.FirstOrDefault(c => c.Id == id);
        }

        public static int GetNoOfCities()
        {
            return _lstCities.Count();
        }

        public static IEnumerable<City> GetAllCities()
        {
            return _lstCities;
        }
    }
}
