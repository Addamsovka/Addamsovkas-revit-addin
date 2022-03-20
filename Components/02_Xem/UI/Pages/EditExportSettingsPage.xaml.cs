#region Namespaces
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Diagnostics;
using System.Windows;
#endregion

namespace Xem
{
    /// <summary>
    /// Interaction logic for EditExportSettingsPage.xaml,  not designed yet - it is for testing now
    /// </summary>
    public partial class EditExportSettingsPage : BasePage<EditExportSettingsPageViewModel>
    {
        private int Loc { get; set; }

        public RevitModel revit = new RevitModel();
        public ExportSettings exportSettings = new ExportSettings();

        public EditExportSettingsPage()
        {
            InitializeComponent();

            // 3Dview avaiable parameters
            lbOne.ItemsSource = revit.Get3DViewParameters();

            // get all sheet sets avaiable in project
            // TODO: validation about content (sheets vs views -> ifc should only export 3d views)
            SetList.ItemsSource = revit.GetViewSheetSets();

            // Get all avaiable saved IFC option in project
            ExportingProfileList.ItemsSource = revit.GetIfcOptions(); // TODO: list is not showing
        }

        private void ApplyButton_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Apply button");
            var list = this.revit.Get3DViewParameters();
            foreach (string a in list)
            {
                Debug.WriteLine(a);
                Debug.WriteLine(Utility.namePrepare(a));
            }

        }

        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Save setting to list


            // TODO: Change to main page
            await AnimateOut();
            await AnimateIn();
        }

        /// <summary>
        /// Animate the page out of the main window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            await AnimateOut();
            //TODO: change page
            await AnimateIn();
        }

        

        private void RefreshButton_Click(object sender, RoutedEventArgs e) // Make avaiable only if passes validation
        {
            Debug.WriteLine("Refresh button");
            // Get new name
            string newName = RulesPrescriptionTextBox.Text;

            // Set name in handler
            WindowViewModel.EvHandler.Name = newName;

            // Trigger event in Revit
            WindowViewModel.ExEvent.Raise();
        }

        /// <summary>
        /// Paste the selected parameter to the NamingRule field.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddParameterButton_Click(object sender, RoutedEventArgs e)
        {
            Loc = RulesPrescriptionTextBox.SelectionStart;

            // Add the parameter to the cursor location in textfield
            try
            {
                string name = (lbOne.SelectedItem).ToString();
                string editedName = Utility.namePrepare(name);
                this.viewModel.RulesPrescriptionTextBox = this.viewModel.RulesPrescriptionTextBox.Insert(Loc, editedName);

                // New location after new text
                Loc = Loc + editedName.Length;
            }
            catch
            {
                MessageBox.Show("There is no selected Parameter. Please make sure you have selected a valid parameter from the list.", "Parameter error");
            }

            // Add focus back to the textfiled in proper location
            RulesPrescriptionTextBox.Focus();
            RulesPrescriptionTextBox.SelectionStart = Loc;
        }


        private void ListBox_PreviewMouseLeftButtonDown(object sender, RoutedEventArgs e)
        {

        }

        #region Form Input Events
        private void ExportingProfileList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var selectedValue = ExportingProfileList.SelectedValue;
            exportSettings.SavedExportingProfile = selectedValue.ToString();
        }

        private void SetList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var selectedValue = SetList.SelectedValue;
            exportSettings.SavedSet = selectedValue.ToString();
        }

        private void RulesPrescriptionTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            var selectedValue = RulesPrescriptionTextBox.Text;
            exportSettings.NamingRule = selectedValue;
        }
        #endregion

        
    }
}
