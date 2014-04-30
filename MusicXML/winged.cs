using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;


[GeneratedCode("xsd", "4.0.30319.33440")]
[Serializable]
public enum winged
{
    
    none,

    
    straight,

    
    curved,

    
    [XmlEnum("double-straight")]
    doublestraight,

    
    [XmlEnum("double-curved")]
    doublecurved,
}