using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;


[GeneratedCode("xsd", "4.0.30319.33440")]
[Serializable]
[DebuggerStepThrough]
[DesignerCategory("code")]
public class barline
{
    private barstylecolor barstyleField;
    private string coda1Field;

    private emptyprintstylealign codaField;
    private decimal divisionsField;

    private bool divisionsFieldSpecified;

    private ending endingField;
    private fermata[] fermataField;
    private formattedtext footnoteField;

    private level levelField;

    private rightleftmiddle locationField;
    private repeat repeatField;

    private string segno1Field;
    private emptyprintstylealign segnoField;
    private wavyline wavylineField;

    public barline()
    {
        locationField = rightleftmiddle.right;
    }

    
    [XmlElement("bar-style")]
    public barstylecolor barstyle
    {
        get { return barstyleField; }
        set { barstyleField = value; }
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

    
    [XmlElement("wavy-line")]
    public wavyline wavyline
    {
        get { return wavylineField; }
        set { wavylineField = value; }
    }

    
    public emptyprintstylealign segno
    {
        get { return segnoField; }
        set { segnoField = value; }
    }

    
    public emptyprintstylealign coda
    {
        get { return codaField; }
        set { codaField = value; }
    }

    
    [XmlElement("fermata")]
    public fermata[] fermata
    {
        get { return fermataField; }
        set { fermataField = value; }
    }

    
    public ending ending
    {
        get { return endingField; }
        set { endingField = value; }
    }

    
    public repeat repeat
    {
        get { return repeatField; }
        set { repeatField = value; }
    }

    
    [XmlAttribute]
    [DefaultValue(rightleftmiddle.right)]
    public rightleftmiddle location
    {
        get { return locationField; }
        set { locationField = value; }
    }

    
    [XmlAttribute("segno", DataType = "token")]
    public string segno1
    {
        get { return segno1Field; }
        set { segno1Field = value; }
    }

    
    [XmlAttribute("coda", DataType = "token")]
    public string coda1
    {
        get { return coda1Field; }
        set { coda1Field = value; }
    }

    
    [XmlAttribute]
    public decimal divisions
    {
        get { return divisionsField; }
        set { divisionsField = value; }
    }

    
    [XmlIgnore]
    public bool divisionsSpecified
    {
        get { return divisionsFieldSpecified; }
        set { divisionsFieldSpecified = value; }
    }
}