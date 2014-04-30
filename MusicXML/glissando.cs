[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class glissando
{

    private startstop typeField;

    private string numberField;

    private linetype linetypeField;

    private bool linetypeFieldSpecified;

    private decimal dashlengthField;

    private bool dashlengthFieldSpecified;

    private decimal spacelengthField;

    private bool spacelengthFieldSpecified;

    private string valueField;

    public glissando()
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