using System;
using System.Collections.Generic;
using System.Text;
using AirportSecurity.Models;

namespace AirportSecurity.Interfaces
{
    public interface IFlightData
    {
        int FlightDataId { get; set; }
        int DataYear { get; set; }
        List<IMonthlyFlightData> YearlyFlightData { get; set; }
        List<IDailyFlightData> DailyFlightData { get; set; }

        FlightData InitializeYearlyFlightData(List<int> EnPlanedPassYear, List<int> DePlanedPassYear, List<double> EnPlaneHours, List<double> DePlaneHours);
        // FlightData InitializeDailyFlightData(FlightData thisYearsFlightData);
    }
}
