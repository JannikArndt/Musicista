[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class grace
{

    private decimal stealtimepreviousField;

    private bool stealtimepreviousFieldSpecified;

    private decimal stealtimefollowingField;

    private bool stealtimefollowingFieldSpecified;

    private decimal maketimeField;

    private bool maketimeFieldSpecified;

    private yesno slashField;

    private bool slashFieldSpecified;


    [System.Xml.Serialization.XmlAttributeAttribute("steal-time-previous")]
    public decimal stealtimeprevious
    {
        get
        {
            return this.stealtimepreviousField;
        }
        set
        {
            this.stealtimepreviousField = value;
        }
    }


    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool stealtimepreviousSpecified
    {
        get
        {
            return this.stealtimepreviousFieldSpecified;
        }
        set
        {
            this.stealtimepreviousFieldSpecified = value;
        }
    }


    [System.Xml.Serialization.XmlAttributeAttribute("steal-time-following")]
    public decimal stealtimefollowing
    {
        get
        {
            return this.stealtimefollowingField;
        }
        set
        {
            this.stealtimefollowingField = value;
        }
    }


    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool stealtimefollowingSpecified
    {
        get
        {
            return this.stealtimefollowingFieldSpecified;
        }
        set
        {
            this.stealtimefollowingFieldSpecified = value;
        }
    }


    [System.Xml.Serialization.XmlAttributeAttribute("make-time")]
    public decimal maketime
    {
        get
        {
            return this.maketimeField;
        }
        set
        {
            this.maketimeField = value;
        }
    }


    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool maketimeSpecified
    {
        get
        {
            return this.maketimeFieldSpecified;
        }
        set
        {
            this.maketimeFieldSpecified = value;
        }
    }


    [System.Xml.Serialization.XmlAttributeAttribute()]
    public yesno slash
    {
        get
        {
            return this.slashField;
        }
        set
        {
            this.slashField = value;
        }
    }


    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool slashSpecified
    {
        get
        {
            return this.slashFieldSpecified;
        }
        set
        {
            this.slashFieldSpecified = value;
        }
    }
}