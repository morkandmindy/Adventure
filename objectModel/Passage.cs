using System.Xml.Serialization;

namespace objectModel
{
    public class Passage : IDescribable
    {
        [XmlElement("Direction")]
        public Directions Direction { get; set; }
        [XmlElement("Destination")]
        public int Destination { get; set; }
        [XmlElement("Door")]
        public Door Door { get; set; }
        [XmlElement("LongDescription")]
        public string LongDescription { get; set; }
        [XmlElement("ShortDescription")]
        public string ShortDescription { get; set; }
    }
}