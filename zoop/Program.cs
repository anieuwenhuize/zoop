using System;

namespace zoop
{
    public class Program
    {

        public void ShowWelcome()
        {
            string msg =  " *** WELCOME at the ***\n"
                + "three PENGUINS\n" 
                + "and a POLARBEAR\n"
                + "ZOO";

            Say(msg);
        }

        /**
         * Output text to the user
         */
        public static void Say(String msg)
        {
            Console.WriteLine(msg);
        }

        public void ShowGoodBye()
        {
            Say("bye ...");
        }

        public void ShowWhatDoYouWant(String cmd)
        {
            string msg = $"The Zoo caretaker does not understand '{cmd}'.";

            Say(msg);
        }

        public void CloseApp()
        {
            ShowGoodBye();
            Environment.Exit(0);
        }

        static void Main(string[] args)
        {
            Program zoo = new Program();

            // Start with message
            zoo.ShowWelcome();

            // listen for commands
            while(true)
            {
                string cmd = Console.ReadLine();

                switch (cmd)
                {
                    // close command
                    case "close": 
                    case "quit":
                            zoo.CloseApp();
                            break;

                    // unknown command
                    default:
                        zoo.ShowWhatDoYouWant(cmd);
                        break;

                }
            }
        }
    }
}
