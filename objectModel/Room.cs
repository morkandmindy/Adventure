using System.Collections.Generic;
using System.Xml.Serialization;

namespace objectModel
{
    public class Room : IDescribable
    {
        [XmlElement("Passages")]
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
