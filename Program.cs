namespace dictionary_writer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string? separator;
            Console.WriteLine("Provide a separator for key-value:");
            separator = Console.ReadLine();
            if(string.IsNullOrEmpty(separator))
            {
                separator = "/";
                Console.WriteLine("separator was not provided default is /");
            }
            Console.WriteLine("Provide a name for your dictionary:");
            string? nameOfDictionary = Console.ReadLine();
            if (string.IsNullOrEmpty(nameOfDictionary))
            {
                long unixTime = new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds();
                Console.WriteLine($"No name was provided name would be:{unixTime}.txt");
                nameOfDictionary = $"{unixTime}";
            }
            Console.WriteLine("Provide first language:");
            string? firstLanguage = Console.ReadLine();
            if (string.IsNullOrEmpty(firstLanguage))
            {
                firstLanguage = "key";
            }

            Console.WriteLine("Provide second language:");
            string? secondLanguage = Console.ReadLine();
            if (string.IsNullOrEmpty(secondLanguage))
            {
                secondLanguage = "key";
            }




            int counter = 0;
            
            
            if(!File.Exists($"{nameOfDictionary}.txt"))
            {
                File.WriteAllText($"{nameOfDictionary}.txt", $"{firstLanguage}{separator}{secondLanguage}\n");
            }
            Console.WriteLine("To exit writing write /e");
            while (true)
            {
                string key,value;
                counter++;
                Console.WriteLine($"Provide key number:{counter}\n");
                key = Console.ReadLine();
                if(key == "/e")
                {
                    break;
                }
                Console.WriteLine($"Provide value number:{counter}\n");
                value = Console.ReadLine();
                if(value == "/e")
                {
                    break;
                }
                string temp = $"{key}{separator}{value}\n";
                File.AppendAllText($"{nameOfDictionary}.txt", temp);
            }
            Console.WriteLine($"File is stored in {Directory.GetCurrentDirectory()}");
        }
    }
}