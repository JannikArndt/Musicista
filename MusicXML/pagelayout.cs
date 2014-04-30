[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(TypeName = "page-layout")]
public partial class pagelayout
{

    private decimal pageheightField;

    private decimal pagewidthField;

    private pagemargins[] pagemarginsField;


    [System.Xml.Serialization.XmlElementAttribute("page-height")]
    public decimal pageheight
    {
        get
        {
            return this.pageheightField;
        }
        set
        {
            this.pageheightField = value;
        }
    }


    [System.Xml.Serialization.XmlElementAttribute("page-width")]
    public decimal pagewidth
    {
        get
        {
            return this.pagewidthField;
        }
        set
        {
            this.pagewidthField = value;
        }
    }


    [System.Xml.Serialization.XmlElementAttribute("page-margins")]
    public pagemargins[] pagemargins
    {
        get
        {
            return this.pagemarginsField;
        }
        set
        {
            this.pagemarginsField = value;
        }
    }
}