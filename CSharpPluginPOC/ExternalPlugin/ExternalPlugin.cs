using MainApp.Interfaces;

namespace ExternalPlugin
{
    public class ExternalPlugin : PluginInterface
    {
        private UtilInterface _utilities;

        public ExternalPlugin(UtilInterface utilities)
        {
            _utilities = utilities;
        }

        public void CallableMethod(string inputString)
        {
            Console.WriteLine("Hello from ExternalPlugin");
            _utilities.LogMessage(inputString);
        }
    }
}
