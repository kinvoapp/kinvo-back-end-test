using Aliquota.Domain;
using Aliquota.Domain.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Service = Aliquota.Domain.Services.Aliquot;

namespace Aliquota.Desktop
{
    class Program
    {
        static void Main(string[] args)
        {
            var options = new DbContextOptionsBuilder<AliquotContext>();
            options.UseInMemoryDatabase("aliquot_test");
            Service.context = new AliquotContext(options.Options);

            while (true)
            {
                try
                {
                    for (int i = 0; i < args.Length; i++)
                    {
                        switch (args[i])
                        {
                            case "add":
                                {
                                    var add = new Add();
                                    add.Entity = args[i + 1];
                                    add.Args = args.Skip(i + 2).ToArray();
                                    add.Run();
                                }
                                break;
                            case "rescue":
                                {
                                    try
                                    {
                                        var rescue = Service.Rescue(Convert.ToInt32(args[i + 1]));
                                        Console.WriteLine(String.Format("Rescued value is: ${0}", rescue));
                                    }
                                    catch (BusinessException e)
                                    {
                                        Console.WriteLine(String.Format("Error: {0}", e.Message));
                                    }
                                }
                                break;
                            case "exit": return;
                            default:
                                break;

                        }
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (IndexOutOfRangeException e)
                {
                    Console.WriteLine("Error: Argument missing.");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error unexpected.");
                }

                
                Console.Write("Command>> ");
                var command = Console.ReadLine();
                args = command.Split(' ');
            }

        }
    }
}
