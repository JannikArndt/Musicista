[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(TypeName = "tuplet-portion")]
public partial class tupletportion
{

    private tupletnumber tupletnumberField;

    private tuplettype tuplettypeField;

    private tupletdot[] tupletdotField;


    [System.Xml.Serialization.XmlElementAttribute("tuplet-number")]
    public tupletnumber tupletnumber
    {
        get
        {
            return this.tupletnumberField;
        }
        set
        {
            this.tupletnumberField = value;
        }
    }


    [System.Xml.Serialization.XmlElementAttribute("tuplet-type")]
    public tuplettype tuplettype
    {
        get
        {
            return this.tuplettypeField;
        }
        set
        {
            this.tuplettypeField = value;
        }
    }


    [System.Xml.Serialization.XmlElementAttribute("tuplet-dot")]
    public tupletdot[] tupletdot
    {
        get
        {
            return this.tupletdotField;
        }
        set
        {
            this.tupletdotField = value;
        }
    }
}