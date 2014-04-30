[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(TypeName = "note-type")]
public partial class notetype
{

    private symbolsize sizeField;

    private bool sizeFieldSpecified;

    private notetypevalue valueField;


    [System.Xml.Serialization.XmlAttributeAttribute()]
    public symbolsize size
    {
        get
        {
            return this.sizeField;
        }
        set
        {
            this.sizeField = value;
        }
    }


    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool sizeSpecified
    {
        get
        {
            return this.sizeFieldSpecified;
        }
        set
        {
            this.sizeFieldSpecified = value;
        }
    }


    [System.Xml.Serialization.XmlTextAttribute()]
    public notetypevalue Value
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