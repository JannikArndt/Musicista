using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[GeneratedCode("xsd", "4.0.30319.33440")]
[Serializable]
[DebuggerStepThrough]
[DesignerCategory("code")]
public class note
{
    private accidental accidentalField;
    private decimal attackField;

    private bool attackFieldSpecified;

    private beam[] beamField;
    private string colorField;

    private decimal defaultxField;

    private bool defaultxFieldSpecified;

    private decimal defaultyField;

    private bool defaultyFieldSpecified;
    private emptyplacement[] dotField;
    private decimal dynamicsField;

    private bool dynamicsFieldSpecified;

    private decimal enddynamicsField;

    private bool enddynamicsFieldSpecified;

    private string fontfamilyField;
    private string fontsizeField;

    private fontstyle fontstyleField;

    private bool fontstyleFieldSpecified;

    private fontweight fontweightField;

    private bool fontweightFieldSpecified;
    private formattedtext footnoteField;
    private instrument instrumentField;
    private ItemsChoiceType1[] itemsElementNameField;
    private object[] itemsField;
    private level levelField;
    private lyric[] lyricField;
    private notations[] notationsField;
    private notehead noteheadField;

    private noteheadtext noteheadtextField;
    private yesno pizzicatoField;

    private bool pizzicatoFieldSpecified;
    private play playField;

    private yesno printdotField;

    private bool printdotFieldSpecified;

    private yesno printlyricField;

    private bool printlyricFieldSpecified;
    private decimal relativexField;

    private bool relativexFieldSpecified;

    private decimal relativeyField;

    private bool relativeyFieldSpecified;

    private decimal releaseField;

    private bool releaseFieldSpecified;
    private string staffField;
    private stem stemField;
    private timemodification timemodificationField;

    private string timeonlyField;
    private notetype typeField;
    private string voiceField;


    [XmlElement("chord", typeof(empty))]
    [XmlElement("cue", typeof(empty))]
    [XmlElement("duration", typeof(decimal))]
    [XmlElement("grace", typeof(grace))]
    [XmlElement("pitch", typeof(pitch))]
    [XmlElement("rest", typeof(rest))]
    [XmlElement("tie", typeof(tie))]
    [XmlElement("unpitched", typeof(unpitched))]
    [XmlChoiceIdentifier("ItemsElementName")]
    public object[] Items
    {
        get { return itemsField; }
        set { itemsField = value; }
    }


    [XmlElement("ItemsElementName")]
    [XmlIgnore]
    public ItemsChoiceType1[] ItemsElementName
    {
        get { return itemsElementNameField; }
        set { itemsElementNameField = value; }
    }


    public instrument instrument
    {
        get { return instrumentField; }
        set { instrumentField = value; }
    }


    public formattedtext footnote
    {
        get { return footnoteField; }
        set { footnoteField = value; }
    }


    public level level
    {
        get { return levelField; }
        set { levelField = value; }
    }


    public string voice
    {
        get { return voiceField; }
        set { voiceField = value; }
    }


    public notetype type
    {
        get { return typeField; }
        set { typeField = value; }
    }


    [XmlElement("dot")]
    public emptyplacement[] dot
    {
        get { return dotField; }
        set { dotField = value; }
    }


    public accidental accidental
    {
        get { return accidentalField; }
        set { accidentalField = value; }
    }


    [XmlElement("time-modification")]
    public timemodification timemodification
    {
        get { return timemodificationField; }
        set { timemodificationField = value; }
    }


    public stem stem
    {
        get { return stemField; }
        set { stemField = value; }
    }


    public notehead notehead
    {
        get { return noteheadField; }
        set { noteheadField = value; }
    }


    [XmlElement("notehead-text")]
    public noteheadtext noteheadtext
    {
        get { return noteheadtextField; }
        set { noteheadtextField = value; }
    }


    [XmlElement(DataType = "positiveInteger")]
    public string staff
    {
        get { return staffField; }
        set { staffField = value; }
    }


    [XmlElement("beam")]
    public beam[] beam
    {
        get { return beamField; }
        set { beamField = value; }
    }


    [XmlElement("notations")]
    public notations[] notations
    {
        get { return notationsField; }
        set { notationsField = value; }
    }


    [XmlElement("lyric")]
    public lyric[] lyric
    {
        get { return lyricField; }
        set { lyricField = value; }
    }


    public play play
    {
        get { return playField; }
        set { playField = value; }
    }


    [XmlAttribute("default-x")]
    public decimal defaultx
    {
        get { return defaultxField; }
        set { defaultxField = value; }
    }


    [XmlIgnore]
    public bool defaultxSpecified
    {
        get { return defaultxFieldSpecified; }
        set { defaultxFieldSpecified = value; }
    }


    [XmlAttribute("default-y")]
    public decimal defaulty
    {
        get { return defaultyField; }
        set { defaultyField = value; }
    }


    [XmlIgnore]
    public bool defaultySpecified
    {
        get { return defaultyFieldSpecified; }
        set { defaultyFieldSpecified = value; }
    }


    [XmlAttribute("relative-x")]
    public decimal relativex
    {
        get { return relativexField; }
        set { relativexField = value; }
    }


    [XmlIgnore]
    public bool relativexSpecified
    {
        get { return relativexFieldSpecified; }
        set { relativexFieldSpecified = value; }
    }


    [XmlAttribute("relative-y")]
    public decimal relativey
    {
        get { return relativeyField; }
        set { relativeyField = value; }
    }


    [XmlIgnore]
    public bool relativeySpecified
    {
        get { return relativeyFieldSpecified; }
        set { relativeyFieldSpecified = value; }
    }


    [XmlAttribute("font-family", DataType = "token")]
    public string fontfamily
    {
        get { return fontfamilyField; }
        set { fontfamilyField = value; }
    }


    [XmlAttribute("font-style")]
    public fontstyle fontstyle
    {
        get { return fontstyleField; }
        set { fontstyleField = value; }
    }


    [XmlIgnore]
    public bool fontstyleSpecified
    {
        get { return fontstyleFieldSpecified; }
        set { fontstyleFieldSpecified = value; }
    }


    [XmlAttribute("font-size")]
    public string fontsize
    {
        get { return fontsizeField; }
        set { fontsizeField = value; }
    }


    [XmlAttribute("font-weight")]
    public fontweight fontweight
    {
        get { return fontweightField; }
        set { fontweightField = value; }
    }


    [XmlIgnore]
    public bool fontweightSpecified
    {
        get { return fontweightFieldSpecified; }
        set { fontweightFieldSpecified = value; }
    }


    [XmlAttribute(DataType = "token")]
    public string color
    {
        get { return colorField; }
        set { colorField = value; }
    }


    [XmlAttribute("print-dot")]
    public yesno printdot
    {
        get { return printdotField; }
        set { printdotField = value; }
    }


    [XmlIgnore]
    public bool printdotSpecified
    {
        get { return printdotFieldSpecified; }
        set { printdotFieldSpecified = value; }
    }


    [XmlAttribute("print-lyric")]
    public yesno printlyric
    {
        get { return printlyricField; }
        set { printlyricField = value; }
    }


    [XmlIgnore]
    public bool printlyricSpecified
    {
        get { return printlyricFieldSpecified; }
        set { printlyricFieldSpecified = value; }
    }


    [XmlAttribute]
    public decimal dynamics
    {
        get { return dynamicsField; }
        set { dynamicsField = value; }
    }


    [XmlIgnore]
    public bool dynamicsSpecified
    {
        get { return dynamicsFieldSpecified; }
        set { dynamicsFieldSpecified = value; }
    }


    [XmlAttribute("end-dynamics")]
    public decimal enddynamics
    {
        get { return enddynamicsField; }
        set { enddynamicsField = value; }
    }


    [XmlIgnore]
    public bool enddynamicsSpecified
    {
        get { return enddynamicsFieldSpecified; }
        set { enddynamicsFieldSpecified = value; }
    }


    [XmlAttribute]
    public decimal attack
    {
        get { return attackField; }
        set { attackField = value; }
    }


    [XmlIgnore]
    public bool attackSpecified
    {
        get { return attackFieldSpecified; }
        set { attackFieldSpecified = value; }
    }


    [XmlAttribute]
    public decimal release
    {
        get { return releaseField; }
        set { releaseField = value; }
    }


    [XmlIgnore]
    public bool releaseSpecified
    {
        get { return releaseFieldSpecified; }
        set { releaseFieldSpecified = value; }
    }


    [XmlAttribute("time-only", DataType = "token")]
    public string timeonly
    {
        get { return timeonlyField; }
        set { timeonlyField = value; }
    }


    [XmlAttribute]
    public yesno pizzicato
    {
        get { return pizzicatoField; }
        set { pizzicatoField = value; }
    }


    [XmlIgnore]
    public bool pizzicatoSpecified
    {
        get { return pizzicatoFieldSpecified; }
        set { pizzicatoFieldSpecified = value; }
    }
}