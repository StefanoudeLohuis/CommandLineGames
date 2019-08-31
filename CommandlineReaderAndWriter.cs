using System;

namespace CommandlineRAWNS
{
    class CommandlineRAW
    {

        //Speed in seconds
        private int slowSpeed = 100;
        private int mediumSpeed = 50;
        private int fastSpeed = 25;
        private int longBreak = 1000;

        private char pause = '%';
        private char enter = '#';

        private string badInputMessage = "---Incorrect Input---#";

        public CommandlineRAW() { }

        public string readCommandline(Boolean withEnter)
        {
            String userInput = Console.ReadLine();
            if (withEnter)
            {
                //After the user writes his message an enter will follow.
                writeToCommandline("" + enter, "Fast");
            }
            return userInput;
        }

        public void writeToCommandline(string input, string speed)
        {
            switch (speed)
            {
                case "Slow":
                    write(input, slowSpeed);
                    break;
                case "Medium":
                    write(input, mediumSpeed);
                    break;
                case "Fast":
                    write(input, fastSpeed);
                    break;
                default:
                    break;
            }
        }

        private void write(string input, int speed)
        {
            char[] charArray = input.ToCharArray();

            foreach (char ch in charArray)
            {
                if (ch.Equals(enter))
                {
                    Console.Write("\n");
                    System.Threading.Thread.Sleep(speed);
                }
                else if (ch.Equals(pause))
                {
                    System.Threading.Thread.Sleep(longBreak);
                }
                else
                {
                    Console.Write(ch);
                    System.Threading.Thread.Sleep(speed);
                }
            }
        }

        public char getEnter()
        {
            return enter;
        }

        public char getPause()
        {
            return pause;
        }

        public void displayBadInputMessage()
        {
            writeToCommandline(badInputMessage, "Medium");
        }
    }
}