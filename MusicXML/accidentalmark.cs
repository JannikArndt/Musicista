[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(TypeName = "accidental-mark")]
public partial class accidentalmark
{

    private abovebelow placementField;

    private bool placementFieldSpecified;

    private accidentalvalue valueField;


    [System.Xml.Serialization.XmlAttributeAttribute()]
    public abovebelow placement
    {
        get
        {
            return this.placementField;
        }
        set
        {
            this.placementField = value;
        }
    }


    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool placementSpecified
    {
        get
        {
            return this.placementFieldSpecified;
        }
        set
        {
            this.placementFieldSpecified = value;
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