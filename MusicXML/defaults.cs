using System;

using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MusicXML
{
    
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    public class defaults
    {
        private appearance appearanceField;

        private lyricfont[] lyricfontField;

        private lyriclanguage[] lyriclanguageField;
        private emptyfont musicfontField;
        private pagelayout pagelayoutField;
        private scaling scalingField;
        private stafflayout[] stafflayoutField;
        private systemlayout systemlayoutField;
        private emptyfont wordfontField;


        public scaling scaling
        {
            get { return scalingField; }
            set { scalingField = value; }
        }


        [XmlElement("page-layout")]
        public pagelayout pagelayout
        {
            get { return pagelayoutField; }
            set { pagelayoutField = value; }
        }


        [XmlElement("system-layout")]
        public systemlayout systemlayout
        {
            get { return systemlayoutField; }
            set { systemlayoutField = value; }
        }


        [XmlElement("staff-layout")]
        public stafflayout[] stafflayout
        {
            get { return stafflayoutField; }
            set { stafflayoutField = value; }
        }


        public appearance appearance
        {
            get { return appearanceField; }
            set { appearanceField = value; }
        }


        [XmlElement("music-font")]
        public emptyfont musicfont
        {
            get { return musicfontField; }
            set { musicfontField = value; }
        }


        [XmlElement("word-font")]
        public emptyfont wordfont
        {
            get { return wordfontField; }
            set { wordfontField = value; }
        }


        [XmlElement("lyric-font")]
        public lyricfont[] lyricfont
        {
            get { return lyricfontField; }
            set { lyricfontField = value; }
        }


        [XmlElement("lyric-language")]
        public lyriclanguage[] lyriclanguage
        {
            get { return lyriclanguageField; }
            set { lyriclanguageField = value; }
        }
    }
}