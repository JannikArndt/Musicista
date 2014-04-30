[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(TypeName = "key-octave")]
public partial class keyoctave
{

    private string numberField;

    private yesno cancelField;

    private bool cancelFieldSpecified;

    private string valueField;


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


    [System.Xml.Serialization.XmlAttributeAttribute()]
    public yesno cancel
    {
        get
        {
            return this.cancelField;
        }
        set
        {
            this.cancelField = value;
        }
    }


    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool cancelSpecified
    {
        get
        {
            return this.cancelFieldSpecified;
        }
        set
        {
            this.cancelFieldSpecified = value;
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