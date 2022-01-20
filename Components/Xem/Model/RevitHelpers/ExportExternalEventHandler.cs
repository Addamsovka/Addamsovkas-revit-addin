#region Namespaces
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using BIM.IFC.Export.UI;
using System.Diagnostics;
#endregion

namespace Xem
{
    /// <summary>
    /// Class to allow access to Revit API and Project via EventHandler
    /// </summary>
    public class ExportExternalEventHandler : IExternalEventHandler
    {
        public string Name { get; set; }
 
        public void Execute(UIApplication uiapp)
        {
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;

            // Apply command in transaction
            using (Transaction tx = new Transaction(doc))
            {
                tx.Start("Export external command");

                // Set the chosen configuration of export
                CurrentIFCExportConfiguration config = new CurrentIFCExportConfiguration();
                var configuration = RevitModel.CreateIfcExportConfiguration(config);

                // Export model with current settings
                RevitModel.ExportIfcModel(doc, @"C:\Users\regin\Desktop\", Name, configuration);

                tx.Commit();
            }
        }

        public string GetName()
        {
            return "Export Event";
        }
    }
}
