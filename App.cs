using Autodesk.Revit.UI;
using System;
using System.Reflection;
using System.Windows.Media.Imaging;
using Xem;

namespace AddamsovkaRevitPlugin
{
    /// <summary>
    /// Namespace IExternalApplication to register as Revit addin application
    /// </summary>
    public class App : IExternalApplication
    {

        /// <summary>
        /// On Revit Apllication Startup, ribon and menu icons will be created.
        /// </summary>
        /// <param name="application"></param>
        /// <returns></returns>
        public Result OnStartup(UIControlledApplication application) 
        {
            // Create tab
            string tabName = "Addamsovka Tab";
            application.CreateRibbonTab(tabName);

            // Create ribbon
            RibbonPanel ribPanel = application.CreateRibbonPanel(tabName, "New Ribbon Panel"); //TODO rename panel

            // Define paths
            string curLib = Assembly.GetExecutingAssembly().Location;
            string curLibPath = System.IO.Path.GetDirectoryName(curLib);

            // Define Buttons
            PushButtonData pbd1 = new PushButtonData("PBD1", "Hello" + "\r" + "World", curLib, "HelloWorld.HelloWorldCommand"); // TODO: add proper commands
            PushButtonData pbd2 = new PushButtonData("PBD2", "Xem" + "\r" + "Command", curLib, "Xem.XemCommand");
            PushButtonData pbd3 = new PushButtonData("PBD3", "IFC Direct Exporter", curLib, "UpperText.UpperTextCommand"); // TODO: add proper commands

            pbd1.LargeImage = new BitmapImage(new Uri(@"C:\Users\regin\source\repos\AddamsovkaRevitPlugin\Resources\helloWorld.png")); //TODO change images
            pbd2.LargeImage = new BitmapImage(new Uri(@"C:\Users\regin\source\repos\AddamsovkaRevitPlugin\Resources\Test2.png"));
            pbd3.LargeImage = new BitmapImage(new Uri(@"C:\Users\regin\source\repos\AddamsovkaRevitPlugin\Resources\Test.png"));
            // "pack://application:,,,/First Plugin;component/Resources/helloWorld.png"


            // Create buttons and add to Ribbon
            PushButton pb1 = (PushButton)ribPanel.AddItem(pbd1);
            PushButton pb2 = (PushButton)ribPanel.AddItem(pbd2);
            PushButton pb3 = (PushButton)ribPanel.AddItem(pbd3);

            return Result.Succeeded;

        }

        /// <summary>
        /// This happen when Revit shut down. This must be implemented.
        /// </summary>
        /// <param name="application"></param>
        /// <returns></returns>
        public Result OnShutdown(UIControlledApplication application)
        {   
            // Here unregister related events
            return Result.Succeeded;
        }
    }
}

