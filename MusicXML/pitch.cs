using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[GeneratedCode("xsd", "4.0.30319.33440")]
[Serializable]
[DebuggerStepThrough]
[DesignerCategory("code")]
public class pitch
{
    private decimal alterField;

    private bool alterFieldSpecified;

    private string octaveField;
    private step stepField;


    public step step
    {
        get { return stepField; }
        set { stepField = value; }
    }


    public decimal alter
    {
        get { return alterField; }
        set { alterField = value; }
    }


    [XmlIgnore]
    public bool alterSpecified
    {
        get { return alterFieldSpecified; }
        set { alterFieldSpecified = value; }
    }


    [XmlElement(DataType = "integer")]
    public string octave
    {
        get { return octaveField; }
        set { octaveField = value; }
    }
}