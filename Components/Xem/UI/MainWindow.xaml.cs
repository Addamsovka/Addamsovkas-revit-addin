
#region Namespaces
using Autodesk.Revit.UI;
using System.Windows;
#endregion

namespace Xem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private WindowViewModel windowViewModel;

        #region Constructor
        public MainWindow(ExternalCommandData commandData, TestExternalEventHandler eventHandler, ExternalEvent revitEvent)
        {
            InitializeComponent();

            // Bind EdiExportSettingstPageViewModel to Main Window
            this.windowViewModel = new WindowViewModel();
            this.DataContext = this.windowViewModel;

            // Assign Revit Common Data and Events
            WindowViewModel.CommandData = commandData;
            WindowViewModel.ExEvent = revitEvent;
            WindowViewModel.EvHandler = eventHandler;

        }
        #endregion
    }
}
