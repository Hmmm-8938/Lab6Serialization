using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;

namespace Lab6Serialization
{
    public class Program
    {
        static void Main(string[] args)
        {
            #pragma warning disable SYSLIB0011
            string event_txt = ($"{(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName)}\\event.txt");
            string text_txt = ($"{(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName)}\\text.txt");
            string event_json = ($"{(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName)}\\event.json");
            int index = 0;

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

            List<Event> eventListJSON = new List<Event>();
            eventListJSON.Add(j1);
            eventListJSON.Add(j2);
            eventListJSON.Add(j3);
            eventListJSON.Add(j4);

            string s1 = "Hackathon";

            // Using Binary Formatter
            SerializeEvent(e1, event_txt);
            Event e2 = (DeserializeEvent(event_txt, e1));

            foreach (Event JSON in eventListJSON)
            {
                Event j = new Event();
                SerializeJSON(j, event_json, index);
                j = (DeserializeJSON(event_json));
                Console.WriteLine(j);
            }
            

            WriteToFile(s1, text_txt);
            string s2 = (ReadFromFile(text_txt).ToUpper());
            

            Console.WriteLine($"\nExpected Program Output:" +
                              $"\n************************" +
                              $"\n{e2.EventNumber}" +
                              $"\n{e2.Location}" +
                              $"\nTech Competition" +
                              $"\nIn Word: {event_json}" +
                              $"\nThe First Character is: {event_json}" +
                              $"\nThe Middle Character is: {event_json}" +
                              $"\nThe Last Character is: {event_json}");
            Console.ReadKey();
        }

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
                Console.WriteLine(e1);
            }
            return e1;
        }

        // Using JSON for Serialization
        private static void SerializeJSON(Event j, string path, int index)
        {
            
            string stringJSON = JsonSerializer.Serialize(j);
            if (index == 0)
            {
                File.WriteAllText(path, stringJSON);
                index += 1;
            }
            else
            {
                File.AppendAllText(path, stringJSON);
            }
            Console.WriteLine("JSON serialization done");
        }

        private static Event DeserializeJSON(string path)
        {
            Event j = JsonSerializer.Deserialize<Event>(File.ReadAllText(path));
            Console.WriteLine("Deserializing using JSON");
            return j;
        }

        public static string ReadFromFile(string path)
        {
            string line = "";
            using (StreamReader sr = new StreamReader(path))
            {
                return line;
            }
        }

        public static void WriteToFile(string s1, string path)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine(s1);
            }
        }
    }
}
