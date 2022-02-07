using System;
using System.Collections.Generic;
using System.Text;
using AirportSecurity.Models;

namespace AirportSecurity.Interfaces
{
    public interface IScreeningStation
    {
        int StationId { get; }
        int PassengersInQueue { get; set; }
        List<ScreeningTask> Tasks { get; set; }
        bool IsOpen { get; set; }
        int OpenHour { get; set; }
        int CloseHour { get; set; }
        int LineCount { get; set; } // Nbr of conveyor belts
        List<SecurityPersonnel> Supervisors { get; set; }
        int AllowedWaitTime { get; set; }
    }
}
