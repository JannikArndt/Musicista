[System.Xml.Serialization.XmlIncludeAttribute(typeof(metronometuplet))]
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(TypeName = "time-modification")]
public partial class timemodification
{

    private string actualnotesField;

    private string normalnotesField;

    private notetypevalue normaltypeField;

    private empty[] normaldotField;


    [System.Xml.Serialization.XmlElementAttribute("actual-notes", DataType = "nonNegativeInteger")]
    public string actualnotes
    {
        get
        {
            return this.actualnotesField;
        }
        set
        {
            this.actualnotesField = value;
        }
    }


    [System.Xml.Serialization.XmlElementAttribute("normal-notes", DataType = "nonNegativeInteger")]
    public string normalnotes
    {
        get
        {
            return this.normalnotesField;
        }
        set
        {
            this.normalnotesField = value;
        }
    }


    [System.Xml.Serialization.XmlElementAttribute("normal-type")]
    public notetypevalue normaltype
    {
        get
        {
            return this.normaltypeField;
        }
        set
        {
            this.normaltypeField = value;
        }
    }


    [System.Xml.Serialization.XmlElementAttribute("normal-dot")]
    public empty[] normaldot
    {
        get
        {
            return this.normaldotField;
        }
        set
        {
            this.normaldotField = value;
        }
    }
}