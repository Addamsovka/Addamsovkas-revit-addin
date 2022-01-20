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

        /// <summary>
        /// Create string list of IFC Export Configurations names in project
        /// </summary>
        /// <returns>String list of values</returns>
        public List<string> GetIfcOptions()
        {
            // Prepare new map to work with
            IFCExportConfigurationsMap iFCExportOptions = new IFCExportConfigurationsMap();

            // Get all avaiable configurations in Project
            iFCExportOptions.Add(IFCExportConfiguration.GetInSession());
            iFCExportOptions.AddBuiltInConfigurations();
            iFCExportOptions.AddSavedConfigurations();

            // Create list of values
            var val = iFCExportOptions.Values;
            List<string> stringList = new List<string>();
            foreach (var o in val)
            {
                stringList.Add(o.Name);
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

        /// <summary>
        /// Return preset IFCExportConfiguration object for exporting.
        /// </summary>
        /// <param name="config"><see cref="CurrentIFCExportConfiguration"/> object with preset options</param>
        /// <returns></returns>
        public static BIM.IFC.Export.UI.IFCExportConfiguration CreateIfcExportConfiguration(CurrentIFCExportConfiguration config) {

            // Create Instance of IFC Configuration class
            BIM.IFC.Export.UI.IFCExportConfiguration iFCExportConfiguration = BIM.IFC.Export.UI.IFCExportConfiguration.CreateDefaultConfiguration();

            // Set by user from config
            iFCExportConfiguration.ExportBaseQuantities = config.ExportBaseQuantities;
            iFCExportConfiguration.SplitWallsAndColumns = config.SplitWallsAndColumns;
            iFCExportConfiguration.ExportInternalRevitPropertySets = config.ExportInternalRevitPropertySets;
            iFCExportConfiguration.ExportIFCCommonPropertySets = config.ExportIFCCommonPropertySets;
            iFCExportConfiguration.Export2DElements = config.Export2DElements;

            iFCExportConfiguration.VisibleElementsOfCurrentView = config.VisibleElementsOfCurrentView;

            iFCExportConfiguration.Use2DRoomBoundaryForVolume = config.Use2DRoomBoundaryForVolume;
            iFCExportConfiguration.UseFamilyAndTypeNameForReference = config.UseFamilyAndTypeNameForReference;
            iFCExportConfiguration.ExportPartsAsBuildingElements = config.ExportPartsAsBuildingElements;
            iFCExportConfiguration.ExportSolidModelRep = config.ExportSolidModelRep;

            iFCExportConfiguration.ExportSchedulesAsPsets = config.ExportSchedulesAsPsets;
            iFCExportConfiguration.ExportUserDefinedPsets = config.ExportUserDefinedPsets;
            iFCExportConfiguration.ExportUserDefinedPsetsFileName = config.ExportUserDefinedPsetsFileName;
            iFCExportConfiguration.ExportUserDefinedParameterMapping = config.ExportUserDefinedParameterMapping;
            iFCExportConfiguration.ExportUserDefinedParameterMappingFileName = config.ExportUserDefinedParameterMappingFileName;

            iFCExportConfiguration.ExportBoundingBox = config.ExportBoundingBox;
            iFCExportConfiguration.IncludeSiteElevation = config.IncludeSiteElevation;
            iFCExportConfiguration.IncludeSteelElements = config.IncludeSteelElements;
            iFCExportConfiguration.UseActiveViewGeometry = config.UseActiveViewGeometry;
            iFCExportConfiguration.ExportSpecificSchedules = config.ExportSpecificSchedules;

            iFCExportConfiguration.TessellationLevelOfDetail = config.TessellationLevelOfDetail;
            iFCExportConfiguration.UseOnlyTriangulation = config.UseOnlyTriangulation;
            iFCExportConfiguration.StoreIFCGUID = config.StoreIFCGUID;
            iFCExportConfiguration.ExportRoomsInView = config.ExportRoomsInView;
            iFCExportConfiguration.ExportLinkedFiles = config.ExportLinkedFiles;
            iFCExportConfiguration.ActiveViewId = config.ActiveViewId;
            iFCExportConfiguration.ExcludeFilter = config.ExcludeFilter;

            iFCExportConfiguration.COBieCompanyInfo = config.COBieProjectInfo;
            iFCExportConfiguration.COBieProjectInfo = config.COBieProjectInfo;
            iFCExportConfiguration.IncludeSteelElements = config.IncludeSteelElements;        

            return iFCExportConfiguration;
        }

        public static void ExportIfcModel(Document doc, string dir, string newName, IFCExportConfiguration _iFCExportConfiguration) 
        {
            // Create Instance of IFC Configuration class
            BIM.IFC.Export.UI.IFCExportConfiguration iFCExportConfiguration = _iFCExportConfiguration;

            // TODO choose views and set export by view
            ElementId ExportViewId = null;

            IFCExportOptions iFCExportOptions = new IFCExportOptions();
            iFCExportConfiguration.UpdateOptions(iFCExportOptions, ExportViewId);

            // Directory for the export
            string directory = $@"{dir}";


            /// TODO Get paramters from view and compose a name
            string s = "project_2_<ProjectInfo>_<sharedParam>_two";


            //Utility.Get3DViews(doc);
            //RevitModel.GetViewSets();
            //string newName = NameRules.prepareName(s); // TODO fix Name rules, search for real parameters
            //string newName = s;

            doc.Export(directory, newName, iFCExportOptions);
            TaskDialog.Show("IFC Settings", directory.ToString() + newName + " has been exported.");

        }


        public static void ExportIfcModel(Document doc, string dir, string newName)
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
            //string directory = @"C:\Users\regin\Desktop\";
            string directory = $@"{dir}";

            doc.Export(directory, newName, iFCExportOptions);
            TaskDialog.Show("IFC Settings", directory.ToString() + newName + " has been exported.");

        }


        #endregion
    }
}
