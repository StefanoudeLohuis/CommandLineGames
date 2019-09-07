using CommandlineRAWNS;
using Menus;
using System;

namespace games
{
    class ThreeDoorGame
    {
        private CommandlineRAW commandlineRAW = new CommandlineRAW();
        private string startMessage;
        private string goalObject;

        public ThreeDoorGame()
        {
            startMessage = "Welcome to the Three Door Game." + commandlineRAW.getPause() + commandlineRAW.getEnter() +
                            "In this game you'll find doors with 2 different things behind them." + commandlineRAW.getPause() + commandlineRAW.getEnter() +
                            "Behind most doors you'll find nothing but dust." + commandlineRAW.getPause() + commandlineRAW.getEnter() +
                            "But behind one door you'll find the ";
        }

        public void gameIntroduction()
        {
            commandlineRAW.writeToCommandline(startMessage, "Fast");

            this.goalObject = commandlineRAW.readCommandline(false);

            startMessage = "It's your job to find the " + goalObject + "." + commandlineRAW.getPause() + commandlineRAW.getEnter(2);
            commandlineRAW.writeToCommandline(startMessage, "Fast");
        }

        public void howManyDoorsText()
        {
            string text = "For this game we need doors. How many would you like?" + commandlineRAW.getEnter();
            commandlineRAW.writeToCommandline(text, "Medium");
        }

        public void userDoorSelectionText(int amountOfDoors)
        {
            string text = "We now have " + amountOfDoors + " doors. Behind one of them is the " + goalObject + "." + commandlineRAW.getPause() + commandlineRAW.getEnter() +
                            "Behind which door from 1 to " + amountOfDoors + " do you think it is?" + commandlineRAW.getPause() + commandlineRAW.getEnter();
            commandlineRAW.writeToCommandline(text, "Fast");
        }

        public void RemoveDoorsText(int selectedDoor, int remainingDoor)
        {
            string text = "All doors but 2 opened and revealed dust." + commandlineRAW.getPause() + commandlineRAW.getEnter() +
                            "Only your door " + selectedDoor + " and door number " + remainingDoor + " are left." + commandlineRAW.getPause() + commandlineRAW.getEnter();
            commandlineRAW.writeToCommandline(text, "Fast");
        }

        public void play()
        {

            //Part One. Let the user decide how many doors he wants.
            howManyDoorsText();
            int amountOfDoors = getNumberBetween(3, 100);
            //---------------------------------------

            //Part Two. Create the doors.
            bool[] doors = createDoors(amountOfDoors);
            //---------------------------------------

            //Part Three. Let the user decide which door he thinks the price is behind.
            userDoorSelectionText(amountOfDoors);
            int selectedDoor = getNumberBetween(1, amountOfDoors) - 1;
            //Part Four. "Erase" the doors behind which the prize isn't.
            //If he picked the door where the prize is behind, a random door will be returned.
            //If he didn't pick the correct door, his selected door and the correct door will be returned.
            int remainingDoor = eraseDoors(selectedDoor, doors);

            RemoveDoorsText(selectedDoor + 1, remainingDoor + 1);
            //---------------------------------------

            //Part Five. Let the user decide if he wants to switch doors.
            selectedDoor = switchDoors(selectedDoor, remainingDoor);
            //---------------------------------------

            //Part six. Check the door the user selected in the end and wrap up the game.
            FinishGame(selectedDoor, doors);
            //---------------------------------------

            //Part seven. Give the option to play again.
            playAgain();
            //---------------------------------------

        }

        public int getNumberBetween(int min = 0, int max = 100)
        {

            int numberInput = getNumberInput();

            if (numberInput >= min && numberInput <= max)
            {
                return numberInput;
            }
            else
            {
                commandlineRAW.writeToCommandline("That number is too high or low." + commandlineRAW.getEnter() +
                                                  "The number has to be between " + min + " and " + max + commandlineRAW.getEnter(), "Medium");
                return getNumberBetween(min, max);
            }
        }

        public int getNumberInput()
        {
            string input = commandlineRAW.readCommandline(true);

            int parsedInput = 0;

            if (Int32.TryParse(input, out parsedInput))
            {
                return parsedInput;
            }
            else
            {
                commandlineRAW.writeToCommandline("---Incorrect Input---" + commandlineRAW.getEnter(), "Medium");
                return getNumberInput();
            }
        }

        public bool[] createDoors(int amountOfDoors)
        {
            //At default the whole array is false.
            bool[] doors = new bool[amountOfDoors];

            Random random = new Random();

            //Creates an int between 0 and N-1. Perfect for an array.
            int prizeDoor = random.Next(0, amountOfDoors);

            //Inserts winning door into the array.
            doors[prizeDoor] = true;

            return doors;
        }

        public int eraseDoors(int selectedDoor, bool[] doors)
        {
            //Selected door has the prize
            if (doors[selectedDoor])
            {
                Random random = new Random();
                int randomEmptyDoor = random.Next(0, doors.Length);

                //Makes sure that the random door that doesn't have the prize isn't the same as the selected door.
                while (randomEmptyDoor == selectedDoor)
                {
                    randomEmptyDoor = random.Next(0, doors.Length);
                }

                return randomEmptyDoor;
            }
            //"Erase" all doors except for the one with prize and selected door.
            else
            {
                int doorWithPrize = 0;

                for (int i = 0; i < doors.Length; i++)
                {
                    if (doors[i])
                    {
                        doorWithPrize = i;
                    }
                }

                return doorWithPrize;
            }
        }

        public int switchDoors(int selectedDoor, int remainingDoor)
        {
            QuickMenu switchDoors = new QuickMenu("Do you want to switch doors?");
            switchDoors.showMenuOptions();

            if (switchDoors.yesOrNo())
            {
                return remainingDoor;
            }

            return selectedDoor;
        }

        public void FinishGame(int selectedDoor, bool[] doors)
        {
            //if door has the prize.
            if (doors[selectedDoor])
            {
                commandlineRAW.writeToCommandline("Congratulations, you found the " + goalObject + commandlineRAW.getPause() + commandlineRAW.getEnter(2), "Medium");
            }
            else
            {
                commandlineRAW.writeToCommandline("Unfortunately you didn't manage to find the " + goalObject + commandlineRAW.getPause() + commandlineRAW.getEnter(2), "Medium");
            }
        }

        public void playAgain()
        {
            QuickMenu playAgain = new QuickMenu("Want to play again?");
            playAgain.showMenuOptions();
            if (playAgain.yesOrNo())
            {
                //"Restarts" the game.
                play();
            }
        }
    }
}