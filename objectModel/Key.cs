using System.Xml.Serialization;

namespace objectModel
{
    public class Key : IDescribable
    {
        [XmlElement("LongDescription")]
        public string LongDescription { get; set; }
        [XmlElement("ShortDescription")]
        public string ShortDescription { get; set; }
    }
}