[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class scorepartwisePart
{

    private scorepartwisePartMeasure[] measureField;

    private string idField;


    [System.Xml.Serialization.XmlElementAttribute("measure")]
    public scorepartwisePartMeasure[] measure
    {
        get
        {
            return this.measureField;
        }
        set
        {
            this.measureField = value;
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