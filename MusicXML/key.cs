[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class key
{

    private object[] itemsField;

    private ItemsChoiceType8[] itemsElementNameField;

    private keyoctave[] keyoctaveField;

    private string numberField;

    private yesno printobjectField;

    private bool printobjectFieldSpecified;


    [System.Xml.Serialization.XmlElementAttribute("cancel", typeof(cancel))]
    [System.Xml.Serialization.XmlElementAttribute("fifths", typeof(string), DataType = "integer")]
    [System.Xml.Serialization.XmlElementAttribute("key-accidental", typeof(accidentalvalue))]
    [System.Xml.Serialization.XmlElementAttribute("key-alter", typeof(decimal))]
    [System.Xml.Serialization.XmlElementAttribute("key-step", typeof(step))]
    [System.Xml.Serialization.XmlElementAttribute("mode", typeof(string))]
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
    public ItemsChoiceType8[] ItemsElementName
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


    [System.Xml.Serialization.XmlElementAttribute("key-octave")]
    public keyoctave[] keyoctave
    {
        get
        {
            return this.keyoctaveField;
        }
        set
        {
            this.keyoctaveField = value;
        }
    }


    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "positiveInteger")]
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
}