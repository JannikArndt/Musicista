[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class identification
{

    private typedtext[] creatorField;

    private typedtext[] rightsField;

    private encoding encodingField;

    private string sourceField;

    private typedtext[] relationField;

    private miscellaneousfield[] miscellaneousField;


    [System.Xml.Serialization.XmlElementAttribute("creator")]
    public typedtext[] creator
    {
        get
        {
            return this.creatorField;
        }
        set
        {
            this.creatorField = value;
        }
    }


    [System.Xml.Serialization.XmlElementAttribute("rights")]
    public typedtext[] rights
    {
        get
        {
            return this.rightsField;
        }
        set
        {
            this.rightsField = value;
        }
    }


    public encoding encoding
    {
        get
        {
            return this.encodingField;
        }
        set
        {
            this.encodingField = value;
        }
    }


    public string source
    {
        get
        {
            return this.sourceField;
        }
        set
        {
            this.sourceField = value;
        }
    }


    [System.Xml.Serialization.XmlElementAttribute("relation")]
    public typedtext[] relation
    {
        get
        {
            return this.relationField;
        }
        set
        {
            this.relationField = value;
        }
    }


    [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable = false)]
    public miscellaneousfield[] miscellaneous
    {
        get
        {
            return this.miscellaneousField;
        }
        set
        {
            this.miscellaneousField = value;
        }
    }
}