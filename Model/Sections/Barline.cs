
using System.Xml.Serialization;

namespace Model.Sections
{
    public class Barline
    {
        [XmlAttribute("Location")]
        public BarlineLocation BarlineLocation { get; set; }


        [XmlAttribute("Beat")]
        public double Beat { get; set; }
        public bool BeatSpecified { get { return BarlineLocation == BarlineLocation.Beat; } }


        [XmlAttribute("Style")]
        public BarlineStyle BarlineStyle { get; set; }


        [XmlAttribute("Fermate")]
        public bool Fermata { get; set; }
        public bool FermataSpecified { get { return Fermata; } }

        public Barline() { }
        public Barline(string location, string barstyle, string repeat = "", bool fermata = false)
        {
            switch (location)
            {
                case "left":
                    BarlineLocation = BarlineLocation.Left;
                    break;
                case "right":
                    BarlineLocation = BarlineLocation.Right;
                    break;
                case "middle":
                    BarlineLocation = BarlineLocation.Beat;
                    break;
                default:
                    BarlineLocation = BarlineLocation.Left;
                    break;
            }

            switch (repeat)
            {
                case "forward":
                    BarlineStyle = BarlineStyle.StartRepeat;
                    break;
                case "backward":
                    BarlineStyle = BarlineStyle.EndRepeat;
                    break;
                default:
                    switch (barstyle)
                    {
                        case "lightheavy":
                            BarlineStyle = BarlineStyle.Final;
                            break;
                        case "lightlight":
                            BarlineStyle = BarlineStyle.Double;
                            break;
                        case "dotted":
                            BarlineStyle = BarlineStyle.Dashed;
                            break;
                        case "none":
                            BarlineStyle = BarlineStyle.Invisible;
                            break;
                        default: // tick, short
                            BarlineStyle = BarlineStyle.Single;
                            break;
                    }
                    break;
            }

            Fermata = fermata;
        }
    }
}
