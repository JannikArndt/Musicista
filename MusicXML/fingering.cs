[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class fingering
{

    private yesno substitutionField;

    private bool substitutionFieldSpecified;

    private yesno alternateField;

    private bool alternateFieldSpecified;

    private abovebelow placementField;

    private bool placementFieldSpecified;

    private string valueField;


    [System.Xml.Serialization.XmlAttributeAttribute()]
    public yesno substitution
    {
        get
        {
            return this.substitutionField;
        }
        set
        {
            this.substitutionField = value;
        }
    }


    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool substitutionSpecified
    {
        get
        {
            return this.substitutionFieldSpecified;
        }
        set
        {
            this.substitutionFieldSpecified = value;
        }
    }


    [System.Xml.Serialization.XmlAttributeAttribute()]
    public yesno alternate
    {
        get
        {
            return this.alternateField;
        }
        set
        {
            this.alternateField = value;
        }
    }


    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool alternateSpecified
    {
        get
        {
            return this.alternateFieldSpecified;
        }
        set
        {
            this.alternateFieldSpecified = value;
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


    [System.Xml.Serialization.XmlTextAttribute()]
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