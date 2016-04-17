using System;

namespace CountingTheNumberofCharacters
{
    public class Program
    {
        
        public static void Main(string[] args)
        {
            Console.WriteLine("What is the input string?");
            var inputString = Console.ReadLine();
            Console.WriteLine("{0} has {1} characters", inputString, inputString.Length);            
        }
    }    
}
