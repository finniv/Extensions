using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Delegate.Interfaces;
using Delegate.Models;
using Delegate.Models.LocalModels;
using Monad;
using ResultExtension;

namespace Delegate.ViewModels
{
    public class FirstViewModel : IViewModel
    {
        public delegate long BinaryOp(int multiply);
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

        private  void ThreadInitializer()
        {
            Count(2);
            BinaryOp  methodDelegate = Count;
            IResult ar = methodDelegate.BeginInvoke(2,null,null);
            while (!ar.IsCompleted)
            {
                Console.Write(".");
                Thread.Sleep(50);
            }
            long result = methodDelegate.EndInvoke(ar);
            Console.WriteLine("Result: " + result);

            Console.ReadLine();
            // Thread myThread = new Thread(Count(out res));
            // myThread.Start();
        }

        private long Count(int multiply)
        {
            Stopwatch stopWatch = new Stopwatch();
            System.Console.WriteLine("Count started");
            stopWatch.Start();
            var list = new List<int>();
            long res = 0;
            for (int i = 0; i < 1000*multiply; i++)
            {
                list.Add(i);
            }
            list.Select(x=> res+=x);
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;

        // Format and display the TimeSpan value.
        string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);
        Console.WriteLine(elapsedTime, "RunTime");
            System.Console.WriteLine("Count end");
            return res;
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
