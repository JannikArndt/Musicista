[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(TypeName = "notehead-text")]
public partial class noteheadtext
{

    private object[] itemsField;


    [System.Xml.Serialization.XmlElementAttribute("accidental-text", typeof(accidentaltext))]
    [System.Xml.Serialization.XmlElementAttribute("display-text", typeof(formattedtext))]
    public object[] Items
    {
        get
        {
            return this.itemsField;
        }
        set
        {
            this.itemsField = value;
        }
    }
}