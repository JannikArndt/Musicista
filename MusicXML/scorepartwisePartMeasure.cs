using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[GeneratedCode("xsd", "4.0.30319.33440")]
[Serializable]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(AnonymousType = true)]
public class scorepartwisePartMeasure
{
    private yesno implicitField;

    private bool implicitFieldSpecified;
    private object[] itemsField;

    private yesno noncontrollingField;

    private bool noncontrollingFieldSpecified;
    private string numberField;

    private decimal widthField;

    private bool widthFieldSpecified;


    [XmlElement("attributes", typeof(attributes))]
    [XmlElement("backup", typeof(backup))]
    [XmlElement("barline", typeof(barline))]
    [XmlElement("bookmark", typeof(bookmark))]
    [XmlElement("direction", typeof(direction))]
    [XmlElement("figured-bass", typeof(figuredbass))]
    [XmlElement("forward", typeof(forward))]
    [XmlElement("grouping", typeof(grouping))]
    [XmlElement("harmony", typeof(harmony))]
    [XmlElement("link", typeof(link))]
    [XmlElement("note", typeof(note))]
    [XmlElement("print", typeof(print))]
    [XmlElement("sound", typeof(sound))]
    public object[] Items
    {
        get { return itemsField; }
        set { itemsField = value; }
    }


    [XmlAttribute(DataType = "token")]
    public string number
    {
        get { return numberField; }
        set { numberField = value; }
    }


    [XmlAttribute]
    public yesno @implicit
    {
        get { return implicitField; }
        set { implicitField = value; }
    }


    [XmlIgnore]
    public bool implicitSpecified
    {
        get { return implicitFieldSpecified; }
        set { implicitFieldSpecified = value; }
    }


    [XmlAttribute("non-controlling")]
    public yesno noncontrolling
    {
        get { return noncontrollingField; }
        set { noncontrollingField = value; }
    }


    [XmlIgnore]
    public bool noncontrollingSpecified
    {
        get { return noncontrollingFieldSpecified; }
        set { noncontrollingFieldSpecified = value; }
    }


    [XmlAttribute]
    public decimal width
    {
        get { return widthField; }
        set { widthField = value; }
    }


    [XmlIgnore]
    public bool widthSpecified
    {
        get { return widthFieldSpecified; }
        set { widthFieldSpecified = value; }
    }
}