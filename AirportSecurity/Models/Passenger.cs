using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AirportSecurity.Models
{
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

   public class Passenger
    {
        [Key]
        public int PassangerId { get; set; }
        public string Name { get; set; }
        public List<ScreeningTasks> RequiredScreeningTasks { get; set; }
        public bool NoFly { get; set; } = false;
        public bool ScreeningRequired { get; set; } = true;
        public bool HasWheelChair { get; set; } = false;
        public int FlightId { get; set; }


        public void SetScreeningTasks(List<ScreeningTasks> screeningTasks)
        {
            screeningTasks.Add(ScreeningTasks.EmptyBelongings);
            screeningTasks.Add(ScreeningTasks.CollectBelongings);
           
            RequiredScreeningTasks = screeningTasks;

        }
    }

   


  


}
