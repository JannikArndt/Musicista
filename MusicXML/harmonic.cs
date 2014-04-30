[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class harmonic
{

    private empty itemField;

    private ItemChoiceType itemElementNameField;

    private empty item1Field;

    private Item1ChoiceType item1ElementNameField;

    private yesno printobjectField;

    private bool printobjectFieldSpecified;

    private abovebelow placementField;

    private bool placementFieldSpecified;


    [System.Xml.Serialization.XmlElementAttribute("artificial", typeof(empty))]
    [System.Xml.Serialization.XmlElementAttribute("natural", typeof(empty))]
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
    public ItemChoiceType ItemElementName
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


    [System.Xml.Serialization.XmlElementAttribute("base-pitch", typeof(empty))]
    [System.Xml.Serialization.XmlElementAttribute("sounding-pitch", typeof(empty))]
    [System.Xml.Serialization.XmlElementAttribute("touching-pitch", typeof(empty))]
    [System.Xml.Serialization.XmlChoiceIdentifierAttribute("Item1ElementName")]
    public empty Item1
    {
        get
        {
            return this.item1Field;
        }
        set
        {
            this.item1Field = value;
        }
    }


    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public Item1ChoiceType Item1ElementName
    {
        get
        {
            return this.item1ElementNameField;
        }
        set
        {
            this.item1ElementNameField = value;
        }
    }


    [System.Xml.Serialization.XmlAttributeAttribute("print-object")]
    public yesno printobject
    {
        get
        {
            return this.printobjectField;
        }
        set
        {
            this.printobjectField = value;
        }
    }


    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool printobjectSpecified
    {
        get
        {
            return this.printobjectFieldSpecified;
        }
        set
        {
            this.printobjectFieldSpecified = value;
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
}