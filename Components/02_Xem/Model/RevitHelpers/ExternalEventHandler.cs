#region Namespaces
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
#endregion

namespace Xem
{
    /// <summary>
    /// Class to allow access to Revit API and Project via EventHandler
    /// </summary>
    class ExternalEventHandler : IExternalEventHandler
    {
        //#region Revit Event Handler
        //public static IExternalEventHandler testingEventHandler = new ExternalEventHandler();
        //ExternalEvent exEvent = ExternalEvent.Create(testingEventHandler);
        //#endregion

        // 

        public void Execute(UIApplication uiapp)
        {
            // Check if there is existing Revit Project
            UIDocument uidoc = uiapp.ActiveUIDocument;
            if (null == uidoc)
            {
                return; // no document, nothing to do
            }
            
            Autodesk.Revit.DB.Document doc = uidoc.Document;

            // Apply command in transaction
            using (Transaction tx = new Transaction(doc))
            {
                tx.Start("MyEvent Xem");
                // Action within valid Revit API context thread
                tx.Commit();
            }
        }

        public string GetName()
        {
            return "my event";
        }
    }
}
