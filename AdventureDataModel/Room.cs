using System.Collections.Generic;
using System.Xml.Serialization;
namespace AdventureDataModel
{
    public class Room : IDescribable
    {
        [XmlArray(ElementName = "Passages")]
        [XmlArrayItem(ElementName = "Passage")]
        public List<Passage> Passages { get; set; }

        //public List<IGameObject> Objects { get; set; }

        [XmlAttribute("Id")]
        public int Id { get; set; }

        [XmlAttribute("Name")]
        public string Name { get; set; }

        [XmlAttribute("Description")]
        public string Description { get; set; }

    }
}
