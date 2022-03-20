#region Namespaces
using System;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
#endregion

namespace Xem
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    class XemCommand : IExternalCommand
    {
        /// <summary>
        /// The main method executing command Xem and open UI for the command
        /// </summary>
        /// <param name="commandData"></param>
        /// <param name="message"></param>
        /// <param name="elementSet"></param>
        /// <returns></returns>
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elementSet)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;

            try
            {
                #region Revit Event Handler Instance
                ExportExternalEventHandler testingEventHandler = new ExportExternalEventHandler();
                ExternalEvent exEvent = ExternalEvent.Create(testingEventHandler);
                #endregion

                // Pass an EventHandler to the WindowViewModel
                var window = new MainWindow(commandData, testingEventHandler, exEvent);

                window.Show();

                return Result.Succeeded;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return Result.Failed;
            }
        }
    }
}

