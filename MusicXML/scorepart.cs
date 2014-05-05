using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[GeneratedCode("xsd", "4.0.30319.33440")]
[Serializable]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(TypeName = "score-part")]
public class scorepart
{
    private string[] groupField;
    private string idField;
    private identification identificationField;
    private mididevice[] midideviceField;

    private midiinstrument[] midiinstrumentField;

    private partname partabbreviationField;

    private namedisplay partabbreviationdisplayField;
    private partname partnameField;

    private namedisplay partnamedisplayField;

    private scoreinstrument[] scoreinstrumentField;


    public identification identification
    {
        get { return identificationField; }
        set { identificationField = value; }
    }


    [XmlElement("part-name")]
    public partname partname
    {
        get { return partnameField; }
        set { partnameField = value; }
    }


    [XmlElement("part-name-display")]
    public namedisplay partnamedisplay
    {
        get { return partnamedisplayField; }
        set { partnamedisplayField = value; }
    }


    [XmlElement("part-abbreviation")]
    public partname partabbreviation
    {
        get { return partabbreviationField; }
        set { partabbreviationField = value; }
    }


    [XmlElement("part-abbreviation-display")]
    public namedisplay partabbreviationdisplay
    {
        get { return partabbreviationdisplayField; }
        set { partabbreviationdisplayField = value; }
    }


    [XmlElement("group")]
    public string[] group
    {
        get { return groupField; }
        set { groupField = value; }
    }


    [XmlElement("score-instrument")]
    public scoreinstrument[] scoreinstrument
    {
        get { return scoreinstrumentField; }
        set { scoreinstrumentField = value; }
    }


    [XmlElement("midi-device")]
    public mididevice[] mididevice
    {
        get { return midideviceField; }
        set { midideviceField = value; }
    }


    [XmlElement("midi-instrument")]
    public midiinstrument[] midiinstrument
    {
        get { return midiinstrumentField; }
        set { midiinstrumentField = value; }
    }


    [XmlAttribute(DataType = "ID")]
    public string id
    {
        get { return idField; }
        set { idField = value; }
    }
}