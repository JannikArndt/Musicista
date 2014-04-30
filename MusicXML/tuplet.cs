[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tuplet
{

    private tupletportion tupletactualField;

    private tupletportion tupletnormalField;

    private startstop typeField;

    private string numberField;

    private yesno bracketField;

    private bool bracketFieldSpecified;

    private showtuplet shownumberField;

    private bool shownumberFieldSpecified;

    private showtuplet showtypeField;

    private bool showtypeFieldSpecified;

    private lineshape lineshapeField;

    private bool lineshapeFieldSpecified;

    private decimal defaultxField;

    private bool defaultxFieldSpecified;

    private decimal defaultyField;

    private bool defaultyFieldSpecified;

    private decimal relativexField;

    private bool relativexFieldSpecified;

    private decimal relativeyField;

    private bool relativeyFieldSpecified;

    private abovebelow placementField;

    private bool placementFieldSpecified;


    [System.Xml.Serialization.XmlElementAttribute("tuplet-actual")]
    public tupletportion tupletactual
    {
        get
        {
            return this.tupletactualField;
        }
        set
        {
            this.tupletactualField = value;
        }
    }


    [System.Xml.Serialization.XmlElementAttribute("tuplet-normal")]
    public tupletportion tupletnormal
    {
        get
        {
            return this.tupletnormalField;
        }
        set
        {
            this.tupletnormalField = value;
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


    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "positiveInteger")]
    public string number
    {
        get
        {
            return this.numberField;
        }
        set
        {
            this.numberField = value;
        }
    }


    [System.Xml.Serialization.XmlAttributeAttribute()]
    public yesno bracket
    {
        get
        {
            return this.bracketField;
        }
        set
        {
            this.bracketField = value;
        }
    }


    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool bracketSpecified
    {
        get
        {
            return this.bracketFieldSpecified;
        }
        set
        {
            this.bracketFieldSpecified = value;
        }
    }


    [System.Xml.Serialization.XmlAttributeAttribute("show-number")]
    public showtuplet shownumber
    {
        get
        {
            return this.shownumberField;
        }
        set
        {
            this.shownumberField = value;
        }
    }


    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool shownumberSpecified
    {
        get
        {
            return this.shownumberFieldSpecified;
        }
        set
        {
            this.shownumberFieldSpecified = value;
        }
    }


    [System.Xml.Serialization.XmlAttributeAttribute("show-type")]
    public showtuplet showtype
    {
        get
        {
            return this.showtypeField;
        }
        set
        {
            this.showtypeField = value;
        }
    }


    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool showtypeSpecified
    {
        get
        {
            return this.showtypeFieldSpecified;
        }
        set
        {
            this.showtypeFieldSpecified = value;
        }
    }


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


    [System.Xml.Serialization.XmlAttributeAttribute("default-x")]
    public decimal defaultx
    {
        get
        {
            return this.defaultxField;
        }
        set
        {
            this.defaultxField = value;
        }
    }


    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool defaultxSpecified
    {
        get
        {
            return this.defaultxFieldSpecified;
        }
        set
        {
            this.defaultxFieldSpecified = value;
        }
    }


    [System.Xml.Serialization.XmlAttributeAttribute("default-y")]
    public decimal defaulty
    {
        get
        {
            return this.defaultyField;
        }
        set
        {
            this.defaultyField = value;
        }
    }


    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool defaultySpecified
    {
        get
        {
            return this.defaultyFieldSpecified;
        }
        set
        {
            this.defaultyFieldSpecified = value;
        }
    }


    [System.Xml.Serialization.XmlAttributeAttribute("relative-x")]
    public decimal relativex
    {
        get
        {
            return this.relativexField;
        }
        set
        {
            this.relativexField = value;
        }
    }


    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool relativexSpecified
    {
        get
        {
            return this.relativexFieldSpecified;
        }
        set
        {
            this.relativexFieldSpecified = value;
        }
    }


    [System.Xml.Serialization.XmlAttributeAttribute("relative-y")]
    public decimal relativey
    {
        get
        {
            return this.relativeyField;
        }
        set
        {
            this.relativeyField = value;
        }
    }


    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool relativeySpecified
    {
        get
        {
            return this.relativeyFieldSpecified;
        }
        set
        {
            this.relativeyFieldSpecified = value;
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