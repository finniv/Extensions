using System;
using System.Threading;
using Delegate.Interfaces;
using Delegate.Models;
using Delegate.Models.LocalModels;
using Monad;
using ResultExtension;

namespace Delegate.ViewModels
{
    public class FirstViewModel : IViewModel
    {
        public FirstViewModel()
        {
            ThreadInitializer();
            for (int i = 1; i < 9; i++)
            {
                Console.WriteLine("Первый поток:");
                Console.WriteLine(i * i);
                Thread.Sleep(400);
            }
            ViewModelInitialize();
        }

        private void ThreadInitializer()
        {
            Thread myThread = new Thread(Count);
            myThread.Start();
        }

        private void Count(object obj)
        {
            for (int i = 1; i < 9; i++)
            {
                Console.WriteLine("Второй поток:");
                Console.WriteLine(i * i);
                Thread.Sleep(400);
            }
        }

        private void ViewModelInitialize()
        {
            var mapped = new Result<Model>(new Model
            {
                Property = "test",
                IntProperty = 1
            })
            .Map(x => new LocalModel
            {
                Property = x.Property,
                IntProperty = x.IntProperty,
                ViewModel = this
            });

            mapped.Value.ViewModel.MapSucced();
        }
        public void MapSucced()
        {
            Console.WriteLine("Done");
        }
    }
}
