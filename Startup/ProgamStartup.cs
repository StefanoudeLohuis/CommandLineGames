using CommandlineRAWNS;

namespace StartupNS
{
    class Startup
    {

        private CommandlineRAW commandlineRAW = new CommandlineRAW();

        private string startupMessage;

        public Startup()
        {
            startupMessage =    "" + commandlineRAW.getEnter(3) + commandlineRAW.getPause(2) + 
                                "Welcome!" + commandlineRAW.getPause(2) + commandlineRAW.getEnter() +
                                "In this little program you can play a few games." + commandlineRAW.getPause(2) + commandlineRAW.getEnter() +
                                "Enjoy!" + commandlineRAW.getEnter(3) + commandlineRAW.getPause(2);
        }

        public void doFakeStartup()
        {
            commandlineRAW.writeToCommandline(startupMessage, "Medium");
        }
    }
}