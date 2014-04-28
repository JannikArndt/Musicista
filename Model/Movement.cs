using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Movement
    {
        public List<Segment> ListOfSegments { get; set; } // Andante, Presto, Trio
        public int Number { get; set; }
        public string Tempo { get; set; } // Adagio
        public string Name { get; set; } // Mahler 2, IV: "Urlicht"
        public int BeatsPerMinute { get; set; } // see Beethovens symphonies
    }
}
