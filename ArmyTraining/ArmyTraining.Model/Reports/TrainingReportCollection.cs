using System.Collections.Generic;

namespace ArmyTraining.Model
{
    public class TrainingReportCollection : List<TrainingReport>
    {
        public TrainingReportCollection PutSerialNo()
        {
            int slNo = 1;
            foreach (TrainingReport report in this)
            {
                report.SerialNo = slNo;
                slNo++;
            }
            return this;
        }
    }
}
