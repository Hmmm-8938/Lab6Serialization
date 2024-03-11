using System.Runtime.Serialization.Formatters.Binary;

namespace Lab6Serialization
{
    public class Program
    {
        static void Main(string[] args)
        {
            #pragma warning disable SYSLIB0011
            string event_txt = $"{(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName)}\\event.txt";
            string text_txt = $"{(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName)}\\text.txt";
            string s1 = "";

            Event e1 = new Event()
            {
                EventNumber = 1,
                Location = "Calgary"
            };

            // Using Binary Formatter
            SerializeEvent(e1, event_txt);
            ReadFromFile(text_txt);
            string s2 = (DeserializeString(text_txt, s1).ToUpper());
            Event e2 = (DeserializeEvent(event_txt, e1));

            Console.WriteLine($"\nExpected Program Output:" +
                              $"\n************************" +
                              $"\n{e2.EventNumber}" +
                              $"\n{e2.Location}" +
                              $"\nTech Competition" +
                              $"\nIn Word: {s2}" +
                              $"\nThe First Character is: {s2[0]}" +
                              $"\nThe Middle Character is: {s2[4]}" +
                              $"\nThe Last Character is: {s2[8]}");
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

        private static String DeserializeString(string path, string s1)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                // deserialize the txt file and cast it into a String object
                // return type of Deserialize is Object Class.
                s1 = (String)binaryFormatter.Deserialize(fs);
            }
            return s1;
        }


        public static void ReadFromFile(string path)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                // serializing the student object
                binaryFormatter.Serialize(fs, "Hackathon");
            }
        }
    }
}
