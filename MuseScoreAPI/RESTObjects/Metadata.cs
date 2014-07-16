using System.Collections.Generic;
namespace MuseScoreAPI.RESTObjects
{
    public class Metadata
    {
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Composer { get; set; }
        public string Poet { get; set; }
        public int Pages { get; set; }
        public int Measures { get; set; }
        public int lyrics { get; set; }
        public int chordnames { get; set; }
        public int keysig { get; set; }
        public int duration { get; set; }
        public string dimensions { get; set; }
        public List<part> parts { get; set; }
    }
}
