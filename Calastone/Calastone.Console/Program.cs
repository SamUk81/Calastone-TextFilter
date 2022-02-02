using Calastone.Application.Contracts;
using Calastone.Infrastructure.Filters;
using Calastone.Services;
using System.IO;
using System;
using Microsoft.Extensions.DependencyInjection;

namespace Calastone.ConsoleApplication
{
    class Program
    {
        private static IFilterService _filterService;

        static void Main(string[] args)
        {
            ConfigureServices();

            var filePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "InputText.txt");

            var output = string.Empty;

            using (StreamReader sr = File.OpenText(filePath))
            {
                var text = sr.ReadToEnd();

                Console.WriteLine("Input text:");
                Console.WriteLine("*************");
                Console.WriteLine(text);
                Console.WriteLine();

                Console.WriteLine("Press any key to apply all 3 filters to the input text >>");
                Console.WriteLine("***********************************************************");
                Console.ReadKey();

                // Apply filter 1
                output = _filterService.FilterOutWordsContainsVowelsInMiddle(text);
                // Apply filter 2
                output = _filterService.FilterOutWordsLengthLessThanThree(output);
                // Apply filter 3
                output = _filterService.FilterOutWordsContainsLetterT(output);                
            }
            
            Console.WriteLine();
            Console.WriteLine("Output text after applying all 3 filters:");
            Console.WriteLine("*******************************************");
            Console.WriteLine(output);
            Console.WriteLine();
        }

        private static void ConfigureServices()
        {
            var serviceCollection = new ServiceCollection()
                .AddTransient<IFilterService, FilterService>()
                .AddTransient<IFilterFactory, FilterFactory>()
                .BuildServiceProvider();

            _filterService = serviceCollection.GetService<IFilterService>();
        }
    }
}
