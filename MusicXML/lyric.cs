[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class lyric
{

    private object[] itemsField;

    private ItemsChoiceType6[] itemsElementNameField;

    private empty endlineField;

    private empty endparagraphField;

    private formattedtext footnoteField;

    private level levelField;

    private string numberField;

    private string nameField;

    private leftcenterright justifyField;

    private bool justifyFieldSpecified;

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

    private string colorField;

    private yesno printobjectField;

    private bool printobjectFieldSpecified;


    [System.Xml.Serialization.XmlElementAttribute("elision", typeof(textfontcolor))]
    [System.Xml.Serialization.XmlElementAttribute("extend", typeof(extend))]
    [System.Xml.Serialization.XmlElementAttribute("humming", typeof(empty))]
    [System.Xml.Serialization.XmlElementAttribute("laughing", typeof(empty))]
    [System.Xml.Serialization.XmlElementAttribute("syllabic", typeof(syllabic))]
    [System.Xml.Serialization.XmlElementAttribute("text", typeof(textelementdata))]
    [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
    public object[] Items
    {
        get
        {
            return this.itemsField;
        }
        set
        {
            this.itemsField = value;
        }
    }


    [System.Xml.Serialization.XmlElementAttribute("ItemsElementName")]
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public ItemsChoiceType6[] ItemsElementName
    {
        get
        {
            return this.itemsElementNameField;
        }
        set
        {
            this.itemsElementNameField = value;
        }
    }


    [System.Xml.Serialization.XmlElementAttribute("end-line")]
    public empty endline
    {
        get
        {
            return this.endlineField;
        }
        set
        {
            this.endlineField = value;
        }
    }


    [System.Xml.Serialization.XmlElementAttribute("end-paragraph")]
    public empty endparagraph
    {
        get
        {
            return this.endparagraphField;
        }
        set
        {
            this.endparagraphField = value;
        }
    }


    public formattedtext footnote
    {
        get
        {
            return this.footnoteField;
        }
        set
        {
            this.footnoteField = value;
        }
    }


    public level level
    {
        get
        {
            return this.levelField;
        }
        set
        {
            this.levelField = value;
        }
    }


    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NMTOKEN")]
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


    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "token")]
    public string name
    {
        get
        {
            return this.nameField;
        }
        set
        {
            this.nameField = value;
        }
    }


    [System.Xml.Serialization.XmlAttributeAttribute()]
    public leftcenterright justify
    {
        get
        {
            return this.justifyField;
        }
        set
        {
            this.justifyField = value;
        }
    }


    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool justifySpecified
    {
        get
        {
            return this.justifyFieldSpecified;
        }
        set
        {
            this.justifyFieldSpecified = value;
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


    [System.Xml.Serialization.XmlAttributeAttribute("print-object")]
    public yesno printobject
    {
        get
        {
            return this.printobjectField;
        }
        set
        {
            this.printobjectField = value;
        }
    }


    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool printobjectSpecified
    {
        get
        {
            return this.printobjectFieldSpecified;
        }
        set
        {
            this.printobjectFieldSpecified = value;
        }
    }
}