[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(TypeName = "heel-toe")]
public partial class heeltoe : emptyplacement
{

    private yesno substitutionField;

    private bool substitutionFieldSpecified;


    [System.Xml.Serialization.XmlAttributeAttribute()]
    public yesno substitution
    {
        get
        {
            return this.substitutionField;
        }
        set
        {
            this.substitutionField = value;
        }
    }


    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool substitutionSpecified
    {
        get
        {
            return this.substitutionFieldSpecified;
        }
        set
        {
            this.substitutionFieldSpecified = value;
        }
    }
}