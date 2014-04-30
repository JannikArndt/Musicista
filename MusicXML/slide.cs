[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class slide
{

    private startstop typeField;

    private string numberField;

    private linetype linetypeField;

    private bool linetypeFieldSpecified;

    private decimal dashlengthField;

    private bool dashlengthFieldSpecified;

    private decimal spacelengthField;

    private bool spacelengthFieldSpecified;

    private yesno accelerateField;

    private bool accelerateFieldSpecified;

    private decimal beatsField;

    private bool beatsFieldSpecified;

    private decimal firstbeatField;

    private bool firstbeatFieldSpecified;

    private decimal lastbeatField;

    private bool lastbeatFieldSpecified;

    private string valueField;

    public slide()
    {
        this.numberField = "1";
    }


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


    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "positiveInteger")]
    [System.ComponentModel.DefaultValueAttribute("1")]
    public string number
    {
        get
        {
            return this.numberField;
        }
        set
        {
            this.numberField = value;
        }
    }


    [System.Xml.Serialization.XmlAttributeAttribute("line-type")]
    public linetype linetype
    {
        get
        {
            return this.linetypeField;
        }
        set
        {
            this.linetypeField = value;
        }
    }


    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool linetypeSpecified
    {
        get
        {
            return this.linetypeFieldSpecified;
        }
        set
        {
            this.linetypeFieldSpecified = value;
        }
    }


    [System.Xml.Serialization.XmlAttributeAttribute("dash-length")]
    public decimal dashlength
    {
        get
        {
            return this.dashlengthField;
        }
        set
        {
            this.dashlengthField = value;
        }
    }


    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool dashlengthSpecified
    {
        get
        {
            return this.dashlengthFieldSpecified;
        }
        set
        {
            this.dashlengthFieldSpecified = value;
        }
    }


    [System.Xml.Serialization.XmlAttributeAttribute("space-length")]
    public decimal spacelength
    {
        get
        {
            return this.spacelengthField;
        }
        set
        {
            this.spacelengthField = value;
        }
    }


    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool spacelengthSpecified
    {
        get
        {
            return this.spacelengthFieldSpecified;
        }
        set
        {
            this.spacelengthFieldSpecified = value;
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


    [System.Xml.Serialization.XmlAttributeAttribute("first-beat")]
    public decimal firstbeat
    {
        get
        {
            return this.firstbeatField;
        }
        set
        {
            this.firstbeatField = value;
        }
    }


    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool firstbeatSpecified
    {
        get
        {
            return this.firstbeatFieldSpecified;
        }
        set
        {
            this.firstbeatFieldSpecified = value;
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


    [System.Xml.Serialization.XmlTextAttribute()]
    public string Value
    {
        get
        {
            return this.valueField;
        }
        set
        {
            this.valueField = value;
        }
    }
}