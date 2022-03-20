#region Namespaces
using Autodesk.Revit.UI;
using System.ComponentModel;
#endregion

namespace Xem

{
    public class BaseViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

    }
}