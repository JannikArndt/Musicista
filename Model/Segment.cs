using System.Collections.Generic;

namespace Model
{
    /// <summary>
    /// Andante, Presto, Trio, ...
    /// </summary>
    public class Segment
    {
        public List<Passage> ListOfPassages { get; set; }
        public string Title { get; set; }
    }
}
