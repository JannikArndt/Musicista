using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[GeneratedCode("xsd", "4.0.30319.33440")]
[Serializable]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(TypeName = "part-list")]
public class partlist
{
    private object[] itemsField;
    private partgroup[] partgroupField;

    private scorepart scorepartField;


    [XmlElement("part-group", Order = 0)]
    public partgroup[] partgroup
    {
        get { return partgroupField; }
        set { partgroupField = value; }
    }


    [XmlElement("score-part", Order = 1)]
    public scorepart scorepart
    {
        get { return scorepartField; }
        set { scorepartField = value; }
    }


    [XmlElement("part-group", typeof(partgroup), Order = 2)]
    [XmlElement("score-part", typeof(scorepart), Order = 2)]
    public object[] Items
    {
        get { return itemsField; }
        set { itemsField = value; }
    }
}