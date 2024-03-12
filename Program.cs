using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;

namespace Lab6Serialization
{
    // Program class the main code that is run...
    public class Program
    {
        // Main Method
        static void Main(string[] args)
        {
            // Disables a warning that was causing problems with Binary Serialization
            #pragma warning disable SYSLIB0011

            // Definitions of the Various File Paths Used in this project
            string event_txt = ($"{(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName)}\\event.txt");
            string text_txt = ($"{(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName)}\\text.txt");
            string event_json = ($"{(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName)}\\event.json");

            // Defining the various events that are used in this program
            Event e1 = new Event()
            {
                EventNumber = 1,
                Location = "Calgary"
            };
            Event j1 = new Event()
            {
                EventNumber = 1,
                Location = "#4 Privet Drive"
            };
            Event j2 = new Event()
            {
                EventNumber = 2,
                Location = "Diagon Alley"
            };
            Event j3 = new Event()
            {
                EventNumber = 3,
                Location = "Gringotts"
            };
            Event j4 = new Event()
            {
                EventNumber = 4,
                Location = "Hogwarts"
            };

            // Defining a List of type Event (Object) and adding the events for JSON Serialization to the list
            List<Event> eventListJSON = new List<Event>();
            eventListJSON.Add(j1);
            eventListJSON.Add(j2);
            eventListJSON.Add(j3);
            eventListJSON.Add(j4);

            // Defining the string Hackathon for use with Writing to text.txt
            string s1 = "Hackathon";

            /* Serializing and Deserializing the event e1
             * and storing in e2 to ensure it is a separate
             * event that is being printed out to the console
             */
            SerializeEvent(e1, event_txt);
            Event e2 = (DeserializeEvent(event_txt, e1));
            Console.WriteLine(e2);

            // Will run the Serialization and deserialization of all the events in eventListJSON which was definied above.
            foreach (Event json in eventListJSON)
            {
                SerializeJSON(json, event_json);
                Event jDeserialized = (DeserializeJSON(event_json));
                Console.WriteLine($"{jDeserialized}\n");
            }
            
            // Will write the string containing "Hackathon" to a text file 
            WriteToFile(s1, text_txt);
            /* Will read the work "Hackathon" from the text.txt file and 
             * then convert the string to uppercase as it was bugging me 
             * that it looked different when printed on separate lines 
             * on the lab documentation */
            string s2 = (ReadFromFile(text_txt).ToUpper());
            
            // Prints a string which contains the expected program output after reading in the stuff from text.txt
            Console.WriteLine($"\nExpected Program Output:" +
                              $"\n************************" +
                              $"\n{e2.EventNumber}" +
                              $"\n{e2.Location}" +
                              $"\nTech Competition" +
                              $"\nIn Word: {s2}" +
                              $"\nThe First Character is: {s2[0]}" +
                              $"\nThe Middle Character is: {s2[4]}" +
                              $"\nThe Last Character is: {s2[8]}");
        }

        // METHODS
        

        
        // Create a bin file to serialize the object
        public static void SerializeEvent(Event s, string path)
        {
            // Creating a BinaryFormatter object to serialize the object
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                // serializing the student object
                binaryFormatter.Serialize(fs, s);
            }
        }

        // Deserializing the contents of the event.txt file
        private static Event DeserializeEvent(string path, Event e1)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                // deserialize the txt file and cast it into a Event object
                // return type of Deserialize is Object Class.
                e1 = (Event)binaryFormatter.Deserialize(fs);
            }
            return e1;
        }

        // Serialization JSON
        private static void SerializeJSON(Event j, string path)
        {
            string stringJSON = JsonSerializer.Serialize(j);
            File.WriteAllText(path, stringJSON);
        }

        // Deserializing JSON
        private static Event DeserializeJSON(string path)
        {
            Event j = JsonSerializer.Deserialize<Event>(File.ReadAllText(path));
            return j;
        }

        // Writing to a file
        public static void WriteToFile(string s1, string path)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine(s1);
            }
        }

        // Reading from a file
        public static string ReadFromFile(string path)
        {
            string line = "";
            using (StreamReader sr = new StreamReader(path))
            {
                line = sr.ReadLine();
                return line;
            }
        }
    }
}
