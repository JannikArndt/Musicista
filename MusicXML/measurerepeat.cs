[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(TypeName = "measure-repeat")]
public partial class measurerepeat
{

    private startstop typeField;

    private string slashesField;

    private string valueField;


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
    public string slashes
    {
        get
        {
            return this.slashesField;
        }
        set
        {
            this.slashesField = value;
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