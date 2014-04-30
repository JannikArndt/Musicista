[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(TypeName = "degree-alter")]
public partial class degreealter
{

    private yesno plusminusField;

    private bool plusminusFieldSpecified;

    private decimal valueField;


    [System.Xml.Serialization.XmlAttributeAttribute("plus-minus")]
    public yesno plusminus
    {
        get
        {
            return this.plusminusField;
        }
        set
        {
            this.plusminusField = value;
        }
    }


    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool plusminusSpecified
    {
        get
        {
            return this.plusminusFieldSpecified;
        }
        set
        {
            this.plusminusFieldSpecified = value;
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