using System.Xml.Serialization;

namespace AdventureDataModel
{
    public class Key : IDescribable
    {
        [XmlAttribute("Name")]
        public string Name { get; set; }

        [XmlAttribute("Description")]
        public string Description { get; set; }
    }
}