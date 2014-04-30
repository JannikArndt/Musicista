[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(TypeName = "staff-layout")]
public partial class stafflayout
{

    private decimal staffdistanceField;

    private bool staffdistanceFieldSpecified;

    private string numberField;


    [System.Xml.Serialization.XmlElementAttribute("staff-distance")]
    public decimal staffdistance
    {
        get
        {
            return this.staffdistanceField;
        }
        set
        {
            this.staffdistanceField = value;
        }
    }


    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool staffdistanceSpecified
    {
        get
        {
            return this.staffdistanceFieldSpecified;
        }
        set
        {
            this.staffdistanceFieldSpecified = value;
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