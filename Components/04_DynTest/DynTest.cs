#region Namespaces
using System;
using System.Collections.Generic;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Dynamo.Applications;
#endregion

namespace DynTest
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class DynTestCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            //Get application and documnet objects and start transaction
            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;

            // Data for empty Dynamo to Run
            IDictionary<string, string> journalData = new Dictionary<string, string>
            {
                { JournalKeys.ShowUiKey, false.ToString() },
                { JournalKeys.AutomationModeKey, true.ToString() },
                { JournalKeys.DynPathKey, "" },
                { JournalKeys.DynPathExecuteKey, true.ToString() },
                { JournalKeys.ForceManualRunKey, false.ToString() },
                { JournalKeys.ModelShutDownKey, true.ToString() },
                { JournalKeys.ModelNodesInfo, false.ToString() }

            };

            DynamoRevitCommandData dynamoRevitCommandData = new DynamoRevitCommandData();
            dynamoRevitCommandData.Application = uiapp;
            dynamoRevitCommandData.JournalData = journalData;

            // Load and Execute the dynamo script
            try
            {
                // Get script path - script must be saved in automatic mode
                string Journal_Dynamo_Path = @"C:\ProgramData\Autodesk\Revit\Addins\2020\DynTest\DynTest.dyn";

                // Start Dynamo
                DynamoRevit dynamoRevit = new DynamoRevit();
                dynamoRevit.ExecuteCommand(dynamoRevitCommandData);

                DynamoRevit.RevitDynamoModel.OpenFileFromPath(Journal_Dynamo_Path, false);
                DynamoRevit.RevitDynamoModel.ForceRun();
                return Result.Succeeded;

            }
            catch(Exception e) {
                TaskDialog.Show("Revit", "Script Failed!" + e);
                return Result.Failed;
            }
        }
    }
}