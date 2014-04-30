[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(TypeName = "score-instrument")]
public partial class scoreinstrument
{

    private string instrumentnameField;

    private string instrumentabbreviationField;

    private string instrumentsoundField;

    private object itemField;

    private virtualinstrument virtualinstrumentField;

    private string idField;


    [System.Xml.Serialization.XmlElementAttribute("instrument-name")]
    public string instrumentname
    {
        get
        {
            return this.instrumentnameField;
        }
        set
        {
            this.instrumentnameField = value;
        }
    }


    [System.Xml.Serialization.XmlElementAttribute("instrument-abbreviation")]
    public string instrumentabbreviation
    {
        get
        {
            return this.instrumentabbreviationField;
        }
        set
        {
            this.instrumentabbreviationField = value;
        }
    }


    [System.Xml.Serialization.XmlElementAttribute("instrument-sound")]
    public string instrumentsound
    {
        get
        {
            return this.instrumentsoundField;
        }
        set
        {
            this.instrumentsoundField = value;
        }
    }


    [System.Xml.Serialization.XmlElementAttribute("ensemble", typeof(string))]
    [System.Xml.Serialization.XmlElementAttribute("solo", typeof(empty))]
    public object Item
    {
        get
        {
            return this.itemField;
        }
        set
        {
            this.itemField = value;
        }
    }


    [System.Xml.Serialization.XmlElementAttribute("virtual-instrument")]
    public virtualinstrument virtualinstrument
    {
        get
        {
            return this.virtualinstrumentField;
        }
        set
        {
            this.virtualinstrumentField = value;
        }
    }


    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "ID")]
    public string id
    {
        get
        {
            return this.idField;
        }
        set
        {
            this.idField = value;
        }
    }
}