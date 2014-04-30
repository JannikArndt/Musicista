using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;


[GeneratedCode("xsd", "4.0.30319.33440")]
[Serializable]
[DebuggerStepThrough]
[DesignerCategory("code")]
public class work
{
    private opus opusField;
    private string worknumberField;

    private string worktitleField;

    
    [XmlElement("work-number")]
    public string worknumber
    {
        get { return worknumberField; }
        set { worknumberField = value; }
    }

    
    [XmlElement("work-title")]
    public string worktitle
    {
        get { return worktitleField; }
        set { worktitleField = value; }
    }

    
    public opus opus
    {
        get { return opusField; }
        set { opusField = value; }
    }
}