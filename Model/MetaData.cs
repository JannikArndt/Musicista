using Model.Meta;
using Model.Meta.People;
using Model.Sections.Attributes;
using System.Xml.Serialization;

namespace Model
{
    public class MetaData
    {
        public string Title { get; set; }
        public string Subtitle { get; set; }

        [XmlElement("People")]
        public People People { get; set; }

        public string Collection { get; set; }
        public OpusNumber Opus { get; set; }
        public Epoch Epoch { get; set; }
        public Form Form { get; set; }
        [XmlElement("Dates")]
        public Dates Dates { get; set; }

        public string Dedication { get; set; }
        public double AverageDuration { get; set; }

        public int BeatsPerMinute { get; set; }
        public MusicalKey Key { get; set; }
        public Album Album { get; set; }

        public string Copyright { get; set; }
        public string Reduction { get; set; }
        public string Weblink { get; set; }
        public string Notes { get; set; }
        public string Software { get; set; }

        public MetaData()
        {
            Title = "New Piece";
            People = new People();
            Dates = new Dates();
            Collection = "";
            Opus = new OpusNumber();
            Epoch = Epoch.None;
            Form = Form.Other;
        }
    }
}
