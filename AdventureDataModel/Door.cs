using System.Collections.Generic;
using System.Dynamic;
using System.Xml.Serialization;

namespace AdventureDataModel
{
    public class Door : IDescribable
    {
        [XmlAttribute("KeyId")]
        public int KeyId { get; set; }
        [XmlAttribute("Name")]
        public string Name { get; set; }
        [XmlAttribute("Description")]
        public string Description { get; set; }
    }
}