using System.Xml.Serialization;

namespace AdventureDataModel
{
    public class Passage
    {
        [XmlAttribute("Direction")]
        public Directions Direction { get; set; }
        [XmlAttribute("Destination")]
        public int Destination { get; set; }
        [XmlElement("Door")]
        public Door Door { get; set; }
    }
}