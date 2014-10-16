
using System.Xml.Serialization;

namespace Model.Sections
{
    /// <summary>
    /// Represents a bar line with different styles, locations and an optional fermata
    /// </summary>
    public class Barline
    {
        [XmlAttribute("Location")]
        public BarlineLocation Location { get; set; }


        [XmlAttribute("Beat")]
        public double Beat { get; set; }
        public bool BeatSpecified { get { return Location == BarlineLocation.Beat; } }


        [XmlAttribute("Type")]
        public BarlineType Type { get; set; }


        [XmlAttribute("Fermata")]
        public bool Fermata { get; set; }
        public bool FermataSpecified { get { return Fermata; } }

        public Barline() { }
        public Barline(string location, string barstyle, string repeat = "", bool fermata = false)
        {
            switch (location)
            {
                case "left":
                    Location = BarlineLocation.Left;
                    break;
                case "right":
                    Location = BarlineLocation.Right;
                    break;
                case "middle":
                    Location = BarlineLocation.Beat;
                    break;
                default:
                    Location = BarlineLocation.Left;
                    break;
            }

            switch (repeat)
            {
                case "forward":
                    Type = BarlineType.StartRepeat;
                    break;
                case "backward":
                    Type = BarlineType.EndRepeat;
                    break;
                default:
                    switch (barstyle)
                    {
                        case "lightheavy":
                            Type = BarlineType.Final;
                            break;
                        case "lightlight":
                            Type = BarlineType.Double;
                            break;
                        case "dotted":
                            Type = BarlineType.Dashed;
                            break;
                        case "none":
                            Type = BarlineType.Invisible;
                            break;
                        default: // tick, short
                            Type = BarlineType.Single;
                            break;
                    }
                    break;
            }

            Fermata = fermata;
        }
    }
}
