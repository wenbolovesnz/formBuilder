using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FormBuilder.Data;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Init...");

            FormBuilderContext context = new FormBuilderContext();
            context.Database.Initialize(true);

            Console.WriteLine("done");
            Console.ReadLine();
        }
    }
}
