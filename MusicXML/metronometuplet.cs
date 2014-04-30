[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(TypeName = "metronome-tuplet")]
public partial class metronometuplet : timemodification
{

    private startstop typeField;

    private yesno bracketField;

    private bool bracketFieldSpecified;

    private showtuplet shownumberField;

    private bool shownumberFieldSpecified;


    [System.Xml.Serialization.XmlAttributeAttribute()]
    public startstop type
    {
        get
        {
            return this.typeField;
        }
        set
        {
            this.typeField = value;
        }
    }


    [System.Xml.Serialization.XmlAttributeAttribute()]
    public yesno bracket
    {
        get
        {
            return this.bracketField;
        }
        set
        {
            this.bracketField = value;
        }
    }


    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool bracketSpecified
    {
        get
        {
            return this.bracketFieldSpecified;
        }
        set
        {
            this.bracketFieldSpecified = value;
        }
    }


    [System.Xml.Serialization.XmlAttributeAttribute("show-number")]
    public showtuplet shownumber
    {
        get
        {
            return this.shownumberField;
        }
        set
        {
            this.shownumberField = value;
        }
    }


    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool shownumberSpecified
    {
        get
        {
            return this.shownumberFieldSpecified;
        }
        set
        {
            this.shownumberFieldSpecified = value;
        }
    }
}