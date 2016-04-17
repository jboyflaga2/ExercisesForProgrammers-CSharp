using System;

namespace PrintingQuotes
{
    public class Program
    {
        
        public static void Main(string[] args)
        {
            Console.WriteLine("What is the quote? ");
            var quote = Console.ReadLine();
            Console.WriteLine("Who said it? ");
            var author = Console.ReadLine();
            Console.WriteLine("{0} says, \" {1}\"", quote, author);            
        }
    }    
}
