using System;

namespace PrintingQuotes
{
    public class Program
    {
        
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter a noun: ");
            var noun = Console.ReadLine();            
            
            Console.WriteLine("Enter a verb: ");
            var verb = Console.ReadLine();
            
            Console.WriteLine("Enter a adjective: ");
            var adjective = Console.ReadLine();
            
            Console.WriteLine("Enter a adverb: ");
            var adverb = Console.ReadLine();
                        
            Console.WriteLine("Do you {0} your {1} {2} {3}? That's hilarious!", verb, adjective, noun, adverb);            
        }
    }    
}
