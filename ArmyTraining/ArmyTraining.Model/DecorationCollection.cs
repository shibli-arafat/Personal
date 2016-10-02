using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ArmyTraining.Model
{
    [Serializable]
    [XmlType("decorations")]
    public class DecorationCollection : List<Decoration>
    {
        public Decoration GetById(int id)
        {
            return this.Find(x => x.Id == id);
        }
    }
}
