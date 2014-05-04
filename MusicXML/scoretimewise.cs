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
[XmlRoot("score-timewise", Namespace = "", IsNullable = false)]
public class scoretimewise
{
    private credit[] creditField;
    private defaults defaultsField;
    private identification identificationField;
    private scoretimewiseMeasure[] measureField;
    private string movementnumberField;

    private string movementtitleField;

    private partlist partlistField;

    private string versionField;
    private work workField;

    public scoretimewise()
    {
        versionField = "1.0";
    }


    public work work
    {
        get { return workField; }
        set { workField = value; }
    }


    [XmlElement("movement-number")]
    public string movementnumber
    {
        get { return movementnumberField; }
        set { movementnumberField = value; }
    }


    [XmlElement("movement-title")]
    public string movementtitle
    {
        get { return movementtitleField; }
        set { movementtitleField = value; }
    }


    public identification identification
    {
        get { return identificationField; }
        set { identificationField = value; }
    }


    public defaults defaults
    {
        get { return defaultsField; }
        set { defaultsField = value; }
    }


    [XmlElement("credit")]
    public credit[] credit
    {
        get { return creditField; }
        set { creditField = value; }
    }


    [XmlElement("part-list")]
    public partlist partlist
    {
        get { return partlistField; }
        set { partlistField = value; }
    }


    [XmlElement("measure")]
    public scoretimewiseMeasure[] measure
    {
        get { return measureField; }
        set { measureField = value; }
    }


    [XmlAttribute(DataType = "token")]
    [DefaultValue("1.0")]
    public string version
    {
        get { return versionField; }
        set { versionField = value; }
    }
}