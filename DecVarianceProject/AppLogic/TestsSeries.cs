using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DecVarianceProject.Entities.Structures;
using DecVarianceProject.Forms;

namespace DecVarianceProject.AppLogic
{
    public class TestsSeries
    {
        private Singleton _instance;
        public DataGridView DgView { get; set; }

        public TestsSeries(DataGridView dgv)
        {
            DgView = dgv;
        }

        public void Execute()
        {
            _instance = Singleton.Instance;
            const int testsNum = 3;
            const int idModelsMax = 1;
            const int idMatchDaysMax = 500;


            using (var progressBarForm = new ProgressBarForm(testsNum*idMatchDaysMax*idModelsMax))
            {
                for (var i = 1; i <= testsNum; i++)
                {
                      var test = new List<TestTableContent>();
                      for (var idModel = 1; idModel <= idModelsMax; idModel++)
                      {
                          var simulation = new Simulation();
                          simulation.Exexute();
                          for (var idMatchDay = 1; idMatchDay <= idMatchDaysMax; idMatchDay++)
                          {
                              _instance.MatchDayResults = new MatchDayResults(DgView);
                              _instance.MatchDayResults.Generate(true);
                              var row = new TestTableContent()
                              {
                                  IdModel = idModel,
                                  IdMatchDay = idMatchDay,
                                  BetsSumm = _instance.AllBetsSum,
                                  RaiseSumm = _instance.RaiseSum,
                                  NetWonBefore = _instance.NetWonBefore,
                                  NetWonAfter = _instance.NetWonAfter
                              };
                              test.Add(row);
                              progressBarForm.IncProgressBarValue();
                          }
                      }
                      var testForm = new TestEstimationForm(test);
                      var date = DateTime.Now;
                      const string format = "MMM_ ddd_d-HH_mm_s_yyyy";
                      var fileName =  _instance.LossToAllBetsSumRatio+"-"+ _instance.OutcomesFrequencesRatio + "-" + idMatchDaysMax + "-"+ date.ToString(format);
                      FileActions.Save(fileName, test);
                      // testForm.Show();
                      //testForm.Close();
                      //testForm.Dispose();
                      testForm.ShowAndInstaClose();
                }
            }
        }
    }
}
