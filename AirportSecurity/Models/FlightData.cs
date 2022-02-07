using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml;
using AirportSecurity.Interfaces;

namespace AirportSecurity.Models
{
    public class FlightData : IFlightData
    {
        [Key]
        public int FlightDataId { get; set; }
        public int DataYear { get; set; }
        public List<IMonthlyFlightData> YearlyFlightData { get; set; }
        public List<IDailyFlightData> DailyFlightData { get; set; }


        public FlightData InitializeYearlyFlightData(List<int> EnPlanedPassYear, List<int> DePlanedPassYear, List<double> EnPlaneHours, List<double> DePlaneHours)
        {
            FlightData thisYearsFlightData = new FlightData();
            thisYearsFlightData.FlightDataId = 1;
            thisYearsFlightData.DataYear = 2008;
            thisYearsFlightData.YearlyFlightData = new List<IMonthlyFlightData>();
            // handle months initialization
            for (int x = 1; x < 13; x++)
            {
                MonthlyFlightData thisMonth = new MonthlyFlightData();
                thisMonth.MonthlyFlightDataId = x;
                thisMonth.MonthNbr = x;

                DateTime date = new DateTime(thisYearsFlightData.DataYear, x, 1);
                thisMonth.MonthName = date.ToString("MMM") + "- " + thisYearsFlightData.DataYear.ToString();

                thisMonth.EnterPlaneCount = EnPlanedPassYear[x-1];
                thisMonth.ExitPlaneCount = DePlanedPassYear[x-1];

                // Set baselines
                thisMonth.MonthDays = DateTime.DaysInMonth(thisYearsFlightData.DataYear, x);;
                thisMonth.PassAvgDay = int.Parse((thisMonth.EnterPlaneCount/thisMonth.MonthDays).ToString());

                thisYearsFlightData.YearlyFlightData.Add(thisMonth);
            }

            thisYearsFlightData = InitializeDailyFlightData( thisYearsFlightData, EnPlaneHours, DePlaneHours);

            return thisYearsFlightData;
        }

        private FlightData InitializeDailyFlightData(FlightData thisYearsFlightData, List<double> EmplanedPlaneHours, List<double> DeplanedPlaneHours)
        {
            List<IDailyFlightData> DailyFlightData = new List<IDailyFlightData>();

            for (int x = 0; x < 24; x++)
            {
                IDailyFlightData thisHoursData = new DailyFlightData();
                thisHoursData.Hour = x;
                thisHoursData.PctEnterPlane = EmplanedPlaneHours[x];
                thisHoursData.PctExitPlane = DeplanedPlaneHours[x];
                thisHoursData.DailyFlightDataId = x + 1;
                DailyFlightData.Add(thisHoursData);
            }
            thisYearsFlightData.DailyFlightData = DailyFlightData;

            return thisYearsFlightData;
        }
    }

    public class MonthlyFlightData : IMonthlyFlightData
    {
        [Key]
        public int MonthlyFlightDataId { get; set; }
        public string MonthName{ get; set; }
        public int MonthNbr { get; set; }
        public int MonthDays { get; set; }
        public double PassAvgDay { get; set; }
        public int EnterPlaneCount  { get; set; }
        public int ExitPlaneCount { get; set; }
        public int AirportEntryCount { get; set; }
        public double JustVisitingPct { get; set; }
        public double ScreeningPct { get; set; }
        public double NewTripPct { get; set; }
        public double ContinueTripPct { get; set; }
        public double InOutSameDayVisitPct { get; set; }
    }

    public class DailyFlightData : IDailyFlightData
    {
        [Key]
        public int DailyFlightDataId { get; set; }
  
        public int Hour { get; set; }
        public double PctEnterPlane { get; set; }
        public double PctExitPlane { get; set; }
       
    }

}
