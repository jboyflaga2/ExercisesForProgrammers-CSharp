using System;
using System.IO;

namespace SayingHello
{
    public class Program
    {
        
        public static void Main(string[] args)
        {
            Console.WriteLine("What is your name?");
            Console.WriteLine("Hello, {0}, nice to meet you!", Console.ReadLine());            
        }
    }
    
    /*
    public class Program
    {        
        public static void Main(string[] args)
        {
            Console.WriteLine("What is your name?");
            Console.WriteLine("Hello, {0}, nice to meet you!", Console.ReadLine());
            
            //for Console.Out cf. https://msdn.microsoft.com/en-us/library/system.console.out(v=vs.110).aspx            
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            sw.AutoFlush = true;
            Console.SetOut(sw);
            StreamReader reader = new StreamReader(Console.OpenStandardInput());            
            
            Greeter greeting = new Greeter(sw, Console.In);
            greeting.DisplayGreeting(string.Format("Hello, {0}, nice to meet you!", greeting.GetName("What is your name?")));
        }
    }
    
    public class Greeter
    {
        StreamWriter _outputStream;
        StreamReader _inputStream;
        
        public Greeter(StreamWriter outputStream, StreamReader inputStream)
        {
            _outputStream = outputStream;
            _inputStream = inputStream;
        }
        
        public string GetName(string prompt)
        {
            Console.WriteLine(prompt);
            return Console.ReadLine();
        }
        
        public void DisplayGreeting(string greeting)
        {
            Console.WriteLine(greeting);
        }
    }
    */
}
