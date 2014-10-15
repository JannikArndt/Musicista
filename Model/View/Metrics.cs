
using System.Xml.Serialization;

namespace Model.View
{
    public class Metrics
    {
        /// <summary>
        /// A reference to what movement this style applies.
        /// </summary>
        [XmlAttribute("MovementNumber")]
        public int MovementNumber { get; set; }

        [XmlElement("Page")]
        public PageMetric Page { get; set; }

        [XmlElement("Margin")]
        public Margin Margin { get; set; }

        [XmlElement("Staff")]
        public StaffMetric Staff { get; set; }

        [XmlElement("System")]
        public SystemMetric System { get; set; }

        [XmlElement("MeasuresPerSystem")]
        public MeasuresMetrics Measures { get; set; }

        [XmlElement("Fontsize")]
        public Fontsize Fontsize { get; set; }


        public Metrics(double width = 0, double height = 0, double marginLeft = 0, double marginTop = 0, double marginRight = 0, double marginBottom = 0, double marginBelowTitle = 0,
            double staffSpacing = 0, double systemSpacing = 0, int measuresPerSystemThreshold = 0,
            double titleSize = 0, double movementSize = 0, double composerSize = 0)
        {
            Page = new PageMetric { Width = width, Height = height };
            Margin = new Margin
            {
                Left = marginLeft,
                Top = marginTop,
                Right = marginRight,
                Bottom = marginBottom,
                BelowTitle = marginBelowTitle
            };
            Staff = new StaffMetric { Spacing = staffSpacing };
            System = new SystemMetric { Spacing = systemSpacing };
            Measures = new MeasuresMetrics { MeasuresPerSystemThreshold = measuresPerSystemThreshold };
            Fontsize = new Fontsize { Title = titleSize, Movement = movementSize, Composer = composerSize };
        }

        public Metrics() { }
    }
}
