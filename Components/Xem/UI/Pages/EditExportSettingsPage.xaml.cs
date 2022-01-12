#region Namespaces
using Autodesk.Revit.UI;
using System.Diagnostics;
using System.Windows;
#endregion

namespace Xem
{
    /// <summary>
    /// Interaction logic for EditExportSettingsPage.xaml
    /// </summary>
    public partial class EditExportSettingsPage : BasePage<EditExportSettingsPageViewModel>
    {
        private int Loc { get; set; }

        public RevitModel revit = new RevitModel();

        public EditExportSettingsPage()
        {
            InitializeComponent();

            // Temporary testing values for view TODO: delete after implementation of real data
            lbOne.ItemsSource = new string[] { "Name", "Project Name", "Width", "CUSTOM_PARAM" };
            SetList.ItemsSource = new string[] { "one", "two", "three", "four" };
            ExportingProfileList.ItemsSource = new string[] { "export1", "export2", "export3" };
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

        

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
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


    }
}
