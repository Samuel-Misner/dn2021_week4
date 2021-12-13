using System;

namespace TestDemo1
{
    class Program
    {
        static string Reverse(string str)
        {
            string returnString = "";
            for (int i = str.Length - 1; i >= 0; i--)
            {
                returnString += str[i];
            }
            return returnString;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(Reverse("word"));
        }
    }
}
