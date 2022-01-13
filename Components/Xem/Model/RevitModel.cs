#region Namespaces
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using BIM.IFC.Export.UI;
#endregion

namespace Xem
{
    /// <summary>
    /// Class representing Revit instance
    /// </summary>
    public class RevitModel
    {
        #region Class properties
        public UIApplication uiapp;
        public UIDocument uidoc;
        public Document doc;
        #endregion

        #region Constructor
        public RevitModel() 
        {
            this.uiapp = WindowViewModel.CommandData.Application;
            this.uidoc = this.uiapp.ActiveUIDocument;
            this.doc = this.uidoc.Document;
        }
        #endregion

        #region Working with Views

        /// <summary>
        /// Get all 3D view parameters
        /// </summary>
        /// <returns><see cref="List{string}"/></returns>
        public List<string> Get3DViewParameters()
        {
            // Get first 3d element
            Element e = new FilteredElementCollector(this.doc).OfClass(typeof(View3D)).WhereElementIsNotElementType().FirstElement();
            // Get all parameters from element
            var elementParameters = e.GetOrderedParameters();

            // Get name of each parameter
            List<string> stringList = new List<string>();
            foreach (Parameter p in elementParameters)
            {
                stringList.Add(p.Definition.Name);
            }

            return stringList;
        }

        public List<string> GetViewSheetSets()
        {
            IList<Element> viewSheetSets = new FilteredElementCollector(this.doc).OfClass(typeof(ViewSheetSet)).ToElements();
            List<string> stringList = new List<string>();
            foreach (Element e in viewSheetSets)
            {
                stringList.Add(e.Name);
            }
            return stringList;
        }

        public List<string> GetIfcOptions()
        {
            IFCExportConfigurationsMap iFCExportOptions = new IFCExportConfigurationsMap();

            var aha = iFCExportOptions.Values;
            List<string> stringList = new List<string>();
            foreach (var a in aha)
            {
                stringList.Add(a.Name);
            }

            return stringList;
        }


        public List<string> GetAll3DViews()
        {
            IEnumerable<View> collected3Ds = new FilteredElementCollector(this.doc).OfClass(typeof(View3D)).WhereElementIsNotElementType().Cast<View>();

            List<string> stringViews = new List<string>();

            foreach (var i in collected3Ds)
            {
                Debug.Print(i.Name);
                stringViews.Append(i.Name);
            }
            return stringViews;
        }

        // find all viewsheet set within document

        public void GetViewSets()
        {

            FilteredElementCollector coll = new FilteredElementCollector(this.doc);
            var all = coll.OfClass(typeof(ViewSheetSet)).ToElements();

            Console.WriteLine("Viewsheet set count: " + all.Count);

            foreach (ViewSheetSet vss in all)
            {
                Debug.Print("Name: " + vss.Name);
            }
        }

        #endregion


        #region Export

        public static void ExportIfcModel(Document doc, string newName) 
        {
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

            doc.Export(Directory, newName, iFCExportOptions);
            TaskDialog.Show("IFC Settings", Directory.ToString() + newName + " has been exported.");

        }
        #endregion
    }
}
