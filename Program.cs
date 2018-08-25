using System;
using Delegate.ViewModels;
using Monad;
using ResultExtension;

namespace Delegate
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine(GetNumber());
            new NavigationService().NavigateTo<FirstViewModel>();
        }

        private static int GetNumber()
        {
            var data = 10;
            return new Result<int>(10)
            .When(data>11)
            .Do(x=>x+15)
            .GetValueOrDefault();
        }

    }
}
