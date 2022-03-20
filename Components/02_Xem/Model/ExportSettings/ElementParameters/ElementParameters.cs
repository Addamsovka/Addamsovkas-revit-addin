#region Namespaces
using System.Collections.ObjectModel;
#endregion

namespace Xem
{
    public class ElementParameters
    {
        /// <summary>
        /// Retrieves <see cref="ObservableCollection{Parameter}"/> of <see cref="Parameter"/> corresponding to the Revit view element
        /// </summary>
        /// <returns></returns>
        public static ObservableCollection<string> GetCollection()
        {
            // TODO: Retrieve a list of parameters from Revit element
            string[] revitList = { "Name", "Project Name", "Width", "CUSTOM_PARAM" };

            // Create observable collection for UI and Validation
            ObservableCollection<string> paramCollection = new ObservableCollection<string>();

            foreach (string paramName in revitList)
            {
                paramCollection.Add(paramName);
            }
            return paramCollection;
        }
    }
}
