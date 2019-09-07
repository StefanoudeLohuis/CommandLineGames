using System;

namespace CommandlineRAWNS
{
    class CommandlineRAW
    {

        //Speed in milliseconds
        private int slowest = 500;
        private int slower = 400;
        private int slow = 300;
        private int mediumst = 200; // Dont question it :)
        private int mediumer = 100; // Dont question it :)
        private int medium = 50;
        private int fast = 25;
        private int faster = 15;
        private int fastest = 5;
        private int pause = 500;

        private char pauseCharacter = '%';
        private char enterCharacter = '#';
        private string lineBreak = "\n";

        public CommandlineRAW() { }

        public string readCommandline(Boolean withEnter)
        {
            String userInput = Console.ReadLine();
            if (withEnter)
            {
                //After the user writes his message an enter will follow.
                writeToCommandline("" + enterCharacter, "Fast");
            }
            return userInput;
        }

        public void writeToCommandline(string input, string speed)
        {
            switch (speed)
            {
                case "Slowest":
                    write(input, slowest);
                    break;
                case "Slower":
                    write(input, slower);
                    break;
                case "Slow":
                    write(input, slow);
                    break;
                case "Mediumst":
                    write(input, mediumst);
                    break;
                case "Mediumer":
                    write(input, mediumer);
                    break;
                case "Medium":
                    write(input, medium);
                    break;
                case "Fast":
                    write(input, fast);
                    break;
                case "Faster":
                    write(input, faster);
                    break;
                case "Fastest":
                    write(input, fastest);
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
                if (ch.Equals(enterCharacter))
                {
                    Console.Write(lineBreak);
                    System.Threading.Thread.Sleep(speed);
                }
                else if (ch.Equals(pauseCharacter))
                {
                    System.Threading.Thread.Sleep(pause);
                }
                else
                {
                    Console.Write(ch);
                    System.Threading.Thread.Sleep(speed);
                }
            }
        }

        public string getEnter(int amount = 1)
        {
            return xAmountOfCharacters(amount, enterCharacter);
        }

        public string getPause(int amount = 1)
        {

            return xAmountOfCharacters(amount, pauseCharacter);
        }

        private string xAmountOfCharacters(int amount, char ch)
        {
            string message = "";

            for (int i = 0; i < amount; i++)
            {
                message += ch;
            }

            return message;
        }
    }
}