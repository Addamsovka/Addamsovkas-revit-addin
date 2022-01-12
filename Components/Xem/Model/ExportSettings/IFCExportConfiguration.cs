namespace Xem
{
    /// <summary>
    /// IFC configuration options setters
    /// </summary>
    public class IFCExportConfiguration
    {
        public bool ExportBaseQuantities { get; set; }
        public bool SplitWallsAndColumns { get; set; }
        public bool ExportInternalRevitPropertySets { get; set; }
        public bool ExportIFCCommonPropertySets { get; set; }
        public bool Export2DElements { get; set; }
        public bool VisibleElementsOfCurrentView { get; set; }
        public bool Use2DRoomBoundaryForVolume { get; set; }
        public bool UseFamilyAndTypeNameForReference { get; set; }
        public bool ExportPartsAsBuildingElements { get; set; }
        public bool ExportSolidModelRep { get; set; }
        public bool ExportSchedulesAsPsets { get; set; }
        public bool ExportUserDefinedPsets { get; set; }
        public string ExportUserDefinedPsetsFileName { get; set; }
        public bool ExportUserDefinedParameterMapping { get; set; }
        public string ExportUserDefinedParameterMappingFileName { get; set; }
        public bool ExportBoundingBox { get; set; }
        public bool IncludeSiteElevation { get; set; }
        public bool UseActiveViewGeometry { get; set; }
        public bool ExportSpecificSchedules { get; set; }
        public double TessellationLevelOfDetail { get; set; }
        public bool UseOnlyTriangulation { get; set; }
        public bool StoreIFCGUID { get; set; }
        public bool ExportRoomsInView { get; set; }
        public bool ExportLinkedFiles { get; set; }
        public int ActiveViewId { get; set; }
        public string ExcludeFilter { get; set; }
        public string COBieCompanyInfo { get; set; }
        public string COBieProjectInfo { get; set; }
        public bool IncludeSteelElements { get; set; }
        public bool IsBuiltIn { get; set; }
        public bool IsInSession { get; set; }
        public string FileVersionDescription { get; set; }

    }
}
