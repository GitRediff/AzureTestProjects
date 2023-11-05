namespace ConsoleSamples
{
        //public class StringHelper
    //{
    //    public string MakeUpperCase(string input)
    //    {
    //        return input.ToUpper();
    //    }
    //}

    public static class StringHelper
    {
        public static string MakeUpperCase(this string input)
        {
            return input.ToUpper();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            //StringHelper objStrHelp = new StringHelper();
            string name = "mahesh";

            string upperCase = name.MakeUpperCase();
            Console.WriteLine(upperCase);

            Console.ReadKey();
        }
    }


}