[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class scoretimewiseMeasure
{

    private scoretimewiseMeasurePart[] partField;

    private string numberField;

    private yesno implicitField;

    private bool implicitFieldSpecified;

    private yesno noncontrollingField;

    private bool noncontrollingFieldSpecified;

    private decimal widthField;

    private bool widthFieldSpecified;


    [System.Xml.Serialization.XmlElementAttribute("part")]
    public scoretimewiseMeasurePart[] part
    {
        get
        {
            return this.partField;
        }
        set
        {
            this.partField = value;
        }
    }


    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "token")]
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
    public yesno @implicit
    {
        get
        {
            return this.implicitField;
        }
        set
        {
            this.implicitField = value;
        }
    }


    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool implicitSpecified
    {
        get
        {
            return this.implicitFieldSpecified;
        }
        set
        {
            this.implicitFieldSpecified = value;
        }
    }


    [System.Xml.Serialization.XmlAttributeAttribute("non-controlling")]
    public yesno noncontrolling
    {
        get
        {
            return this.noncontrollingField;
        }
        set
        {
            this.noncontrollingField = value;
        }
    }


    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool noncontrollingSpecified
    {
        get
        {
            return this.noncontrollingFieldSpecified;
        }
        set
        {
            this.noncontrollingFieldSpecified = value;
        }
    }


    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal width
    {
        get
        {
            return this.widthField;
        }
        set
        {
            this.widthField = value;
        }
    }


    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool widthSpecified
    {
        get
        {
            return this.widthFieldSpecified;
        }
        set
        {
            this.widthFieldSpecified = value;
        }
    }
}