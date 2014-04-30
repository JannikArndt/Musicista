using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Schema;
using System.Xml.Serialization;


[GeneratedCode("xsd", "4.0.30319.33440")]
[Serializable]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(TypeName = "formatted-text")]
public class formattedtext
{
    private string langField;

    private string spaceField;

    private string valueField;

    
    [XmlAttribute(Form = XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
    public string lang
    {
        get { return langField; }
        set { langField = value; }
    }

    
    [XmlAttribute(Form = XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
    public string space
    {
        get { return spaceField; }
        set { spaceField = value; }
    }

    
    [XmlText]
    public string Value
    {
        get { return valueField; }
        set { valueField = value; }
    }
}