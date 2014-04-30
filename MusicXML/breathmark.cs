[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(TypeName = "breath-mark")]
public partial class breathmark
{

    private abovebelow placementField;

    private bool placementFieldSpecified;

    private breathmarkvalue valueField;


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
    public breathmarkvalue Value
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