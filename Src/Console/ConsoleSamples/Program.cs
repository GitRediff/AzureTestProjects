namespace ConsoleSamples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Warrior> warriors = new List<Warrior>()
            {
                new Warrior() { Name="Prasad", Height=172 },
                new Warrior() { Name="Mahesh", Height=169 },
                new Warrior() { Name="Mahendra", Height=172 }
            };

            var output = warriors
                        .GroupBy(x => x.Height)//.ToList();
                        .Select(x => new
                        {
                            value = x.Key,
                            count = x.Count()
                        }
                        );

            foreach (var item in output)
            {
                //Console.WriteLine(item.Key + " " + item.Count());
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }
    }

    internal class Warrior
    {
        public string Name { get; set; }
        public int Height { get; set; }
    }
}