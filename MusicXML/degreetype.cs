[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(TypeName = "degree-type")]
public partial class degreetype
{

    private string textField;

    private degreetypevalue valueField;


    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "token")]
    public string text
    {
        get
        {
            return this.textField;
        }
        set
        {
            this.textField = value;
        }
    }


    [System.Xml.Serialization.XmlTextAttribute()]
    public degreetypevalue Value
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