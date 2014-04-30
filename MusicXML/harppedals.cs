[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(TypeName = "harp-pedals")]
public partial class harppedals
{

    private pedaltuning[] pedaltuningField;


    [System.Xml.Serialization.XmlElementAttribute("pedal-tuning")]
    public pedaltuning[] pedaltuning
    {
        get
        {
            return this.pedaltuningField;
        }
        set
        {
            this.pedaltuningField = value;
        }
    }
}