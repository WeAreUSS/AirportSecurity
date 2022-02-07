using System;
using System.Collections.Generic;
using System.Text;

namespace AirportSecurity.Interfaces
{
    public interface IMonthlyFlightData
    {
        int MonthlyFlightDataId { get; set; }
        string MonthName { get; set; }
        int MonthNbr { get; set; }
        int MonthDays { get; set; }
        double PassAvgDay { get; set; }
        int EnterPlaneCount { get; set; }
        int ExitPlaneCount { get; set; }
        int AirportEntryCount { get; set; }
        double JustVisitingPct { get; set; }
        double ScreeningPct { get; set; }
        double NewTripPct { get; set; }
        double ContinueTripPct { get; set; }
        double InOutSameDayVisitPct { get; set; }
    }
}
