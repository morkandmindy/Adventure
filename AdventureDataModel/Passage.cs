using System.Xml.Serialization;

namespace Adventure
{
    public class Passage : IDescribable
    {
        [XmlAttribute("Direction")]
        public Directions Direction { get; set; }
        [XmlAttribute("Destination")]
        public int Destination { get; set; }
        [XmlElement("Door")]
        public Door Door { get; set; }
        [XmlAttribute("LongDescription")]
        public string LongDescription { get; set; }
        [XmlAttribute("ShortDescription")]
        public string ShortDescription { get; set; }
    }
}