[System.Xml.Serialization.XmlIncludeAttribute(typeof(mordent))]
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(TypeName = "empty-trill-sound")]
public partial class emptytrillsound
{

    private abovebelow placementField;

    private bool placementFieldSpecified;

    private startnote startnoteField;

    private bool startnoteFieldSpecified;

    private trillstep trillstepField;

    private bool trillstepFieldSpecified;

    private twonoteturn twonoteturnField;

    private bool twonoteturnFieldSpecified;

    private yesno accelerateField;

    private bool accelerateFieldSpecified;

    private decimal beatsField;

    private bool beatsFieldSpecified;

    private decimal secondbeatField;

    private bool secondbeatFieldSpecified;

    private decimal lastbeatField;

    private bool lastbeatFieldSpecified;


    [System.Xml.Serialization.XmlAttributeAttribute()]
    public abovebelow placement
    {
        get
        {
            return this.placementField;
        }
        set
        {
            this.placementField = value;
        }
    }


    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool placementSpecified
    {
        get
        {
            return this.placementFieldSpecified;
        }
        set
        {
            this.placementFieldSpecified = value;
        }
    }


    [System.Xml.Serialization.XmlAttributeAttribute("start-note")]
    public startnote startnote
    {
        get
        {
            return this.startnoteField;
        }
        set
        {
            this.startnoteField = value;
        }
    }


    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool startnoteSpecified
    {
        get
        {
            return this.startnoteFieldSpecified;
        }
        set
        {
            this.startnoteFieldSpecified = value;
        }
    }


    [System.Xml.Serialization.XmlAttributeAttribute("trill-step")]
    public trillstep trillstep
    {
        get
        {
            return this.trillstepField;
        }
        set
        {
            this.trillstepField = value;
        }
    }


    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool trillstepSpecified
    {
        get
        {
            return this.trillstepFieldSpecified;
        }
        set
        {
            this.trillstepFieldSpecified = value;
        }
    }


    [System.Xml.Serialization.XmlAttributeAttribute("two-note-turn")]
    public twonoteturn twonoteturn
    {
        get
        {
            return this.twonoteturnField;
        }
        set
        {
            this.twonoteturnField = value;
        }
    }


    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool twonoteturnSpecified
    {
        get
        {
            return this.twonoteturnFieldSpecified;
        }
        set
        {
            this.twonoteturnFieldSpecified = value;
        }
    }


    [System.Xml.Serialization.XmlAttributeAttribute()]
    public yesno accelerate
    {
        get
        {
            return this.accelerateField;
        }
        set
        {
            this.accelerateField = value;
        }
    }


    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool accelerateSpecified
    {
        get
        {
            return this.accelerateFieldSpecified;
        }
        set
        {
            this.accelerateFieldSpecified = value;
        }
    }


    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal beats
    {
        get
        {
            return this.beatsField;
        }
        set
        {
            this.beatsField = value;
        }
    }


    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool beatsSpecified
    {
        get
        {
            return this.beatsFieldSpecified;
        }
        set
        {
            this.beatsFieldSpecified = value;
        }
    }


    [System.Xml.Serialization.XmlAttributeAttribute("second-beat")]
    public decimal secondbeat
    {
        get
        {
            return this.secondbeatField;
        }
        set
        {
            this.secondbeatField = value;
        }
    }


    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool secondbeatSpecified
    {
        get
        {
            return this.secondbeatFieldSpecified;
        }
        set
        {
            this.secondbeatFieldSpecified = value;
        }
    }


    [System.Xml.Serialization.XmlAttributeAttribute("last-beat")]
    public decimal lastbeat
    {
        get
        {
            return this.lastbeatField;
        }
        set
        {
            this.lastbeatField = value;
        }
    }


    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool lastbeatSpecified
    {
        get
        {
            return this.lastbeatFieldSpecified;
        }
        set
        {
            this.lastbeatFieldSpecified = value;
        }
    }
}