using System;

namespace zoop
{
    public class Program
    {
        private int penguinOneEngergy;
        private int penguinTwoEngergy;
        private int penguinThreeEngergy;

        private int polarBearEnergy;
        private const int polarBearStarvationEngergyThreshold = 150;

        public Program()
        {
            penguinOneEngergy = 100;
            penguinTwoEngergy = 100;
            penguinThreeEngergy = 100;
            polarBearEnergy = 1000;
        }

        public void ShowWelcome()
        {
            string msg =  " ***  WELCOME at the  ***\n"
                        + "   *  three PENGUINS  *\n" 
                        + "   *  and a POLARBEAR *\n"
                        + "   *      ZOO         *";

            Say(msg);
        }

        public void ShowInstructions()
        {
            string msg = "You must feed the animals to keepup the zoo.\n"
                + "Use 'new day' to advance to the next day"
                + "Use 'feed penguin' to throw a fish to the penguins"
                + "Take care that all penguins are fed"
                + "Oh, and dont forget the polar bear.";

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

        public bool IsPolarBearAlive()
        {
            return this.polarBearEnergy > 0;
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

        public void FeedPolarBear(int energy)
        {
            this.polarBearEnergy += energy;
            Say("Polar bear snatches a fish.");
        }

        public void PolarBearHuntsPenguinOne()
        {
            this.polarBearEnergy += this.penguinOneEngergy;
            this.penguinOneEngergy = 0;

            Say("The polar bear has eaten a penguin!");
        }

        public void PolarBearHuntsPenguinTwo()
        {
            this.polarBearEnergy += this.penguinTwoEngergy;
            this.penguinTwoEngergy = 0;

            Say("The polar bear has eaten a penguin!");
        }

        public void PolarBearHuntsPenguinThree()
        {
            this.polarBearEnergy += this.penguinThreeEngergy;
            this.penguinThreeEngergy = 0;

            Say("The polar bear has eaten a penguin!");
        }

        /**
         * Avoid starvation, try to catch a penguin
         */
        public void PolarBearHunts()
        {
            int penguinNumber = GetNumber(1, 3);

            switch (penguinNumber)
            {
                case 1:
                    if (IsPenguinOneAlive()) PolarBearHuntsPenguinOne(); break;

                case 2:
                    if (IsPenguinTwoAlive()) PolarBearHuntsPenguinTwo(); break;

                case 3:
                    if (IsPenguinThreeAlive()) PolarBearHuntsPenguinThree(); break;

                default: ShowNoPenguinToHunt(); break;
            }
        }

        public void ShowNoPenguinToHunt()
        {
            Say("There is no penguin left to hunt for the polar bear. You better be careful!");
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

        public void FeedPolarBear()
        {
            int fish = 50;

            this.polarBearEnergy += fish;
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
                    penguinMsg = "Three penguins and a polar bear."; break;
                case 2:
                    penguinMsg = "Two penguins and a polar bear."; break;
                case 1:
                    penguinMsg = "One penguin and a polar bear."; break;
                case 0:
                    penguinMsg = "Just a lonely dead? polar bear."; break;
            }

            Say(penguinMsg);
        }

        public int GetNumber(int from, int to)
        {
            var rand = new Random();
            return rand.Next(from, to);
        }

        public bool IsPolarBearStarving()
        {
            return this.polarBearEnergy <= polarBearStarvationEngergyThreshold;
        }

        /**
         * Each day, the animals consume energy
         */
        public void DayChange()
        {
            int penguinEnergyUsedForADay = 30;
            int polarBearEngergyUsedForADay = 300;
            

            this.penguinOneEngergy -= penguinEnergyUsedForADay;
            this.penguinTwoEngergy -= penguinEnergyUsedForADay;
            this.penguinThreeEngergy -= penguinEnergyUsedForADay;

            this.polarBearEnergy -= polarBearEngergyUsedForADay;


            if (IsPolarBearStarving()) PolarBearHunts();

            Say(" *** A new day is comming. ***");
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

                    // feed penguin command
                    case "feed polar bear":
                        zoo.FeedPolarBear();
                        break;

                    // new day command
                    case "new day":
                        zoo.DayChange();
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
