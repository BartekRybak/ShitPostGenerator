using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShitPostGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Post p = PostGenerator.Generate(6, 100);

            Console.WriteLine(p.Title + "\n");
            Console.WriteLine(p.Body);
            
            Console.ReadLine();
        }
    }
}
