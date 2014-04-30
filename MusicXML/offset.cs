[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class offset
{

    private yesno soundField;

    private bool soundFieldSpecified;

    private decimal valueField;


    [System.Xml.Serialization.XmlAttributeAttribute()]
    public yesno sound
    {
        get
        {
            return this.soundField;
        }
        set
        {
            this.soundField = value;
        }
    }


    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool soundSpecified
    {
        get
        {
            return this.soundFieldSpecified;
        }
        set
        {
            this.soundFieldSpecified = value;
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