[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class supports
{

    private yesno typeField;

    private string elementField;

    private string attributeField;

    private string valueField;


    [System.Xml.Serialization.XmlAttributeAttribute()]
    public yesno type
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


    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NMTOKEN")]
    public string element
    {
        get
        {
            return this.elementField;
        }
        set
        {
            this.elementField = value;
        }
    }


    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NMTOKEN")]
    public string attribute
    {
        get
        {
            return this.attributeField;
        }
        set
        {
            this.attributeField = value;
        }
    }


    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "token")]
    public string value
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