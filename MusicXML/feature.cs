using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[GeneratedCode("xsd", "4.0.30319.33440")]
[Serializable]
[DebuggerStepThrough]
[DesignerCategory("code")]
public class feature
{
    private string typeField;

    private string valueField;

    [XmlAttribute(DataType = "token")]
    public string type
    {
        get { return typeField; }
        set { typeField = value; }
    }

    [XmlText]
    public string Value
    {
        get { return valueField; }
        set { valueField = value; }
    }
}