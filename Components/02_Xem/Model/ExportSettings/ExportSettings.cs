namespace Xem
{
    public class ExportSettings
    {
        #region Constructor
        /// <summary>
        /// Constructor - create instance and sets all settings to and ExportSettings object
        /// </summary>
        /// <param name="name"></param>
        /// <param name="namingRule"></param>
        /// <param name="set"></param>
        /// <param name="exportingProfile"></param>
        public ExportSettings(string name, string namingRule, string set, string exportingProfile)
        {
            this.Name = name;
            this.NamingRule = namingRule;
            this.SavedSet = set;
            this.SavedExportingProfile = exportingProfile;
        }

        /// <summary>
        /// Creates object of the <see cref="ExportSettings"/> with empty strings
        /// </summary>
        public ExportSettings()
        {
            this.Name = "";
            this.NamingRule = "";
            this.SavedSet = "";
            this.SavedExportingProfile = "";
        }
        #endregion

        /// <summary>
        /// Save <see cref="ExportSettings"/> into a existing <see cref="ExportSettingsList"/>
        /// </summary>
        /// <param name="esets"></param>
        public void Save(ExportSettingsList esets)
        {
            esets.Add(this);
        }

        #region Properties
        /// <summary>
        /// Name of the set shown in ExportSettingsList page
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Naming rule applied when exporting each view of the set
        /// </summary>
        public string NamingRule { get; set; }

        /// <summary>
        /// String reference name to the Revit Set
        /// </summary>
        public string SavedSet { get; set; }

        /// <summary>
        /// String reference to the Revit exporting options
        /// </summary>
        public string SavedExportingProfile { get; set; }
        #endregion
    }
}