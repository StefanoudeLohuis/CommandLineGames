using CommandlineRAWNS;

namespace StartupNS
{
    class Startup
    {

        private CommandlineRAW commandlineRAW = new CommandlineRAW();

        private string startupMessage;

        public Startup()
        {
            startupMessage =    "" + commandlineRAW.getEnter() + commandlineRAW.getEnter() + commandlineRAW.getEnter() +
                                commandlineRAW.getPause() + "Welcome!" + commandlineRAW.getPause() + commandlineRAW.getEnter() +
                                "In this little program you can play a few games." + commandlineRAW.getPause() + commandlineRAW.getEnter() +
                                "Enjoy!" + commandlineRAW.getEnter() + commandlineRAW.getEnter() + commandlineRAW.getEnter() + commandlineRAW.getPause();
        }

        public void doFakeStartup()
        {
            commandlineRAW.writeToCommandline(startupMessage, "Medium");
        }
    }
}