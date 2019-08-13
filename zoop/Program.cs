using System;

namespace zoop
{
    public class Program
    {

        public string ShowWelcome()
        {
            string msg =  " *** WELCOME at the ***\n"
                + "three PENGUINS\n" 
                + "and a POLARBEAR\n"
                + "ZOO";

            return msg;
        }

        static void Main(string[] args)
        {
            Program zoo = new Program();

            // Start with message
            Console.WriteLine(zoo.ShowWelcome());
        }
    }
}
