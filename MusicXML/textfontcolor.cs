[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(TypeName = "text-font-color")]
public partial class textfontcolor
{

    private string fontfamilyField;

    private fontstyle fontstyleField;

    private bool fontstyleFieldSpecified;

    private string fontsizeField;

    private fontweight fontweightField;

    private bool fontweightFieldSpecified;

    private string colorField;

    private string underlineField;

    private string overlineField;

    private string linethroughField;

    private decimal rotationField;

    private bool rotationFieldSpecified;

    private string letterspacingField;

    private string langField;

    private textdirection dirField;

    private bool dirFieldSpecified;

    private string valueField;


    [System.Xml.Serialization.XmlAttributeAttribute("font-family", DataType = "token")]
    public string fontfamily
    {
        get
        {
            return this.fontfamilyField;
        }
        set
        {
            this.fontfamilyField = value;
        }
    }


    [System.Xml.Serialization.XmlAttributeAttribute("font-style")]
    public fontstyle fontstyle
    {
        get
        {
            return this.fontstyleField;
        }
        set
        {
            this.fontstyleField = value;
        }
    }


    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool fontstyleSpecified
    {
        get
        {
            return this.fontstyleFieldSpecified;
        }
        set
        {
            this.fontstyleFieldSpecified = value;
        }
    }


    [System.Xml.Serialization.XmlAttributeAttribute("font-size")]
    public string fontsize
    {
        get
        {
            return this.fontsizeField;
        }
        set
        {
            this.fontsizeField = value;
        }
    }


    [System.Xml.Serialization.XmlAttributeAttribute("font-weight")]
    public fontweight fontweight
    {
        get
        {
            return this.fontweightField;
        }
        set
        {
            this.fontweightField = value;
        }
    }


    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool fontweightSpecified
    {
        get
        {
            return this.fontweightFieldSpecified;
        }
        set
        {
            this.fontweightFieldSpecified = value;
        }
    }


    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "token")]
    public string color
    {
        get
        {
            return this.colorField;
        }
        set
        {
            this.colorField = value;
        }
    }


    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "nonNegativeInteger")]
    public string underline
    {
        get
        {
            return this.underlineField;
        }
        set
        {
            this.underlineField = value;
        }
    }


    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "nonNegativeInteger")]
    public string overline
    {
        get
        {
            return this.overlineField;
        }
        set
        {
            this.overlineField = value;
        }
    }


    [System.Xml.Serialization.XmlAttributeAttribute("line-through", DataType = "nonNegativeInteger")]
    public string linethrough
    {
        get
        {
            return this.linethroughField;
        }
        set
        {
            this.linethroughField = value;
        }
    }


    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal rotation
    {
        get
        {
            return this.rotationField;
        }
        set
        {
            this.rotationField = value;
        }
    }


    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool rotationSpecified
    {
        get
        {
            return this.rotationFieldSpecified;
        }
        set
        {
            this.rotationFieldSpecified = value;
        }
    }


    [System.Xml.Serialization.XmlAttributeAttribute("letter-spacing")]
    public string letterspacing
    {
        get
        {
            return this.letterspacingField;
        }
        set
        {
            this.letterspacingField = value;
        }
    }


    [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
    public string lang
    {
        get
        {
            return this.langField;
        }
        set
        {
            this.langField = value;
        }
    }


    [System.Xml.Serialization.XmlAttributeAttribute()]
    public textdirection dir
    {
        get
        {
            return this.dirField;
        }
        set
        {
            this.dirField = value;
        }
    }


    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool dirSpecified
    {
        get
        {
            return this.dirFieldSpecified;
        }
        set
        {
            this.dirFieldSpecified = value;
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