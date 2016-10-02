using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace ArmyTraining.Model.Trainings
{
    [XmlType("statuse")]
    public class TrainingStatusCollection 
    {
        public TrainingStatusCollection()
        {
            Items = new List<TrainingStatus>();
        }

        private static TrainingStatusCollection _Instance;

        [XmlElement("add")]
        public List<TrainingStatus> Items { get; set; }

        public static void CreateInstance(string content)
        {
            _Instance = XmlSerializeHelper<TrainingStatusCollection>.Deserialize(content);
        }

        public static TrainingStatusCollection GetInstance()
        {
            return _Instance;
        }

        public TrainingStatus GetStatusById(int id)
        {
            return Items.Find(x => x.Id == id);
        }

        public TrainingStatusCollection GetAllowedStatusList(AlloweStatusCollection allowed)
        {
            TrainingStatusCollection result = new TrainingStatusCollection();
            for (int index = 0; index < allowed.Items.Count; index++)
            {
                result.Items.Add(GetStatusById(allowed.Items[index].Id));
            }
            return result;
        }
    }
}
