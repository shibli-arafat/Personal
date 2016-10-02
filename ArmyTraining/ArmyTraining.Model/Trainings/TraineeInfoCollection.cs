using System.Collections.Generic;
using System.Text;

namespace ArmyTraining.Model.Trainings
{
    public class TraineeInfoCollection : List<TraineeInfo>
    {
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            char[] chars = new char[] { ',', ' ' };
            foreach (TraineeInfo trainee in this)
            {
                builder.AppendFormat("{0}, ", trainee.PersonalNo);
            }
            return builder.ToString().TrimEnd(chars);
        }
    }
}
