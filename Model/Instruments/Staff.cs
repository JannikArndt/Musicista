
using System.Xml.Serialization;

namespace Model.Instruments
{
    /// <summary>
    /// Instructs how to notate an instrumet, i.e. a flute has one staff, the Flute 2 has one as well, but it may point to the first Flute ones. A piano has two staves.
    /// </summary>
    public class Staff
    {
        [XmlAttribute("ID")]
        public int ID { get; set; }

        [XmlAttribute("PrintInStaff")]
        public string PrintInStaffString
        {
            get { return PrintInStaff.ToString(); }
        }
        [XmlIgnore]
        public Staff PrintInStaff = null;

        public override string ToString()
        {
            return "" + ID;
        }
    }
}
