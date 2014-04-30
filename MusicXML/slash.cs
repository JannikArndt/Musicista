[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class slash
{

    private notetypevalue slashtypeField;

    private empty[] slashdotField;

    private startstop typeField;

    private yesno usedotsField;

    private bool usedotsFieldSpecified;

    private yesno usestemsField;

    private bool usestemsFieldSpecified;


    [System.Xml.Serialization.XmlElementAttribute("slash-type")]
    public notetypevalue slashtype
    {
        get
        {
            return this.slashtypeField;
        }
        set
        {
            this.slashtypeField = value;
        }
    }


    [System.Xml.Serialization.XmlElementAttribute("slash-dot")]
    public empty[] slashdot
    {
        get
        {
            return this.slashdotField;
        }
        set
        {
            this.slashdotField = value;
        }
    }


    [System.Xml.Serialization.XmlAttributeAttribute()]
    public startstop type
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


    [System.Xml.Serialization.XmlAttributeAttribute("use-dots")]
    public yesno usedots
    {
        get
        {
            return this.usedotsField;
        }
        set
        {
            this.usedotsField = value;
        }
    }


    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool usedotsSpecified
    {
        get
        {
            return this.usedotsFieldSpecified;
        }
        set
        {
            this.usedotsFieldSpecified = value;
        }
    }


    [System.Xml.Serialization.XmlAttributeAttribute("use-stems")]
    public yesno usestems
    {
        get
        {
            return this.usestemsField;
        }
        set
        {
            this.usestemsField = value;
        }
    }


    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool usestemsSpecified
    {
        get
        {
            return this.usestemsFieldSpecified;
        }
        set
        {
            this.usestemsFieldSpecified = value;
        }
    }
}