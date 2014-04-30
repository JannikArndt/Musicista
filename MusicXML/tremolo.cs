[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tremolo
{

    private startstopsingle typeField;

    private abovebelow placementField;

    private bool placementFieldSpecified;

    private string valueField;

    public tremolo()
    {
        this.typeField = startstopsingle.single;
    }


    [System.Xml.Serialization.XmlAttributeAttribute()]
    [System.ComponentModel.DefaultValueAttribute(startstopsingle.single)]
    public startstopsingle type
    {
        get
        {
            return this.typeField;
        }
        set
        {
            this.typeField = value;
        }
    }


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