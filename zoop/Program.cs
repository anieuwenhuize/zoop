using System;

namespace zoop
{
    public class Program
    {
        int penguinOneEngergy;
        int penguinTwoEngergy;
        int penguinThreeEngergy;

        public Program()
        {
            penguinOneEngergy = 100;
            penguinTwoEngergy = 100;
            penguinThreeEngergy = 100;
        }

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

        public void FeedPenguinOne(int energy)
        {
            this.penguinOneEngergy += energy;
            Say("Penguin 1 feeded.");
        }

        public void FeedPenguinTwo(int energy)
        {
            this.penguinTwoEngergy += energy;
            Say("Penguin 2 feeded.");
        }

        public void FeedPenguinThree(int energy)
        {
            this.penguinThreeEngergy += energy;
            Say("Penguin 3 feeded.");
        }

        public void ShowNoPenguinFeeded()
        {
            Say("The zoo caretaker ate the fish himself.");
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

        /**
         * The zoo caretaker feeds one of the penguins
         */
        public void FeedPenguin()
        {
            int fish = 50;

            int penguinNumber = GetNumber(1, 3);

            switch(penguinNumber)
            {
                case 1: FeedPenguinOne(fish); break;
                case 2: FeedPenguinTwo(fish); break;
                case 3: FeedPenguinThree(fish); break;
                default: ShowNoPenguinFeeded(); break;
            }
        }

        public int GetNumber(int from, int to)
        {
            var rand = new Random();
            return rand.Next(from, to);
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

                    // feed penguin command
                    case "feed penguin":
                        zoo.FeedPenguin();
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
