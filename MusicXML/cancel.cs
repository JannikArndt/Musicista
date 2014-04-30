[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class cancel
{

    private cancellocation locationField;

    private bool locationFieldSpecified;

    private string valueField;


    [System.Xml.Serialization.XmlAttributeAttribute()]
    public cancellocation location
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


    [System.Xml.Serialization.XmlTextAttribute(DataType = "integer")]
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