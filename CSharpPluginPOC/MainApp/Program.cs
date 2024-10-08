using MainApp.Interfaces;

namespace MainApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello from Main");

            UtilInterface utilities = new Util();
            PluginInterface internalPlugin = new InternalPlugin(utilities);
            internalPlugin.CallableMethod("Test String");
        }
    }

    public class Util : UtilInterface
    {
        public void LogMessage(string message)
        {
            Console.WriteLine("Hello from Util");
            Console.WriteLine(message);
        }
    }

    internal class InternalPlugin : PluginInterface
    {
        private UtilInterface _utilities;

        public InternalPlugin(UtilInterface utilities)
        {
            _utilities = utilities;
        }

        public void CallableMethod(string inputString)
        {
            Console.WriteLine("Hello from InternalPlugin");
            _utilities.LogMessage(inputString);
        }
    }
}
