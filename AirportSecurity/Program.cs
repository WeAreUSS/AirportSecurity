using System;
using System.Collections.Generic;
using System.Threading;
using AirportSecurity.Interfaces;
using AirportSecurity.Models;


namespace AirportSecurity
{
    class Program
    {
        private static Interfaces.IFlightData myFlightData;
      private static Interfaces.IHelpers myHelper ;

        // Annual Values
        private static int[] enPlane = new int[12]{ 75134, 72072, 85211, 78315, 93893, 96288, 100658, 96247, 77288, 79790, 68663, 74818};
        private static int[] dePlane = new int[12]{ 72374, 72450, 82129, 79522, 92581, 98939, 103074, 97423, 75117, 78662, 67805, 74605};
        // Hourly Values
        private static double[] enPlaneHours = new double[24]{ 0.0, 0.0, 0.0, 0.0, 0.0, 2.9, 3.7, 11.0, 10.3, 6.4, 4.0, 4.1, 2.8, 2.0, 8.4, 5.6, 6.3, 8.1, 8.7, 7.0, 4.0, 2.4, 2.0, 0.3 };
        private static double[] dePlaneHours = new double[24]{ 0.2, 0.0, 0.0, 0.0, 0.0, 0.0, .5, 4.0,  8.0, 8.7, 5.4, 11.3, 11.1, 8.8, 3.2, 3.1, 6.8, 9.4, 8.2, 3.0, 4.2, 3.0, 1.1, 0.0 };

       

        static void Main(string[] args)
        {

            myFlightData = new Models.FlightData();
            myHelper = new Helpers.Helpers();
            // raw data initialization
            List<int> enPlanedPassYear = myHelper.CreateList(enPlane);
            List<int> dePlanedPassYear = myHelper.CreateList(dePlane);
            List<double> enPlanedHours = myHelper.CreateList(enPlaneHours);
            List<double> dePlanedHours = myHelper.CreateList(dePlaneHours);

            // models initialization
            myFlightData.InitializeYearlyFlightData( enPlanedPassYear, dePlanedPassYear, enPlanedHours, dePlanedHours);


            SecStations mySecStations = new SecStations(1);
           
            mySecStations.ScreeningStations = new List<IScreeningStation>();

            int allowedWaitTime = 30;

            ScreeningStation myStation = new ScreeningStation(allowedWaitTime, 1);
            myStation.Tasks = new List<ScreeningTask>();







            int monthPassNbr = enPlanedPassYear[1]; // nbr psgrs for month
            int days = DateTime.DaysInMonth(2022, 2);
            int psgrsToday = int.Parse((monthPassNbr / days).ToString());
            //=====================================================
            // now, we have the number of passengers for this day
            //=====================================================
            // next, we have to find the hourly distribution of passengers
            List<int> screenPassHr = new List<int>();
            for (int x = 0; x < 23; x++)
                screenPassHr.Add(int.Parse((psgrsToday*enPlanedHours[x]).ToString()));

            // now we need to know what hour we are in so that we determine
            // what happened last hour with respect to passenger volume in respect to stations
            // and what is happening this hour with respect to passenger volume in respect to stations
            // -- We are trying to create a realistic "as is" situation
            // later, someone is going to change things up for new screenings
            // that may also have an effect on folks currently in the queue

            string nowString = DateTime.Now.ToString("hh:mm:ss");
            string[] timeStringParts = nowString.Split(':');

            int curHour = int.Parse(timeStringParts[0]);
            int curMin = int.Parse(timeStringParts[1]);
            int remainingMin = 60 - curMin;
            int currPassHour = screenPassHr[curHour];
            double screenTime = 0.0;

            // Now, we got to figure how much time it takes per passenger to make it through a screening
            // =========================================================================================
            // Last hour first
            //------------------
            // with the correct optimal number of queues for last hour
            // based upon 30 minute wait time
            //
            // we get the current nominal passenger que
            // then we havce to figure
            // with amount of folks still in the queqe from last hour (minutes remaining in hour)

            // processing time for last hour's queue
            // for each task figure the amount of time













            myStation.AnticipatedPsngrCount = enPlanedPassYear[1]; // nbr psgrs for month

           
            myStation.Tasks = new List<ScreeningTask>();

            ScreeningTask myTask = new ScreeningTask(1);
          
            


            /*
             * 1. Get current date/time
             * 2. figure out how many stations should be up and running
             * 3. set each station to a randum number of hours working 
             * 4. figure how many passengers are processed and how many are waiting
             *     use 30 minute wait time
             *     use all screenings running
             * 5. Get timestamp for moment of configuration
             * 
             */

            ShowInitializationInfo();

            // Get Required Screening Tasks
            while (true)
            {
                bool done = false;
                ShowStationInfo();
                Console.ReadLine();
                // ToDo: input parsing and verification
                
               if (done)
                   break;// if success break while
                   
            }
            Console.Clear();
           
            // Get Passenger wait time
            while (true)
            {
                bool done = false;
                ShowWaitTimeInfo();
                Console.ReadLine();
                // ToDo: input parsing and verification
                
                if (done)
                    break;// if success break while
            }
           
            Console.Clear();
           
            // ToDo: Input parsing and verification
            
            // ToDo: Run all calculations
            // 1. use config timestamp and determine the state of current stations and queues
            // 2. open/close stations if rule dictates

            // ToDo: Output Results








            Console.WriteLine("Output Results");
        }


        public static void ShowInitializationInfo()
        {
            // input screening parameters
            Console.WriteLine("==================================================");
            Console.WriteLine("                                                                   ");
            Console.WriteLine("      System Initialization Information           ");
            Console.WriteLine("                                                                   ");
            Console.WriteLine("==================================================");
            Console.WriteLine("==================================================");
            Console.WriteLine("    Assumptions in Configuration                                              ");
            Console.WriteLine("==================================================");
            Console.WriteLine("   1. Start wait time is 30 minutes               ");
            Console.WriteLine("   2. Rand was used for each station start.       ");
            Console.WriteLine("   3. Previous DateTime().Today.Hour was used.    ");
            Console.WriteLine("==================================================");
            Console.WriteLine("                                                  ");
            Console.WriteLine("     Operating Screening Stations                 ");
            Console.WriteLine("==================================================");
            Console.WriteLine("  StationId  Start Hour  Hours Operating     Passengers in Queue    End Hour");
            Console.WriteLine("  ---------  ----------  ---------------     -------------------    --------");
            foreach (ScreeningStation station in myScreeningStations)
            {

                // ToDo: dump useful information
            }
            Console.WriteLine("==================================================");
            Console.WriteLine("==================================================");

        }

        public static void ShowStationInfo()
        {
            // input screening parameters
            Console.WriteLine("==================================================");
            Console.WriteLine("      Input Required Screening Safeguards         ");
            Console.WriteLine("==================================================");
            Console.WriteLine("                                                  ");
            Console.WriteLine("  Number             Screening Name               ");
            Console.WriteLine("  ------             --------------               ");
            Console.WriteLine("                                                  ");
            Console.WriteLine("   1.                Puffer                       ");
            Console.WriteLine("   2.                ExtendedScreening            ");
            Console.WriteLine("   3.                MetalDetector                ");
            Console.WriteLine("   4.                X-Ray                        ");
            Console.WriteLine("   5.                Biological                   ");
            Console.WriteLine("   6.                Chemical                     ");
            Console.WriteLine("                                                  ");
            Console.WriteLine("==================================================");
            Console.WriteLine("   Hint: Use comma separated input.               ");
            Console.WriteLine(" Example:  3,5,6 [Enter Key]                      ");
            Console.WriteLine("==================================================");

        }

        public static void ShowWaitTimeInfo()
        {
             Console.WriteLine("==========================================================================");
            Console.WriteLine("                                                                   ");
            Console.WriteLine("           Input Acceptable Passenger Screening Wait Time          ");
            Console.WriteLine("             The maximum allowed Wait Time is 60 minutes           ");
            Console.WriteLine("                                                                   ");
            Console.WriteLine("==========================================================================");
            Console.WriteLine("    NOTE: Wait time is based upon:                           ");
            Console.WriteLine("                                   Number of passengers      ");
            Console.WriteLine("                                   Number of screening stations open      ");
            Console.WriteLine("                                   Time for each screening safeguard      ");
            Console.WriteLine("                                                                          ");
            Console.WriteLine("    ALSO: A low value here does not guarantee speedy screening            ");
            Console.WriteLine("==========================================================================");
            Console.WriteLine("==========================================================================");
            Console.WriteLine("   Hint: Type a whole number between 1 and 60.               ");
            Console.WriteLine(" Example:  35 [Enter Key]                      ");
            Console.WriteLine("         The above would set wait time to 35 minutes and would            ");
            Console.WriteLine("         allocate a sufficient number of available screening              ");
            Console.WriteLine("         stations to optimize processing of passengers to be                  ");
            Console.WriteLine("         within the selected wait time.                                       ");
            Console.WriteLine("============================================================================");
            Console.ReadLine();
        }
    }
   
}
