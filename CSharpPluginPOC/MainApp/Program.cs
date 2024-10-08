using MainApp.Interfaces;
using System.Reflection;

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

            Assembly externalDLL = Assembly.LoadFrom("ExternalPlugin.dll");
            foreach (Type type in externalDLL.GetExportedTypes())
            {
                if (type.GetInterface(typeof(PluginInterface).FullName) != null)
                {
                    Console.WriteLine("Found external plugin class");
                    PluginInterface externalPlugin = Activator.CreateInstance(type, new object[] { utilities }) as PluginInterface;
                    if (externalPlugin != null)
                    {
                        Console.WriteLine("Class constructed");
                        externalPlugin.CallableMethod("Another Test String");
                    }
                }
            }
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
