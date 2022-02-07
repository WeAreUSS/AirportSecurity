using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AirportSecurity.Interfaces;
using AirportSecurity.Models;

namespace AirportSecurity
{
    public class ScreeningProcessing
    {
        private static object _lockObject = new object();
        public SecStations ProcessScreening(SecStations myAirportConfiguration, IList<Passenger> passengers)
        {
            var threadPoolMax = Environment.ProcessorCount;
            var result = ThreadPool.SetMaxThreads(threadPoolMax, threadPoolMax);

            var stationCount = myAirportConfiguration.ScreeningStations.Count;
            //var newList = productsList.Where(p => selectedIds.Contains(p.id)).ToList();
            var openStations = myAirportConfiguration.ScreeningStations.Where(s => s.IsOpen == true).ToList();
            int openStationsCount = openStations.Count;
            ConcurrentBag<ScreeningStation> stationList = new ConcurrentBag<ScreeningStation>();
            Parallel.ForEach(myAirportConfiguration.ScreeningStations, station =>
            {
                int x = 0;
                int y = 0;
                int z = 0;
                int perStationQueueCount = station.PassengersInQueue / openStationsCount;
               
                System.Threading.ThreadPool.QueueUserWorkItem(callBack => DoPassengerScreening(station,perStationQueueCount ));

            } );

            return myAirportConfiguration;
        }

        // kick off each station and set tasks
        // foreach line, kick off passenger screening
        // as each passenger finishes, decrement passCount, if no more ->stop and return completed info, else send another passenger
        public static void DoPassengerScreening(IScreeningStation station, int passAllotment)
        {
            Thread thread = Thread.CurrentThread;
            string message = $"Background: {thread.IsBackground}, Thread Pool: {thread.IsThreadPoolThread}, Thread ID: {thread.ManagedThreadId}";
            Console.WriteLine(message);

            // get number of passengers for each queue
            ScreeningTask thisTask = station.Tasks[0];
            thisTask.QueueedPassengers = passAllotment; //Allocate equal amount to task
            // obviously, each passenger can not be unloading belongings and also be picking up belongings at the same time
            // --> station.LineCount = number of sequential processing lines for tasks
            
            //==============================================
            //  Process for starting all lines
            //==============================================
            Console.WriteLine("Main Thread Started");
            //Main Thread creating three child threads
            Thread thread4 = new Thread(Method4);
            Thread thread5 = new Thread(Method5);
            Thread thread6 = new Thread(Method6);

            // each runs freely
            thread4.Start();
            thread5.Start();
            thread6.Start();

            thread4.Join();
            thread5.Join();
            thread6.Join();
            // at this point when all lines are finished
            // main thread finishes
            //==============================================
            

            // Using Lock:  private static object _lockObject = new object();
            // each call locks an object until the specified object's processing is completed
            // With this, each child has to wait it's turn....
            Thread t10 = new Thread(DisplayMessageWithLock);
            Thread t11 = new Thread(DisplayMessageWithLock);
            Thread t12 = new Thread(DisplayMessageWithLock);
            t10.Start();
            t11.Start();
            t12.Start();
            t10.Join();
            t11.Join();
            t10.Join();
            Console.Read();
            
            // Just a test of multiple parameters
            Console.WriteLine("message");
        }

        public async Task<List<ScreeningTask>> DoScreeningTask1(List<ScreeningTask> thisTaskList)
        {

            // Do all screeningtasks, for all passengers in each queue using multiThreading

            return thisTaskList;
        }

        static void DisplayMessageWithLock()
        {
            // Lock Block
            lock(_lockObject)
            {
                Console.Write("[Welcome to the ");
                Thread.Sleep(1000);
                Console.WriteLine("world of dotnet!]");
            }
        }

        static void Method1()
        {
            Console.WriteLine("Method1 - Thread 1 Started  and sleeping for 3000");
            Thread.Sleep(3000);
            Console.WriteLine("Method1 - Thread 1 Ended");
        }
        static void Method2()
        {
            Console.WriteLine("Method2 - Thread 2 Started and sleeping for 2000");
            Thread.Sleep(2000);
            Console.WriteLine("Method2 - Thread 2 Ended");
        }
        static void Method3()
        {
            Console.WriteLine("Method3 - Thread 3 Started and sleeping for 5000");
            Thread.Sleep(5000);
            Console.WriteLine("Method3 - Thread 3 Ended");
        }

        static void Method4()
        {
            Console.WriteLine("Method4 - Thread 4 Started  and sleeping for 1000");
            Thread.Sleep(1000);
            Console.WriteLine("Method4 - Thread 4 Ended");
        }
        static void Method5()
        {
            Console.WriteLine("Method5 - Thread 5 Started and sleeping for 2000");
            Thread.Sleep(2000);
            Console.WriteLine("Method5 - Thread 5 Ended");
        }
        static void Method6()
        {
            Console.WriteLine("Method6 - Thread 6 Started and sleeping for 5000");
            Thread.Sleep(5000);
            Console.WriteLine("Method6 - Thread 6 Ended");
        }








    }
}
