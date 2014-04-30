[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class notations
{

    private formattedtext footnoteField;

    private level levelField;

    private object[] itemsField;

    private yesno printobjectField;

    private bool printobjectFieldSpecified;


    public formattedtext footnote
    {
        get
        {
            return this.footnoteField;
        }
        set
        {
            this.footnoteField = value;
        }
    }


    public level level
    {
        get
        {
            return this.levelField;
        }
        set
        {
            this.levelField = value;
        }
    }


    [System.Xml.Serialization.XmlElementAttribute("accidental-mark", typeof(accidentalmark))]
    [System.Xml.Serialization.XmlElementAttribute("arpeggiate", typeof(arpeggiate))]
    [System.Xml.Serialization.XmlElementAttribute("articulations", typeof(articulations))]
    [System.Xml.Serialization.XmlElementAttribute("dynamics", typeof(dynamics))]
    [System.Xml.Serialization.XmlElementAttribute("fermata", typeof(fermata))]
    [System.Xml.Serialization.XmlElementAttribute("glissando", typeof(glissando))]
    [System.Xml.Serialization.XmlElementAttribute("non-arpeggiate", typeof(nonarpeggiate))]
    [System.Xml.Serialization.XmlElementAttribute("ornaments", typeof(ornaments))]
    [System.Xml.Serialization.XmlElementAttribute("other-notation", typeof(othernotation))]
    [System.Xml.Serialization.XmlElementAttribute("slide", typeof(slide))]
    [System.Xml.Serialization.XmlElementAttribute("slur", typeof(slur))]
    [System.Xml.Serialization.XmlElementAttribute("technical", typeof(technical))]
    [System.Xml.Serialization.XmlElementAttribute("tied", typeof(tied))]
    [System.Xml.Serialization.XmlElementAttribute("tuplet", typeof(tuplet))]
    public object[] Items
    {
        get
        {
            return this.itemsField;
        }
        set
        {
            this.itemsField = value;
        }
    }


    [System.Xml.Serialization.XmlAttributeAttribute("print-object")]
    public yesno printobject
    {
        get
        {
            return this.printobjectField;
        }
        set
        {
            this.printobjectField = value;
        }
    }


    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool printobjectSpecified
    {
        get
        {
            return this.printobjectFieldSpecified;
        }
        set
        {
            this.printobjectFieldSpecified = value;
        }
    }
}