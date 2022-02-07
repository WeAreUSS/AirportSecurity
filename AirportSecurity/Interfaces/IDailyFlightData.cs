using System;
using System.Collections.Generic;
using System.Text;

namespace AirportSecurity.Interfaces
{
    public interface IDailyFlightData
    {
        int DailyFlightDataId { get; set; }
        int Hour { get; set; }
        double PctEnterPlane { get; set; }
        double PctExitPlane { get; set; }
    }
}
