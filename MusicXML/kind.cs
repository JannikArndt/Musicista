[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class kind
{

    private yesno usesymbolsField;

    private bool usesymbolsFieldSpecified;

    private string textField;

    private yesno stackdegreesField;

    private bool stackdegreesFieldSpecified;

    private yesno parenthesesdegreesField;

    private bool parenthesesdegreesFieldSpecified;

    private yesno bracketdegreesField;

    private bool bracketdegreesFieldSpecified;

    private leftcenterright halignField;

    private bool halignFieldSpecified;

    private valign valignField;

    private bool valignFieldSpecified;

    private kindvalue valueField;


    [System.Xml.Serialization.XmlAttributeAttribute("use-symbols")]
    public yesno usesymbols
    {
        get
        {
            return this.usesymbolsField;
        }
        set
        {
            this.usesymbolsField = value;
        }
    }


    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool usesymbolsSpecified
    {
        get
        {
            return this.usesymbolsFieldSpecified;
        }
        set
        {
            this.usesymbolsFieldSpecified = value;
        }
    }


    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "token")]
    public string text
    {
        get
        {
            return this.textField;
        }
        set
        {
            this.textField = value;
        }
    }


    [System.Xml.Serialization.XmlAttributeAttribute("stack-degrees")]
    public yesno stackdegrees
    {
        get
        {
            return this.stackdegreesField;
        }
        set
        {
            this.stackdegreesField = value;
        }
    }


    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool stackdegreesSpecified
    {
        get
        {
            return this.stackdegreesFieldSpecified;
        }
        set
        {
            this.stackdegreesFieldSpecified = value;
        }
    }


    [System.Xml.Serialization.XmlAttributeAttribute("parentheses-degrees")]
    public yesno parenthesesdegrees
    {
        get
        {
            return this.parenthesesdegreesField;
        }
        set
        {
            this.parenthesesdegreesField = value;
        }
    }


    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool parenthesesdegreesSpecified
    {
        get
        {
            return this.parenthesesdegreesFieldSpecified;
        }
        set
        {
            this.parenthesesdegreesFieldSpecified = value;
        }
    }


    [System.Xml.Serialization.XmlAttributeAttribute("bracket-degrees")]
    public yesno bracketdegrees
    {
        get
        {
            return this.bracketdegreesField;
        }
        set
        {
            this.bracketdegreesField = value;
        }
    }


    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool bracketdegreesSpecified
    {
        get
        {
            return this.bracketdegreesFieldSpecified;
        }
        set
        {
            this.bracketdegreesFieldSpecified = value;
        }
    }


    [System.Xml.Serialization.XmlAttributeAttribute()]
    public leftcenterright halign
    {
        get
        {
            return this.halignField;
        }
        set
        {
            this.halignField = value;
        }
    }


    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool halignSpecified
    {
        get
        {
            return this.halignFieldSpecified;
        }
        set
        {
            this.halignFieldSpecified = value;
        }
    }


    [System.Xml.Serialization.XmlAttributeAttribute()]
    public valign valign
    {
        get
        {
            return this.valignField;
        }
        set
        {
            this.valignField = value;
        }
    }


    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool valignSpecified
    {
        get
        {
            return this.valignFieldSpecified;
        }
        set
        {
            this.valignFieldSpecified = value;
        }
    }


    [System.Xml.Serialization.XmlTextAttribute()]
    public kindvalue Value
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