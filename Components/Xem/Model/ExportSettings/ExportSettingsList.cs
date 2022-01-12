#region Namespaces
using System.Collections.ObjectModel;
using System.Diagnostics;
#endregion

namespace Xem
{
    public class ExportSettingsList
    {
        #region Properties
        private ObservableCollection<ExportSettings> exportSettingList;

        /// <summary>
        /// Represents the whole collection of <see cref="ExportSettings"/> objects in the <see cref="ExportSettingList"/>. Read-only.
        /// </summary>
        public ObservableCollection<ExportSettings> List
        {
            get { return exportSettingList; }
        }

        #endregion

        #region Constructor
        public ExportSettingsList()
        {
            this.exportSettingList = new ObservableCollection<ExportSettings>();
        }
        #endregion

        #region Methods

        /// <summary>
        /// Get <see cref="ExportSettings"/> object at index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns>ExportSettings object or null.</returns>
        public ExportSettings GetItemAtIndex(int index)
        {
            try
            {
                return this.exportSettingList[index];
            }
            catch
            {
                Debug.WriteLine("There is not value at that index."); //TODO: Test and delete debug, catch the error later.
                return null;
            }
        }

        /// <summary>
        /// Add <see cref="ExportSettings"/> object at the end of the collection.
        /// </summary>
        /// <param name="item"></param>
        public void Add(ExportSettings item)
        {
            this.exportSettingList.Add(item);
        }

        /// <summary>
        /// Removes the first occurence of the <see cref="ExportSettings"/> object in the list.
        /// </summary>
        /// <param name="item"></param>
        public void Remove(ExportSettings item)
        {
            this.exportSettingList.Remove(item);
        }
        #endregion
    }
}









