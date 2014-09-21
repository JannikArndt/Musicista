using System;
using System.Linq;
using System.Xml.Serialization;

namespace Model.Meta.People
{
    public class Person
    {
        [XmlAttribute("FirstName")]
        public string FirstName { get; set; }
        [XmlAttribute("MiddleName")]
        public string MiddleName { get; set; }
        public bool ShouldSerializeMiddleName() { return !string.IsNullOrEmpty(MiddleName); }
        [XmlAttribute("LastName")]
        public string LastName { get; set; }
        [XmlAttribute("Role")]
        public string Role { get; set; }
        [XmlAttribute("Misc")]
        public string Misc { get; set; }
        [XmlIgnore]
        public string FullName
        {
            get
            {
                if (String.IsNullOrEmpty(MiddleName))
                    return FirstName + " " + LastName;
                return FirstName + " " + MiddleName + " " + LastName;
            }
            set
            {
                string[] names = value.Split(' ');
                switch (names.Length)
                {
                    case 0:
                        return;
                    case 1:
                        LastName = names[0];
                        break;
                    case 2:
                        FirstName = names[0];
                        LastName = names[1];
                        break;
                    default:
                        FirstName = names[0];
                        LastName = names.Last();
                        MiddleName = String.Join(" ", names.Skip(1).Take(names.Length - 2));
                        break;
                }
            }
        }

        [XmlIgnore]
        public DateTime Born { get; set; }
        [XmlAttribute("Born")]
        public string BornString
        {
            get { return Born.ToString("yyyy-MM-dd"); }
            set
            {
                DateTime born; DateTime.TryParse(value, out born); Born = born;
            }
        }
        public bool ShouldSerializeBornString() { return Born != new DateTime(); }
        [XmlIgnore]
        public DateTime Died { get; set; }
        [XmlAttribute("Died")]
        public string DiedString { get { return Died.ToString("yyyy-MM-dd"); } set { DateTime died; DateTime.TryParse(value, out died); Died = died; } }

        public bool ShouldSerializeDiedString() { return Died != new DateTime(); }

        public Person()
        {
            FirstName = "";
            MiddleName = "";
            LastName = "";
        }
        public override string ToString()
        {
            return FullName;
        }
    }
}