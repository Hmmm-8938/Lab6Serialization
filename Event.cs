using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6Serialization
{
    // Making this class serializable
    [Serializable]
    public class Event
    {
        public int EventNumber { get; set; }
        public string Location { get; set; }

        public Event()
        {
            
        }

        public override string ToString()
        {
            return ($"Event Details" +
                  $"\n*************" +
                  $"\nEvent Number: {EventNumber}" +
                  $"\nLocation: {Location}");
        }
    }
}
