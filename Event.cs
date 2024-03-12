using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6Serialization
{
    // Making this class serializable
    [Serializable]
    // This is the Event class has 2 class variables EventNumber and Location
    public class Event
    {
        public int EventNumber { get; set; }
        public string Location { get; set; }

        // Default Constructor
        public Event()
        {
            
        }

        // The to string method which will display the details of the Event
        public override string ToString()
        {
            return ($"Event Details" +
                  $"\n*************" +
                  $"\nEvent Number: {EventNumber}" +
                  $"\nLocation: {Location}");
        }
    }
}
