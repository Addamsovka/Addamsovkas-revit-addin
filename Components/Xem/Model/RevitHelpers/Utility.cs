#region Namespaces
using System;
using System.Linq;
using Autodesk.Revit.DB;
using System.Collections.Generic;
using System.Diagnostics;
#endregion

namespace Xem
{
    class Utility
    {
        #region Text Editor

        /// <summary>
        /// Prepares string for Naming rules to the <parameterName> format.
        /// </summary>
        /// <returns>string "<paramtername>"</returns>
        public static string namePrepare(string name)
        {
            return $@"<{name}>";
        }

        #endregion
    }
}
