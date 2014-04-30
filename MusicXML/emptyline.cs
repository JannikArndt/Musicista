[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(TypeName = "empty-line")]
public partial class emptyline
{

    private lineshape lineshapeField;

    private bool lineshapeFieldSpecified;

    private linetype linetypeField;

    private bool linetypeFieldSpecified;

    private decimal dashlengthField;

    private bool dashlengthFieldSpecified;

    private decimal spacelengthField;

    private bool spacelengthFieldSpecified;

    private abovebelow placementField;

    private bool placementFieldSpecified;


    [System.Xml.Serialization.XmlAttributeAttribute("line-shape")]
    public lineshape lineshape
    {
        get
        {
            return this.lineshapeField;
        }
        set
        {
            this.lineshapeField = value;
        }
    }


    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool lineshapeSpecified
    {
        get
        {
            return this.lineshapeFieldSpecified;
        }
        set
        {
            this.lineshapeFieldSpecified = value;
        }
    }


    [System.Xml.Serialization.XmlAttributeAttribute("line-type")]
    public linetype linetype
    {
        get
        {
            return this.linetypeField;
        }
        set
        {
            this.linetypeField = value;
        }
    }


    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool linetypeSpecified
    {
        get
        {
            return this.linetypeFieldSpecified;
        }
        set
        {
            this.linetypeFieldSpecified = value;
        }
    }


    [System.Xml.Serialization.XmlAttributeAttribute("dash-length")]
    public decimal dashlength
    {
        get
        {
            return this.dashlengthField;
        }
        set
        {
            this.dashlengthField = value;
        }
    }


    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool dashlengthSpecified
    {
        get
        {
            return this.dashlengthFieldSpecified;
        }
        set
        {
            this.dashlengthFieldSpecified = value;
        }
    }


    [System.Xml.Serialization.XmlAttributeAttribute("space-length")]
    public decimal spacelength
    {
        get
        {
            return this.spacelengthField;
        }
        set
        {
            this.spacelengthField = value;
        }
    }


    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool spacelengthSpecified
    {
        get
        {
            return this.spacelengthFieldSpecified;
        }
        set
        {
            this.spacelengthFieldSpecified = value;
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
}