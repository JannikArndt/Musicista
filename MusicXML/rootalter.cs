[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(TypeName = "root-alter")]
public partial class rootalter
{

    private yesno printobjectField;

    private bool printobjectFieldSpecified;

    private leftright locationField;

    private bool locationFieldSpecified;

    private decimal valueField;


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
    public leftright location
    {
        get
        {
            return this.locationField;
        }
        set
        {
            this.locationField = value;
        }
    }


    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool locationSpecified
    {
        get
        {
            return this.locationFieldSpecified;
        }
        set
        {
            this.locationFieldSpecified = value;
        }
    }


    [System.Xml.Serialization.XmlTextAttribute()]
    public decimal Value
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