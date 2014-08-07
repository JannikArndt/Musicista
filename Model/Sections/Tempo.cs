using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace Model.Sections
{
    public class Tempo
    {
        [XmlIgnore]
        public TempoString TempoString { get; set; }
        [XmlIgnore]
        public TempoChangeString TempoChangeString { get; set; }
        [XmlIgnore]
        public String FreeText { get; set; }
        [XmlIgnore]
        public int BeatsPerMinute { get; set; }

        [XmlAttribute]
        public double Beat { get; set; }

        [XmlAttribute("Text")]
        public String TempoText
        {
            get
            {
                //var bpmText = BeatsPerMinute > 0 ? " (Quarter = " + BeatsPerMinute + ")" : "";
                if (TempoString != TempoString.None) return TempoString.GetDescription();// + bpmText;
                if (TempoChangeString != TempoChangeString.None) return TempoChangeString.GetDescription();// + bpmText;
                return !string.IsNullOrEmpty(FreeText) ? FreeText : "";
            }
            set
            {
                Parse(value);
            }
        }

        public override string ToString()
        {
            return TempoText;
        }

        public Tempo()
        {
        }

        public bool Parse(string tempoString)
        {
            if (tempoString == null) return false;

            var stringParts = tempoString.Split('(');
            var parseString = stringParts[0].RemoveWhitespace();

            if (stringParts.Count() > 1)
            {
                int number;
                int.TryParse(Regex.Match(stringParts[1], @"\d+").Value, out number);
                BeatsPerMinute = number;
            }

            if (Enum.IsDefined(typeof(TempoString), parseString))
            {
                TempoString = (TempoString)Enum.Parse(typeof(TempoString), parseString);
                return true;
            }

            parseString = parseString.ToLower().Replace(".", String.Empty);

            if (Enum.IsDefined(typeof(TempoChangeString), parseString))
            {
                TempoChangeString = (TempoChangeString)Enum.Parse(typeof(TempoChangeString), parseString);
                return true;
            }
            return false;
        }
    }
}
