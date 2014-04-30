[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class rest
{

    private step displaystepField;

    private string displayoctaveField;

    private yesno measureField;

    private bool measureFieldSpecified;


    [System.Xml.Serialization.XmlElementAttribute("display-step")]
    public step displaystep
    {
        get
        {
            return this.displaystepField;
        }
        set
        {
            this.displaystepField = value;
        }
    }


    [System.Xml.Serialization.XmlElementAttribute("display-octave", DataType = "integer")]
    public string displayoctave
    {
        get
        {
            return this.displayoctaveField;
        }
        set
        {
            this.displayoctaveField = value;
        }
    }


    [System.Xml.Serialization.XmlAttributeAttribute()]
    public yesno measure
    {
        get
        {
            return this.measureField;
        }
        set
        {
            this.measureField = value;
        }
    }


    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool measureSpecified
    {
        get
        {
            return this.measureFieldSpecified;
        }
        set
        {
            this.measureFieldSpecified = value;
        }
    }
}