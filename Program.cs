using System;
using Menus;
using CommandlineRAWNS;
using StartupNS;

namespace Commandline_Game
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Startup startup = new Startup();
            // startup.doFakeStartup();

            // StartMenu startMenu = new StartMenu();
            // startMenu.showMenuOptions();
            // //All takeover() methods will pretty much take over everything that happends in the application.
            // startMenu.takeOver();

            GameMenu gameMenu = new GameMenu();
            gameMenu.showMenuOptions();
            gameMenu.takeOver();
        }
    }
}