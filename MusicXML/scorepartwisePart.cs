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
public class scorepartwisePart
{
    private string idField;
    private scorepartwisePartMeasure[] measureField;


    [XmlElement("measure")]
    public scorepartwisePartMeasure[] measure
    {
        get { return measureField; }
        set { measureField = value; }
    }


    [XmlAttribute(DataType = "IDREF")]
    public string id
    {
        get { return idField; }
        set { idField = value; }
    }
}