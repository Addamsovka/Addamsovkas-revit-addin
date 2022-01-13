#region Namespaces
using System;
using System.Globalization;
using System.Windows.Controls;
using System.Text.RegularExpressions;
using System.Collections.Generic;
#endregion

namespace Xem
{
    /// <summary>
    /// Validation for user field
    /// </summary>
    class RuleNamingValidation : ValidationRule
    {
        // Accesing View model properties (Testing Lisk)
        public EditExportSettingsPageViewModel viewModel { get; set; }

        /// <summary>
        /// Overrides validate function to check if the naming rules for export are written correctly
        /// </summary>
        /// <param name="value"></param>
        /// <param name="cultureInfo"></param>
        /// <returns></returns>
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string sOriginal = (string)value;

            // Get all <parameters> and <>
            string regexParameters = @"<([^><]*)>";
            Regex controlString = new Regex(regexParameters);
            Match onlyBracketMatch = controlString.Match(sOriginal);

            // Replace all <> pairs with empty string and check if there is any bracket left with another regex
            string replacement = Regex.Replace(sOriginal, regexParameters, "");
            Regex containsBracket = new Regex(@"[<>]");
            if (containsBracket.IsMatch(replacement))
            {
                return new ValidationResult(false, "Please check, < > should be used only for parameters.");
            }

            // Get list of avaiable parameter names
            // View parameters for views
            // TODO: Sheet parameters for sheets (will be implemented later)
            RevitModel revit = new RevitModel();
            List<string> paramList = revit.Get3DViewParameters();


            // Check all parameters if they are in the list (list of all parameters from Revit element = view)
            while (onlyBracketMatch.Success)
            {
                string rParam = onlyBracketMatch.Groups[1].ToString();
                if (!paramList.Contains(rParam))
                {
                    return new ValidationResult(false, "Not Valid parameter found in < >. Note. Is case sensitive.");
                }
                onlyBracketMatch = onlyBracketMatch.NextMatch();
            }

            return ValidationResult.ValidResult;
        }
    }
}
