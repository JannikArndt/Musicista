[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(TypeName = "midi-instrument")]
public partial class midiinstrument
{

    private string midichannelField;

    private string midinameField;

    private string midibankField;

    private string midiprogramField;

    private string midiunpitchedField;

    private decimal volumeField;

    private bool volumeFieldSpecified;

    private decimal panField;

    private bool panFieldSpecified;

    private decimal elevationField;

    private bool elevationFieldSpecified;

    private string idField;


    [System.Xml.Serialization.XmlElementAttribute("midi-channel", DataType = "positiveInteger")]
    public string midichannel
    {
        get
        {
            return this.midichannelField;
        }
        set
        {
            this.midichannelField = value;
        }
    }


    [System.Xml.Serialization.XmlElementAttribute("midi-name")]
    public string midiname
    {
        get
        {
            return this.midinameField;
        }
        set
        {
            this.midinameField = value;
        }
    }


    [System.Xml.Serialization.XmlElementAttribute("midi-bank", DataType = "positiveInteger")]
    public string midibank
    {
        get
        {
            return this.midibankField;
        }
        set
        {
            this.midibankField = value;
        }
    }


    [System.Xml.Serialization.XmlElementAttribute("midi-program", DataType = "positiveInteger")]
    public string midiprogram
    {
        get
        {
            return this.midiprogramField;
        }
        set
        {
            this.midiprogramField = value;
        }
    }


    [System.Xml.Serialization.XmlElementAttribute("midi-unpitched", DataType = "positiveInteger")]
    public string midiunpitched
    {
        get
        {
            return this.midiunpitchedField;
        }
        set
        {
            this.midiunpitchedField = value;
        }
    }


    public decimal volume
    {
        get
        {
            return this.volumeField;
        }
        set
        {
            this.volumeField = value;
        }
    }


    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool volumeSpecified
    {
        get
        {
            return this.volumeFieldSpecified;
        }
        set
        {
            this.volumeFieldSpecified = value;
        }
    }


    public decimal pan
    {
        get
        {
            return this.panField;
        }
        set
        {
            this.panField = value;
        }
    }


    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool panSpecified
    {
        get
        {
            return this.panFieldSpecified;
        }
        set
        {
            this.panFieldSpecified = value;
        }
    }


    public decimal elevation
    {
        get
        {
            return this.elevationField;
        }
        set
        {
            this.elevationField = value;
        }
    }


    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool elevationSpecified
    {
        get
        {
            return this.elevationFieldSpecified;
        }
        set
        {
            this.elevationFieldSpecified = value;
        }
    }


    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "IDREF")]
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