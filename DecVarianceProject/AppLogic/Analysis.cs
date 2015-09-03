using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DecVarianceProject.Entities.Structures;
using DecVarianceProject.Forms;

namespace DecVarianceProject.AppLogic
{ 
    public class Analysis
    {
        public void Execute()
        {
            var analysysForm = new AnalysisForm();
            analysysForm.ShowDialog();
            var sb = new StringBuilder();
            var folderPath = analysysForm.Path;
            var folderName = analysysForm.FolderName;
            var fileName = "Analysis"+folderName+".txt";
            var filesArray = Directory.GetFiles(folderPath);
            var testInfo = new TestInfo { EvAndVariances = new List<EvAndVariance>() };
            var progressBarForm = new ProgressBarForm(filesArray.Count());
            foreach (var name in filesArray)
            {
                try
                {
                    var testForm = new TestEstimationForm(FileActions.Open(name));
                    var evandVariance = new EvAndVariance
                    {
                        EvDiff = testForm.EvProfit,
                        VarianceDiff = testForm.VarianceDiff
                    };
                    testInfo.EvAndVariances.Add(evandVariance);
                    sb.AppendLine(testForm.EvProfit + "  " + testForm.VarianceDiff);
                    
                }
                catch
                {
                    // ignored
                }
                progressBarForm.IncProgressBarValue();
            }
            var notNillElemsCount = 0;
            foreach (var elem in testInfo.EvAndVariances)
            {
                if ((elem.EvDiff != 0) && (elem.VarianceDiff != 0)) notNillElemsCount++;
                testInfo.AvgEvDiff += elem.EvDiff;
                testInfo.AvgVarianceDiff += elem.VarianceDiff;
            }
            testInfo.AvgEvDiff /= notNillElemsCount;
            testInfo.AvgVarianceDiff /= testInfo.EvAndVariances.Count;
            sb.AppendLine("-----------------------------");
            sb.AppendLine("Average Ev diff: " + testInfo.AvgEvDiff + " Average Variance Diff: " + testInfo.AvgVarianceDiff);

            using (var streamWriter = new StreamWriter(folderPath + @"\" + fileName))
            {
                streamWriter.Write(sb.ToString());
            }
            MessageBox.Show("Analysis done!");
        }
    }
}
