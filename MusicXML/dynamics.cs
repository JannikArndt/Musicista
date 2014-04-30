[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class dynamics
{

    private object[] itemsField;

    private ItemsChoiceType5[] itemsElementNameField;

    private abovebelow placementField;

    private bool placementFieldSpecified;

    private string underlineField;

    private string overlineField;

    private string linethroughField;

    private enclosureshape enclosureField;

    private bool enclosureFieldSpecified;


    [System.Xml.Serialization.XmlElementAttribute("f", typeof(empty))]
    [System.Xml.Serialization.XmlElementAttribute("ff", typeof(empty))]
    [System.Xml.Serialization.XmlElementAttribute("fff", typeof(empty))]
    [System.Xml.Serialization.XmlElementAttribute("ffff", typeof(empty))]
    [System.Xml.Serialization.XmlElementAttribute("fffff", typeof(empty))]
    [System.Xml.Serialization.XmlElementAttribute("ffffff", typeof(empty))]
    [System.Xml.Serialization.XmlElementAttribute("fp", typeof(empty))]
    [System.Xml.Serialization.XmlElementAttribute("fz", typeof(empty))]
    [System.Xml.Serialization.XmlElementAttribute("mf", typeof(empty))]
    [System.Xml.Serialization.XmlElementAttribute("mp", typeof(empty))]
    [System.Xml.Serialization.XmlElementAttribute("other-dynamics", typeof(string))]
    [System.Xml.Serialization.XmlElementAttribute("p", typeof(empty))]
    [System.Xml.Serialization.XmlElementAttribute("pp", typeof(empty))]
    [System.Xml.Serialization.XmlElementAttribute("ppp", typeof(empty))]
    [System.Xml.Serialization.XmlElementAttribute("pppp", typeof(empty))]
    [System.Xml.Serialization.XmlElementAttribute("ppppp", typeof(empty))]
    [System.Xml.Serialization.XmlElementAttribute("pppppp", typeof(empty))]
    [System.Xml.Serialization.XmlElementAttribute("rf", typeof(empty))]
    [System.Xml.Serialization.XmlElementAttribute("rfz", typeof(empty))]
    [System.Xml.Serialization.XmlElementAttribute("sf", typeof(empty))]
    [System.Xml.Serialization.XmlElementAttribute("sffz", typeof(empty))]
    [System.Xml.Serialization.XmlElementAttribute("sfp", typeof(empty))]
    [System.Xml.Serialization.XmlElementAttribute("sfpp", typeof(empty))]
    [System.Xml.Serialization.XmlElementAttribute("sfz", typeof(empty))]
    [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
    public object[] Items
    {
        get
        {
            return this.itemsField;
        }
        set
        {
            this.itemsField = value;
        }
    }


    [System.Xml.Serialization.XmlElementAttribute("ItemsElementName")]
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public ItemsChoiceType5[] ItemsElementName
    {
        get
        {
            return this.itemsElementNameField;
        }
        set
        {
            this.itemsElementNameField = value;
        }
    }


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


    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "nonNegativeInteger")]
    public string underline
    {
        get
        {
            return this.underlineField;
        }
        set
        {
            this.underlineField = value;
        }
    }


    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "nonNegativeInteger")]
    public string overline
    {
        get
        {
            return this.overlineField;
        }
        set
        {
            this.overlineField = value;
        }
    }


    [System.Xml.Serialization.XmlAttributeAttribute("line-through", DataType = "nonNegativeInteger")]
    public string linethrough
    {
        get
        {
            return this.linethroughField;
        }
        set
        {
            this.linethroughField = value;
        }
    }


    [System.Xml.Serialization.XmlAttributeAttribute()]
    public enclosureshape enclosure
    {
        get
        {
            return this.enclosureField;
        }
        set
        {
            this.enclosureField = value;
        }
    }


    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool enclosureSpecified
    {
        get
        {
            return this.enclosureFieldSpecified;
        }
        set
        {
            this.enclosureFieldSpecified = value;
        }
    }
}