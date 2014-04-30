[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(TypeName = "part-group")]
public partial class partgroup
{

    private groupname groupnameField;

    private namedisplay groupnamedisplayField;

    private groupname groupabbreviationField;

    private namedisplay groupabbreviationdisplayField;

    private groupsymbol groupsymbolField;

    private groupbarline groupbarlineField;

    private empty grouptimeField;

    private formattedtext footnoteField;

    private level levelField;

    private startstop typeField;

    private string numberField;

    public partgroup()
    {
        this.numberField = "1";
    }


    [System.Xml.Serialization.XmlElementAttribute("group-name")]
    public groupname groupname
    {
        get
        {
            return this.groupnameField;
        }
        set
        {
            this.groupnameField = value;
        }
    }


    [System.Xml.Serialization.XmlElementAttribute("group-name-display")]
    public namedisplay groupnamedisplay
    {
        get
        {
            return this.groupnamedisplayField;
        }
        set
        {
            this.groupnamedisplayField = value;
        }
    }


    [System.Xml.Serialization.XmlElementAttribute("group-abbreviation")]
    public groupname groupabbreviation
    {
        get
        {
            return this.groupabbreviationField;
        }
        set
        {
            this.groupabbreviationField = value;
        }
    }


    [System.Xml.Serialization.XmlElementAttribute("group-abbreviation-display")]
    public namedisplay groupabbreviationdisplay
    {
        get
        {
            return this.groupabbreviationdisplayField;
        }
        set
        {
            this.groupabbreviationdisplayField = value;
        }
    }


    [System.Xml.Serialization.XmlElementAttribute("group-symbol")]
    public groupsymbol groupsymbol
    {
        get
        {
            return this.groupsymbolField;
        }
        set
        {
            this.groupsymbolField = value;
        }
    }


    [System.Xml.Serialization.XmlElementAttribute("group-barline")]
    public groupbarline groupbarline
    {
        get
        {
            return this.groupbarlineField;
        }
        set
        {
            this.groupbarlineField = value;
        }
    }


    [System.Xml.Serialization.XmlElementAttribute("group-time")]
    public empty grouptime
    {
        get
        {
            return this.grouptimeField;
        }
        set
        {
            this.grouptimeField = value;
        }
    }


    public formattedtext footnote
    {
        get
        {
            return this.footnoteField;
        }
        set
        {
            this.footnoteField = value;
        }
    }


    public level level
    {
        get
        {
            return this.levelField;
        }
        set
        {
            this.levelField = value;
        }
    }


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


    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "token")]
    [System.ComponentModel.DefaultValueAttribute("1")]
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