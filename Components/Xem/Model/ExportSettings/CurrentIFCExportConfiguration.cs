namespace Xem
{
    /// <summary>
    /// IFC configuration options setters, defaul "IFC 2x3 Coordination View 2.0"
    /// </summary>
    public class CurrentIFCExportConfiguration
    {
        public bool ExportBaseQuantities { get; set; } = false;
        public bool SplitWallsAndColumns { get; set; } = false;
        public bool ExportInternalRevitPropertySets { get; set; } = false;
        public bool ExportIFCCommonPropertySets { get; set; } = true;
        public bool Export2DElements { get; set; } = false;
        public bool VisibleElementsOfCurrentView { get; set; } = false;
        public bool Use2DRoomBoundaryForVolume { get; set; } = false;
        public bool UseFamilyAndTypeNameForReference { get; set; } = false;
        public bool ExportPartsAsBuildingElements { get; set; } = false;
        public bool ExportSolidModelRep { get; set; } = false;
        public bool ExportSchedulesAsPsets { get; set; } = false;
        public bool ExportUserDefinedPsets { get; set; } = false;
        public string ExportUserDefinedPsetsFileName { get; set; } = "";
        public bool ExportUserDefinedParameterMapping { get; set; } = false;
        public string ExportUserDefinedParameterMappingFileName { get; set; } = "";
        public bool ExportBoundingBox { get; set; } = false;
        public bool IncludeSiteElevation { get; set; } = false;
        public bool UseActiveViewGeometry { get; set; } = false;
        public bool ExportSpecificSchedules { get; set; } = false;
        public double TessellationLevelOfDetail { get; set; } = 0.5;
        public bool UseOnlyTriangulation { get; set; } = false;
        public bool StoreIFCGUID { get; set; } = false;
        public bool ExportRoomsInView { get; set; } = false;
        public bool ExportLinkedFiles { get; set; } = false;
        public int ActiveViewId { get; set; } = 0;
        public string ExcludeFilter { get; set; } = "";
        public string COBieCompanyInfo { get; set; } = "";
        public string COBieProjectInfo { get; set; } = "";
        public bool IncludeSteelElements { get; set; } = true;
        public bool IsBuiltIn { get; set; } = false;
        public bool IsInSession { get; set; } = false;
        public string FileVersionDescription { get; set; } = "IFC 2x3 Coordination View 2.0";
    }
}
