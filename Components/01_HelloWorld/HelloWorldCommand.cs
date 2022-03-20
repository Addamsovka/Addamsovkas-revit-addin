#region Namespaces
using System.Collections.Generic;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
#endregion


namespace HelloWorld
{
    [Transaction(TransactionMode.Manual)]
    public class HelloWorldCommand : IExternalCommand
    {
        // The main method (inhereted from IExternalCommand)
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elementSet)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Autodesk.Revit.ApplicationServices.Application app = uiapp.Application;
            Document doc = uidoc.Document;

            //DisplayHelloForm("Hello World Title");
            TaskDialog.Show("Revit", "Hello World!");
            return Result.Succeeded;
        }

        private void DisplayHelloForm(
            string filename)
        {
            //System.Windows.Forms.Form form = new HelloForm();
            //form.Text = filename;
            //form.ShowDialog();
        }

        private List<string> GetViewSets(Document doc)
        {

            FilteredElementCollector coll = new FilteredElementCollector(doc);
            var all = coll.OfClass(typeof(ViewSheetSet)).ToElements();

            List<string> list = new List<string>();

            foreach (ViewSheetSet vss in all){
                list.Add(vss.Name);
            }
            return list;
        }
    }

    
}
