using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Part
    {
        public Instrument Instrument { get; set; }
        public List<Symbol> ListOfSymbols { get; set; }
    }
}
