using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Section
    {
        public string Name { get; set; }
        public List<Movement> ListOfMovements { get; set; }

        public Section()
        {
            ListOfMovements = new List<Movement>();
        }
    }
}
