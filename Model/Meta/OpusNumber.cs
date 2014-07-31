
using System.Xml.Serialization;

namespace Model.Meta
{
    public class OpusNumber
    {
        [XmlAttribute]
        public int Number { get; set; }
        [XmlAttribute]
        public int SubNumber { get; set; }
        [XmlAttribute]
        public bool Posthum = false;
        public bool ShouldSerializePosthum() { return Posthum; }
        public string OpusString
        {
            get
            {
                if (Posthum)
                    return "Op. posth.";
                if (SubNumber != 0)
                    return "Op. " + Number + ", No. " + SubNumber;
                else if (Number != 0)
                    return "Op. " + Number;
                return "-";
            }
        }

        public OpusNumber()
        {
            Number = 0;
            SubNumber = 0;
        }
        public OpusNumber(int number = 0, int subnumber = 0, bool posthum = false)
        {
            Number = number;
            SubNumber = subnumber;
            Posthum = posthum;
        }
    }
}
