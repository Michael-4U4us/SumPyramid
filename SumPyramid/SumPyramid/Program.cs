using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumPyramid
{
    public class Program
    {
        static void Main(string[] args)
        {
            PyramidService pyramidService = new PyramidService();
            pyramidService.Show();

            Console.ReadKey();
        }

       
    }
}
