using System.Collections.Generic;
using System.Xml.Serialization;

namespace Adventure
{
    public class Room : IDescribable
    {
        [XmlArray(ElementName = "Passages")]
        [XmlArrayItem(ElementName = "Passage")]
        public List<Passage> Passages { get; set; }

        //public List<IGameObject> Objects { get; set; }

        [XmlAttribute("Id")]
        public int Id { get; set; }

        [XmlAttribute("LongDescription")]
        public string LongDescription { get; set; }

        [XmlAttribute("ShortDescription")]
        public string ShortDescription { get; set; }
    }
}
