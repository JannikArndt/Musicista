[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(TypeName = "score-part")]
public partial class scorepart
{

    private identification identificationField;

    private partname partnameField;

    private namedisplay partnamedisplayField;

    private partname partabbreviationField;

    private namedisplay partabbreviationdisplayField;

    private string[] groupField;

    private scoreinstrument[] scoreinstrumentField;

    private mididevice[] midideviceField;

    private midiinstrument[] midiinstrumentField;

    private string idField;


    public identification identification
    {
        get
        {
            return this.identificationField;
        }
        set
        {
            this.identificationField = value;
        }
    }


    [System.Xml.Serialization.XmlElementAttribute("part-name")]
    public partname partname
    {
        get
        {
            return this.partnameField;
        }
        set
        {
            this.partnameField = value;
        }
    }


    [System.Xml.Serialization.XmlElementAttribute("part-name-display")]
    public namedisplay partnamedisplay
    {
        get
        {
            return this.partnamedisplayField;
        }
        set
        {
            this.partnamedisplayField = value;
        }
    }


    [System.Xml.Serialization.XmlElementAttribute("part-abbreviation")]
    public partname partabbreviation
    {
        get
        {
            return this.partabbreviationField;
        }
        set
        {
            this.partabbreviationField = value;
        }
    }


    [System.Xml.Serialization.XmlElementAttribute("part-abbreviation-display")]
    public namedisplay partabbreviationdisplay
    {
        get
        {
            return this.partabbreviationdisplayField;
        }
        set
        {
            this.partabbreviationdisplayField = value;
        }
    }


    [System.Xml.Serialization.XmlElementAttribute("group")]
    public string[] group
    {
        get
        {
            return this.groupField;
        }
        set
        {
            this.groupField = value;
        }
    }


    [System.Xml.Serialization.XmlElementAttribute("score-instrument")]
    public scoreinstrument[] scoreinstrument
    {
        get
        {
            return this.scoreinstrumentField;
        }
        set
        {
            this.scoreinstrumentField = value;
        }
    }


    [System.Xml.Serialization.XmlElementAttribute("midi-device")]
    public mididevice[] mididevice
    {
        get
        {
            return this.midideviceField;
        }
        set
        {
            this.midideviceField = value;
        }
    }


    [System.Xml.Serialization.XmlElementAttribute("midi-instrument")]
    public midiinstrument[] midiinstrument
    {
        get
        {
            return this.midiinstrumentField;
        }
        set
        {
            this.midiinstrumentField = value;
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