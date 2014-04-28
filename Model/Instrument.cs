using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Instrument
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public Instrument(string name = "", int id = 0)
        {
            ID = id;
            Name = name;
        }
    }
}
