using CommandlineRAWNS;
using games;

namespace Menus
{
    class BaseMenu
    {
        private CommandlineRAW commandlineRAW = new CommandlineRAW();

        private string menuOptions;

        public BaseMenu(string baseMessage, string[] menuOptions)
        {
            this.menuOptions = baseMessage + commandlineRAW.getPause() + commandlineRAW.getEnter(2);

            for (int i = 0; i < menuOptions.Length; i++)
            {
                if (menuOptions[i].Equals("Quit"))
                {
                    //Extra enter.
                    this.menuOptions += commandlineRAW.getEnter();
                }

                this.menuOptions += "  " + i + ". " + menuOptions[i] + commandlineRAW.getEnter();
            }

            //Extra enter at the end of the message.
            this.menuOptions += commandlineRAW.getEnter();
        }

        public void showMenuOptions()
        {
            commandlineRAW.writeToCommandline(menuOptions, "Fast");
        }
    }

    class StartMenu : BaseMenu
    {
        private CommandlineRAW commandlineRAW = new CommandlineRAW();
        private static string[] startMenuOptions = { "Play", "Quit" };
        private static string baseMessage = "What would you like to do?";

        public StartMenu() : base(baseMessage, startMenuOptions) { }

        public void takeOver()
        {
            switch (commandlineRAW.readCommandline(true))
            {
                //Play
                case "0":
                case "Play":
                case "play":
                    GameMenu gameMenu = new GameMenu();
                    gameMenu.showMenuOptions();
                    gameMenu.takeOver();

                    //"Restarts" the Menu.
                    showMenuOptions();
                    takeOver();
                    break;
                //Quit
                case "1":
                case "Quit":
                case "quit":
                    break;
                default:
                    commandlineRAW.writeToCommandline("---Incorrect Input---" + commandlineRAW.getEnter(), "Medium");
                    //Starts the same funtion again. This will happen until the user inputs one of the cases above.
                    takeOver();
                    break;
            }
        }
    }

    class GameMenu : BaseMenu
    {
        private CommandlineRAW commandlineRAW = new CommandlineRAW();
        private static string[] gameMenuOptions = { "Three Door Game", "Quit" };
        private static string baseMessage = "Which game would you like to play?";

        public GameMenu() : base(baseMessage, gameMenuOptions) { }

        public void takeOver()
        {

            QuickMenu playThisGame = new QuickMenu("Do you want to play this game?");

            switch (commandlineRAW.readCommandline(true))
            {
                //Three Door Game
                case "0":
                case "Three Door Game":
                    ThreeDoorGame threeDoorGame = new ThreeDoorGame();
                    threeDoorGame.gameIntroduction();

                    playThisGame.showMenuOptions();

                    if (playThisGame.yesOrNo())
                    {
                        threeDoorGame.play();
                    }

                    //"Restarts" the Menu
                    showMenuOptions();
                    takeOver();
                    break;
                //Quit
                case "1":
                case "Quit":
                case "quit":
                    break;
                default:
                    commandlineRAW.writeToCommandline("---Incorrect Input---" + commandlineRAW.getEnter(), "Medium");
                    //Starts the same funtion again. This will happen until the user inputs one of the cases above.
                    takeOver();
                    break;
            }
        }
    }

    class QuickMenu : BaseMenu
    {

        private CommandlineRAW commandlineRAW = new CommandlineRAW();
        private static string[] gameMenuOptions = { "Yes", "No" };
        public QuickMenu(string baseMessage) : base(baseMessage, gameMenuOptions) { }

        public bool yesOrNo()
        {
            switch (commandlineRAW.readCommandline(true))
            {
                //Yes
                case "0":
                case "Yes":
                case "yes":
                    return true;
                //No
                case "1":
                case "No":
                case "no":
                    return false;
                default:
                    commandlineRAW.writeToCommandline("---Incorrect Input---" + commandlineRAW.getEnter(), "Medium");
                    //Starts the same funtion again. This will happen until the user inputs one of the cases above.
                    return yesOrNo();
            }
        }
    }
}