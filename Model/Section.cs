using System.Collections.Generic;

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
