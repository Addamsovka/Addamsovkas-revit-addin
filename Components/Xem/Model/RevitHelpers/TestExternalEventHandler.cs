#region Namespaces
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Diagnostics;
#endregion

namespace Xem
{
    /// <summary>
    /// Class to allow access to Revit API and Project via EventHandler
    /// </summary>
    public class TestExternalEventHandler : IExternalEventHandler
    {
        public string Name { get; set; }
 
        public void Execute(UIApplication uiapp)
        {
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;

            // Apply command in transaction
            using (Transaction tx = new Transaction(doc))
            {
                tx.Start("Another external command run");

                RevitModel.ExportIfcModel(doc, Name);

                tx.Commit();
            }
        }

        public string GetName()
        {
            return "my event";
        }
    }
}
