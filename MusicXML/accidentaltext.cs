[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(TypeName = "accidental-text")]
public partial class accidentaltext
{

    private string langField;

    private string spaceField;

    private accidentalvalue valueField;


    [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
    public string lang
    {
        get
        {
            return this.langField;
        }
        set
        {
            this.langField = value;
        }
    }


    [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
    public string space
    {
        get
        {
            return this.spaceField;
        }
        set
        {
            this.spaceField = value;
        }
    }


    [System.Xml.Serialization.XmlTextAttribute()]
    public accidentalvalue Value
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