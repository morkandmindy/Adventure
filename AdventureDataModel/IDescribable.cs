using System.Xml.Serialization;

namespace AdventureDataModel
{
    public interface IDescribable
    {
        string Name { get; set; }
        string Description { get; set; }
    }
}
