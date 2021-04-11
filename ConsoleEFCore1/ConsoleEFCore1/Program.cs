using ConsoleEFCore1.Models;
using System;

namespace ConsoleEFCore1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var _context = new AppDbContext())
            {
            }

            Console.ReadLine();
        }
    }
}
