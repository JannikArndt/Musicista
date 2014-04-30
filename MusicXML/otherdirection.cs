[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(TypeName = "other-direction")]
public partial class otherdirection
{

    private yesno printobjectField;

    private bool printobjectFieldSpecified;

    private string valueField;


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