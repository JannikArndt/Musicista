using System;
using System.Linq;
using System.Xml.Serialization;

namespace Model.Meta.People
{
    public class Person
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public bool ShouldSerializeMiddleName() { return !string.IsNullOrEmpty(MiddleName); }
        public string LastName { get; set; }
        public string Role { get; set; }
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

        public DateTime Born { get; set; }
        public bool ShouldSerializeBorn() { return Born != new DateTime(); }
        public DateTime Died { get; set; }
        public bool ShouldSerializeDied() { return Died != new DateTime(); }

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