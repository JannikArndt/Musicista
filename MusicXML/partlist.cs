[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(TypeName = "part-list")]
public partial class partlist
{

    private partgroup[] partgroupField;

    private scorepart scorepartField;

    private object[] itemsField;


    [System.Xml.Serialization.XmlElementAttribute("part-group", Order = 0)]
    public partgroup[] partgroup
    {
        get
        {
            return this.partgroupField;
        }
        set
        {
            this.partgroupField = value;
        }
    }


    [System.Xml.Serialization.XmlElementAttribute("score-part", Order = 1)]
    public scorepart scorepart
    {
        get
        {
            return this.scorepartField;
        }
        set
        {
            this.scorepartField = value;
        }
    }


    [System.Xml.Serialization.XmlElementAttribute("part-group", typeof(partgroup), Order = 2)]
    [System.Xml.Serialization.XmlElementAttribute("score-part", typeof(scorepart), Order = 2)]
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
}