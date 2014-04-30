[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tie
{

    private startstop typeField;

    private string timeonlyField;


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


    [System.Xml.Serialization.XmlAttributeAttribute("time-only", DataType = "token")]
    public string timeonly
    {
        get
        {
            return this.timeonlyField;
        }
        set
        {
            this.timeonlyField = value;
        }
    }
}