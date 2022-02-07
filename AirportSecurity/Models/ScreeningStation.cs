using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using AirportSecurity.Interfaces;

namespace AirportSecurity.Models
{
   

    public class ScreeningStation : IScreeningStation
    {
        [Key]
        public int StationId { get { return _stationId; }}
        public int PassengersInQueue{ get; set; }
        public List<ScreeningTask> Tasks  { get; set; }
        public bool IsOpen { get; set; }
        public int OpenHour { get; set; }
        public int CloseHour { get; set; }
        public int LineCount { get; set; } // Nbr of conveyor belts
        public List<SecurityPersonnel> Supervisors  { get; set; }
        public int AllowedWaitTime  { get; set; }

        private int _stationId;
        
        public ScreeningStation(int allowedWaitTime, int stationId)
        {
            _stationId = stationId;
            AllowedWaitTime = allowedWaitTime;
            InitializeTasks();
        }

        private void InitializeTasks()
        {
            Tasks = new List<ScreeningTask>();
            for (int x = 1; x < 9; x++)
            {
                ScreeningTask myTask = new ScreeningTask(x);
                if (x == (int)ScreeningTasks.EmptyBelongings)
                {
                    myTask.TaskName = "Empty Belongings Onto Conveyor";
                    myTask.PercentUse = 100;
                    myTask.ProcessTimeSec = 120;
                }

                if(x==(int)ScreeningTasks.CollectBelongings)
                {
                    myTask.TaskName = "Collect Belongings From Conveyor";
                    myTask.PercentUse = 100;
                    myTask.ProcessTimeSec = 60;
                }
                  
                if(x==(int)ScreeningTasks.Bio)
                {
                    myTask.TaskName = "Perform Biological Scan";
                    myTask.PercentUse = 100;
                }
                   
                if(x==(int)ScreeningTasks.Chem)
                {
                    myTask.TaskName = "Perform Chemical Scan";
                    myTask.PercentUse = 100;
                }
                    
                if(x==(int)ScreeningTasks.ExtendedScreening)
                {
                    myTask.TaskName = "Perform Extended Screening";
                    myTask.PercentUse = 0.1;
                    myTask.ProcessTimeSec = 240;
                }
                   
                if(x==(int)ScreeningTasks.MetalDetector)
                {
                    myTask.TaskName = "Perform Metal Scan";
                    myTask.PercentUse = 100;
                    myTask.ProcessTimeSec = .10;
                }
                   
                if(x==(int)ScreeningTasks.X_Ray)
                {
                    myTask.TaskName = "Perform X-Ray Scan";
                    myTask.PercentUse = 100;
                }
                   
                if(x==(int)ScreeningTasks.Puffer)
                {
                    myTask.TaskName = "Perform Puffer Test";
                    myTask.PercentUse = 0.02;
                    myTask.ProcessTimeSec = 60;
                }
                   
                if(x==(int)ScreeningTasks.WheelChair)
                {
                    myTask.TaskName = "Perform Wheelchair Examination";
                    myTask.PercentUse = 0.05;
                    myTask.ProcessTimeSec = 90;
                }

                myTask.Required = true;
                myTask.Available = true;

                Tasks.Add(myTask);
            }

        }
    }
}
