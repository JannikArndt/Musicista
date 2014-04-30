[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class play
{

    private object[] itemsField;

    private string idField;


    [System.Xml.Serialization.XmlElementAttribute("ipa", typeof(string))]
    [System.Xml.Serialization.XmlElementAttribute("mute", typeof(mute))]
    [System.Xml.Serialization.XmlElementAttribute("other-play", typeof(otherplay))]
    [System.Xml.Serialization.XmlElementAttribute("semi-pitched", typeof(semipitched))]
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


    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "IDREF")]
    public string id
    {
        get
        {
            return this.idField;
        }
        set
        {
            this.idField = value;
        }
    }
}