using System;
using System.Linq;
using System.Threading.Tasks;

namespace ClassRegister
{
    class Program
    {    
        static void Main()
        {
            Data dt = new Data();

            dt.AddNewFellow("54rk-bdi5", "Murinat", "Abolarinwa", "Oloyede", Gender.Female, 5);

            Console.ReadKey();

            dt.UpdateFellowState("54rk-bdi5", 10);
        }
    }
}