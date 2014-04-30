[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class degree
{

    private degreevalue degreevalueField;

    private degreealter degreealterField;

    private degreetype degreetypeField;

    private yesno printobjectField;

    private bool printobjectFieldSpecified;


    [System.Xml.Serialization.XmlElementAttribute("degree-value")]
    public degreevalue degreevalue
    {
        get
        {
            return this.degreevalueField;
        }
        set
        {
            this.degreevalueField = value;
        }
    }


    [System.Xml.Serialization.XmlElementAttribute("degree-alter")]
    public degreealter degreealter
    {
        get
        {
            return this.degreealterField;
        }
        set
        {
            this.degreealterField = value;
        }
    }


    [System.Xml.Serialization.XmlElementAttribute("degree-type")]
    public degreetype degreetype
    {
        get
        {
            return this.degreetypeField;
        }
        set
        {
            this.degreetypeField = value;
        }
    }


    [System.Xml.Serialization.XmlAttributeAttribute("print-object")]
    public yesno printobject
    {
        get
        {
            return this.printobjectField;
        }
        set
        {
            this.printobjectField = value;
        }
    }


    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool printobjectSpecified
    {
        get
        {
            return this.printobjectFieldSpecified;
        }
        set
        {
            this.printobjectFieldSpecified = value;
        }
    }
}