#region Namespaces
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
#endregion

namespace Xem
{
    /// <summary>
    /// All classed interaction with the model view-model
    /// </summary>
    public class ExportSettingsListPageViewModel : BaseViewModel
    {

        #region Name Rules 
        /// <summary>
        /// TextBox field for entering and showing user rules for naming of exported files.
        /// </summary>
        public string RulesPrescriptionTextBox { get; set; } = "";

        /// <summary>
        /// List of avaiable parameters for the view.
        /// </summary>
        public ObservableCollection<string> ParamInCollection { get; set; }
        #endregion

        #region ExportSettings property
        /// <summary>
        /// Storing private export settings
        /// </summary>
        public ExportSettings ExportSettings { get; set; }

        #endregion

        #region Exporting Options and Settings

        /// <summary>
        /// Exporting options - defines type of export / default IFC Export
        /// </summary>
        public ExportingOptionEnum ExportingOption { get; set; } = ExportingOptionEnum.IfcExport;

        /// <summary>
        /// List of avaiable sets in project
        /// </summary>
        public ObservableCollection<string> SetList { get; set; }

        /// <summary>
        /// List of avaiable exporting settings for selected option in the project
        /// </summary>
        public ObservableCollection<string> ExportingProfileList { get; set; }
        #endregion

        #region Commands

        /// <summary>
        /// The command to save settings
        /// </summary>
        public ICommand SavingCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public ExportSettingsListPageViewModel()
        {
            // Create public save command
            SavingCommand = new RelaySaveCommand(async (parameter) => await Save(parameter));

            // TODO: Create export settings if not existing
        }
        #endregion

        /// <summary>
        /// Attemps to Save the settings
        /// </summary>
        /// <param name="parameter"><see cref="ExportingOption"/> passed from the view model instance</param>
        /// <returns></returns>
        public async Task Save(object parameter)
        {
            Debug.WriteLine("Save commands");
            await Task.Delay(500);
            Debug.WriteLine(parameter.ToString());
        }
    }
}