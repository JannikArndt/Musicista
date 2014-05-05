using System;
using System.Linq;

namespace Model
{
    public class Person
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public string FullName
        {
            get { return FirstName + " " + MiddleName + " " + LastName; }
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
        public DateTime Died { get; set; }

        public override string ToString()
        {
            return FullName;
        }
    }
}