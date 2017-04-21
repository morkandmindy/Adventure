using System.Xml.Serialization;

namespace Adventure
{
    public interface IDescribable
    {
        string LongDescription { get; set; }
        string ShortDescription { get; set; }
    }
}
