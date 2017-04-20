using System.Xml.Serialization;

namespace objectModel
{
    public interface IDescribable
    {
        string LongDescription { get; set; }
        string ShortDescription { get; set; }
    }
}
