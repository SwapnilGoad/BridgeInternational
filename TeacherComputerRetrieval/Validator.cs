using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeacherComputerRetrieval
{
    public static class Validator
    {
        public static bool ValidateInput(string input)
        {

            try
            {
                var tempRoutes = input.Split(',');
                for (int i = 0; i < tempRoutes.Length; i++)
                {
                    var tempArray = tempRoutes[i].Trim().ToCharArray();                                       
                    if (tempArray[0].ToString().ToUpper() == tempArray[1].ToString().ToUpper())
                    {
                        return false;
                    }                    
                    var distance = int.Parse(tempRoutes[i].Trim().Substring(2));                    
                }
                return true;
            }
            catch (Exception)
            {
                //Here we are expecting integer parsing to cause exception
                return false;
            }
        }
    }
}
