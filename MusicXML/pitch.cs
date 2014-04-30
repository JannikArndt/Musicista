[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class pitch
{

    private step stepField;

    private decimal alterField;

    private bool alterFieldSpecified;

    private string octaveField;


    public step step
    {
        get
        {
            return this.stepField;
        }
        set
        {
            this.stepField = value;
        }
    }


    public decimal alter
    {
        get
        {
            return this.alterField;
        }
        set
        {
            this.alterField = value;
        }
    }


    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool alterSpecified
    {
        get
        {
            return this.alterFieldSpecified;
        }
        set
        {
            this.alterFieldSpecified = value;
        }
    }


    [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
    public string octave
    {
        get
        {
            return this.octaveField;
        }
        set
        {
            this.octaveField = value;
        }
    }
}