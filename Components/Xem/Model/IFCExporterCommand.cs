#region Namespaces
using System;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
#endregion

namespace Xem
{
    [Transaction(TransactionMode.Manual)]
    public class IFCExporterCommand : IExternalCommand
    {

        #region ExportSetting Loader

        public string newName = "testing new name for export";

        #endregion

        // Set exporting setting profile
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elementSet)
        {

            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;

            // Create Instance of IFC Configuration class
            BIM.IFC.Export.UI.IFCExportConfiguration iFCExportConfiguration = BIM.IFC.Export.UI.IFCExportConfiguration.CreateDefaultConfiguration();

            // TODO Options - set by user
            iFCExportConfiguration.ExportLinkedFiles = false;

            // TODO choose views and set export by view
            ElementId ExportViewId = null;
            iFCExportConfiguration.VisibleElementsOfCurrentView = false;


            IFCExportOptions iFCExportOptions = new IFCExportOptions();
            iFCExportConfiguration.UpdateOptions(iFCExportOptions, ExportViewId);

            // Directory for the export
            string Directory = @"C:\Users\regin\Desktop\";


            /// TODO Get paramters from view and compose a name
            string s = "project_2_<ProjectInfo>_<sharedParam>_two";


            //Utility.Get3DViews(doc);
            //RevitModel.GetViewSets();
            //string newName = NameRules.prepareName(s); // TODO fix Name rules, search for real parameters
            //string newName = s;

            // TODO Save

            // Exporting transaction
            using (Transaction tx = new Transaction(doc))
            {
                tx.Start("Export task");

                doc.Export(Directory, this.newName, iFCExportOptions);

                tx.Commit();

                TaskDialog.Show("IFC Settings", Directory.ToString() + this.newName + " has been exported.");
            }

            return Result.Succeeded;
        }

    }
}
