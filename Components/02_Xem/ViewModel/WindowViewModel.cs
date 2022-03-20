#region Namespaces
using Autodesk.Revit.UI;
using System.ComponentModel;
#endregion

namespace Xem
{
    /// <summary>
    /// Viewmodel uset for the whole window
    /// </summary>
    public class WindowViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        #region Revit Events
        public static ExternalCommandData CommandData { get; set; }
        public static ExportExternalEventHandler EvHandler { get; set; }
        public static ExternalEvent ExEvent { get; set; }
        #endregion


        #region Window Properties
        public static double MinimalWindowHeight { get; set; } = 450;
        public static double MinimalWindowWidth { get; set; } = 800;
        #endregion


        #region Pages
        /// <summary>
        /// Set default page to the main window
        /// </summary>
        public PageEnum CurrentPage { get; set; } = PageEnum.ExportSettingsListPage;

        #endregion

    }
}
