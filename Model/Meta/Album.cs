
using System;

namespace Model.Meta
{
    public class Album
    {
        public string Title { get; set; }
        public string Label { get; set; }
        public DateTime Published { get; set; }
        public TimeSpan Duration { get; set; }

        public Album() { }
    }
}
