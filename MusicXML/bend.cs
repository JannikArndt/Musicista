[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class bend
{

    private decimal bendalterField;

    private empty itemField;

    private ItemChoiceType1 itemElementNameField;

    private placementtext withbarField;

    private yesno accelerateField;

    private bool accelerateFieldSpecified;

    private decimal beatsField;

    private bool beatsFieldSpecified;

    private decimal firstbeatField;

    private bool firstbeatFieldSpecified;

    private decimal lastbeatField;

    private bool lastbeatFieldSpecified;


    [System.Xml.Serialization.XmlElementAttribute("bend-alter")]
    public decimal bendalter
    {
        get
        {
            return this.bendalterField;
        }
        set
        {
            this.bendalterField = value;
        }
    }


    [System.Xml.Serialization.XmlElementAttribute("pre-bend", typeof(empty))]
    [System.Xml.Serialization.XmlElementAttribute("release", typeof(empty))]
    [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemElementName")]
    public empty Item
    {
        get
        {
            return this.itemField;
        }
        set
        {
            this.itemField = value;
        }
    }


    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public ItemChoiceType1 ItemElementName
    {
        get
        {
            return this.itemElementNameField;
        }
        set
        {
            this.itemElementNameField = value;
        }
    }


    [System.Xml.Serialization.XmlElementAttribute("with-bar")]
    public placementtext withbar
    {
        get
        {
            return this.withbarField;
        }
        set
        {
            this.withbarField = value;
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
}