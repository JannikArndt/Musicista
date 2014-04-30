[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class transpose
{

    private string diatonicField;

    private decimal chromaticField;

    private string octavechangeField;

    private empty doubleField;

    private string numberField;


    [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
    public string diatonic
    {
        get
        {
            return this.diatonicField;
        }
        set
        {
            this.diatonicField = value;
        }
    }


    public decimal chromatic
    {
        get
        {
            return this.chromaticField;
        }
        set
        {
            this.chromaticField = value;
        }
    }


    [System.Xml.Serialization.XmlElementAttribute("octave-change", DataType = "integer")]
    public string octavechange
    {
        get
        {
            return this.octavechangeField;
        }
        set
        {
            this.octavechangeField = value;
        }
    }


    public empty @double
    {
        get
        {
            return this.doubleField;
        }
        set
        {
            this.doubleField = value;
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
}