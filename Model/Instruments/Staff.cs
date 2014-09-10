
using System.Xml.Serialization;

namespace Model.Instruments
{
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
