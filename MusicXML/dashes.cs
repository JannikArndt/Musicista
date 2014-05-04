[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class dashes
{

    private startstopcontinue typeField;

    private string numberField;

    private decimal dashlengthField;

    private bool dashlengthFieldSpecified;

    private decimal spacelengthField;

    private bool spacelengthFieldSpecified;

    private decimal defaultxField;

    private bool defaultxFieldSpecified;

    private decimal defaultyField;

    private bool defaultyFieldSpecified;

    private decimal relativexField;

    private bool relativexFieldSpecified;

    private decimal relativeyField;

    private bool relativeyFieldSpecified;

    private string colorField;


    [System.Xml.Serialization.XmlAttributeAttribute()]
    public startstopcontinue type
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
}