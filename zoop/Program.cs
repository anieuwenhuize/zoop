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

        public bool IsPenguinOneAlive()
        {
            return this.penguinOneEngergy > 0;
        }

        public bool IsPenguinTwoAlive()
        {
            return this.penguinTwoEngergy > 0;
        }

        public bool IsPenguinThreeAlive()
        {
            return this.penguinThreeEngergy > 0;
        }

        public void FeedPenguinOne(int energy)
        {
            this.penguinOneEngergy += energy;
            Say("Penguin 1 snatches a fish.");
        }

        public void FeedPenguinTwo(int energy)
        {
            this.penguinTwoEngergy += energy;
            Say("Penguin 2 snatches a fish.");
        }

        public void FeedPenguinThree(int energy)
        {
            this.penguinThreeEngergy += energy;
            Say("Penguin 3 snatches a fish.");
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
                case 1:
                    if(IsPenguinOneAlive() ) FeedPenguinOne(fish); break;

                case 2:
                    if (IsPenguinTwoAlive()) FeedPenguinTwo(fish); break;

                case 3:
                    if (IsPenguinThreeAlive()) FeedPenguinThree(fish); break;

                default: ShowNoPenguinFeeded(); break;
            }
        }

        public void ShowStatus()
        {
            int numberOfPinguins = 0;
            if (IsPenguinOneAlive() ) numberOfPinguins++;
            if (IsPenguinTwoAlive()) numberOfPinguins++;
            if (IsPenguinThreeAlive()) numberOfPinguins++;

            string penguinMsg = "";

            switch(numberOfPinguins)
            {
                case 3:
                    penguinMsg = "Three penguins"; break;
                case 2:
                    penguinMsg = "Two penguins"; break;
                case 1:
                    penguinMsg = "One penguin"; break;
                case 0:
                    penguinMsg = "No penguins"; break;
            }

            Say(penguinMsg);
        }

        public int GetNumber(int from, int to)
        {
            var rand = new Random();
            return rand.Next(from, to);
        }

        /**
         * Each day, the animals consume energy
         */
        public void LiveALife()
        {
            int energyUsedForADay = 30;

            penguinOneEngergy -= energyUsedForADay;
            penguinTwoEngergy -= energyUsedForADay;
            penguinThreeEngergy -= energyUsedForADay;
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
                    case "close": case "quit": case "exit":
                        zoo.CloseApp();
                        break;

                    // feed penguin command
                    case "feed penguin":
                        zoo.FeedPenguin();
                        break;

                    // new day command
                    case "new day":
                        zoo.LiveALife();
                        zoo.ShowStatus();
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
