[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class unpitched
{

    private step displaystepField;

    private string displayoctaveField;


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
}