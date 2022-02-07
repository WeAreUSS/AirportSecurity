using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AirportSecurity.Models
{
    public class ScreeningTask
    {
        [Key]
        public int TaskId { get { return _taskId; }  }
        public string TaskName { get; set; }
        public int QueueedPassengers { get; set; }
        public double ProcessTimeSec { get; set; }
        public double PercentUse { get; set; }
        public bool Available { get; set; }
        public bool Required { get; set; }
        public IEnumerable<SecurityPersonnel> Operators  { get; set; }

        private int _taskId;
        public enum ScreeningTasks 
        {
            EmptyBelongings,
            WheelChair,
            Puffer,
            ExtendedScreening,
            MetalDetector,
            X_Ray,
            Bio,
            Chem,
            CollectBelongings
        }

        public ScreeningTask(int taskId)
        {
            _taskId = taskId;
        }

     
    }
}
