namespace MusicXML
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class defaults
    {

        private scaling scalingField;

        private pagelayout pagelayoutField;

        private systemlayout systemlayoutField;

        private stafflayout[] stafflayoutField;

        private appearance appearanceField;

        private emptyfont musicfontField;

        private emptyfont wordfontField;

        private lyricfont[] lyricfontField;

        private lyriclanguage[] lyriclanguageField;


        public scaling scaling
        {
            get
            {
                return this.scalingField;
            }
            set
            {
                this.scalingField = value;
            }
        }


        [System.Xml.Serialization.XmlElementAttribute("page-layout")]
        public pagelayout pagelayout
        {
            get
            {
                return this.pagelayoutField;
            }
            set
            {
                this.pagelayoutField = value;
            }
        }


        [System.Xml.Serialization.XmlElementAttribute("system-layout")]
        public systemlayout systemlayout
        {
            get
            {
                return this.systemlayoutField;
            }
            set
            {
                this.systemlayoutField = value;
            }
        }


        [System.Xml.Serialization.XmlElementAttribute("staff-layout")]
        public stafflayout[] stafflayout
        {
            get
            {
                return this.stafflayoutField;
            }
            set
            {
                this.stafflayoutField = value;
            }
        }


        public appearance appearance
        {
            get
            {
                return this.appearanceField;
            }
            set
            {
                this.appearanceField = value;
            }
        }


        [System.Xml.Serialization.XmlElementAttribute("music-font")]
        public emptyfont musicfont
        {
            get
            {
                return this.musicfontField;
            }
            set
            {
                this.musicfontField = value;
            }
        }


        [System.Xml.Serialization.XmlElementAttribute("word-font")]
        public emptyfont wordfont
        {
            get
            {
                return this.wordfontField;
            }
            set
            {
                this.wordfontField = value;
            }
        }


        [System.Xml.Serialization.XmlElementAttribute("lyric-font")]
        public lyricfont[] lyricfont
        {
            get
            {
                return this.lyricfontField;
            }
            set
            {
                this.lyricfontField = value;
            }
        }


        [System.Xml.Serialization.XmlElementAttribute("lyric-language")]
        public lyriclanguage[] lyriclanguage
        {
            get
            {
                return this.lyriclanguageField;
            }
            set
            {
                this.lyriclanguageField = value;
            }
        }
    }
}