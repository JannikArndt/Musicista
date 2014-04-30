using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;


[GeneratedCode("xsd", "4.0.30319.33440")]
[Serializable]
[DebuggerStepThrough]
[DesignerCategory("code")]
public class ending
{
    private decimal endlengthField;

    private bool endlengthFieldSpecified;
    private string numberField;

    private yesno printobjectField;

    private bool printobjectFieldSpecified;

    private decimal textxField;

    private bool textxFieldSpecified;

    private decimal textyField;

    private bool textyFieldSpecified;
    private startstopdiscontinue typeField;

    private string valueField;

    
    [XmlAttribute(DataType = "token")]
    public string number
    {
        get { return numberField; }
        set { numberField = value; }
    }

    
    [XmlAttribute]
    public startstopdiscontinue type
    {
        get { return typeField; }
        set { typeField = value; }
    }

    
    [XmlAttribute("print-object")]
    public yesno printobject
    {
        get { return printobjectField; }
        set { printobjectField = value; }
    }

    
    [XmlIgnore]
    public bool printobjectSpecified
    {
        get { return printobjectFieldSpecified; }
        set { printobjectFieldSpecified = value; }
    }

    
    [XmlAttribute("end-length")]
    public decimal endlength
    {
        get { return endlengthField; }
        set { endlengthField = value; }
    }

    
    [XmlIgnore]
    public bool endlengthSpecified
    {
        get { return endlengthFieldSpecified; }
        set { endlengthFieldSpecified = value; }
    }

    
    [XmlAttribute("text-x")]
    public decimal textx
    {
        get { return textxField; }
        set { textxField = value; }
    }

    
    [XmlIgnore]
    public bool textxSpecified
    {
        get { return textxFieldSpecified; }
        set { textxFieldSpecified = value; }
    }

    
    [XmlAttribute("text-y")]
    public decimal texty
    {
        get { return textyField; }
        set { textyField = value; }
    }

    
    [XmlIgnore]
    public bool textySpecified
    {
        get { return textyFieldSpecified; }
        set { textyFieldSpecified = value; }
    }

    
    [XmlText]
    public string Value
    {
        get { return valueField; }
        set { valueField = value; }
    }
}