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

        public string ShowGoodBye()
        {
            return "bye ...";
        }

        public void CloseApp()
        {
            Console.WriteLine(ShowGoodBye());
            Environment.Exit(0);
        }

        static void Main(string[] args)
        {
            Program zoo = new Program();

            // Start with message
            Console.WriteLine(zoo.ShowWelcome());

            // listen for commands
            while(true)
            {
                string cmd = Console.ReadLine();

                switch (cmd)
                {
                    case "close": 
                    case "quit":
                    default:
                        {
                            zoo.CloseApp();
                            break;
                        }
                        
                }
            }
        }
    }
}
