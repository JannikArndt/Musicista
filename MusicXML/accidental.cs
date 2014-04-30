[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class accidental
{

    private yesno cautionaryField;

    private bool cautionaryFieldSpecified;

    private yesno editorialField;

    private bool editorialFieldSpecified;

    private yesno parenthesesField;

    private bool parenthesesFieldSpecified;

    private yesno bracketField;

    private bool bracketFieldSpecified;

    private symbolsize sizeField;

    private bool sizeFieldSpecified;

    private accidentalvalue valueField;


    [System.Xml.Serialization.XmlAttributeAttribute()]
    public yesno cautionary
    {
        get
        {
            return this.cautionaryField;
        }
        set
        {
            this.cautionaryField = value;
        }
    }


    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool cautionarySpecified
    {
        get
        {
            return this.cautionaryFieldSpecified;
        }
        set
        {
            this.cautionaryFieldSpecified = value;
        }
    }


    [System.Xml.Serialization.XmlAttributeAttribute()]
    public yesno editorial
    {
        get
        {
            return this.editorialField;
        }
        set
        {
            this.editorialField = value;
        }
    }


    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool editorialSpecified
    {
        get
        {
            return this.editorialFieldSpecified;
        }
        set
        {
            this.editorialFieldSpecified = value;
        }
    }


    [System.Xml.Serialization.XmlAttributeAttribute()]
    public yesno parentheses
    {
        get
        {
            return this.parenthesesField;
        }
        set
        {
            this.parenthesesField = value;
        }
    }


    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool parenthesesSpecified
    {
        get
        {
            return this.parenthesesFieldSpecified;
        }
        set
        {
            this.parenthesesFieldSpecified = value;
        }
    }


    [System.Xml.Serialization.XmlAttributeAttribute()]
    public yesno bracket
    {
        get
        {
            return this.bracketField;
        }
        set
        {
            this.bracketField = value;
        }
    }


    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool bracketSpecified
    {
        get
        {
            return this.bracketFieldSpecified;
        }
        set
        {
            this.bracketFieldSpecified = value;
        }
    }


    [System.Xml.Serialization.XmlAttributeAttribute()]
    public symbolsize size
    {
        get
        {
            return this.sizeField;
        }
        set
        {
            this.sizeField = value;
        }
    }


    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool sizeSpecified
    {
        get
        {
            return this.sizeFieldSpecified;
        }
        set
        {
            this.sizeFieldSpecified = value;
        }
    }


    [System.Xml.Serialization.XmlTextAttribute()]
    public accidentalvalue Value
    {
        get
        {
            return this.valueField;
        }
        set
        {
            this.valueField = value;
        }
    }
}